using PInvoke;
using PwBasicBot.Enuns;
using PwBasicBot.Items;
using PwBasicBot.Offsets;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using Tesseract;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace PwBasicBot.Actions
{
    public class CollectMineral : BaseAction, IAction
    {
        public void Finish()
        {
            ActionStatus = ActionStatusEnum.FINISHED;
        }

        public ActionStatusEnum GetActionStatus()
        {
            return ActionStatus;
        }

        public void Start(IntPtr gameWindowHandler)
        {
            try
            {
                ActionStatus = ActionStatusEnum.RUNNING;

                Random rnd = new Random();

                TesseractEngine tesEngine = new TesseractEngine(null, "por", EngineMode.TesseractAndLstm);
                tesEngine.SetVariable("tessedit_char_whitelist", "abcdefghijklmnopqrstuvxyzABCDEFGHIJKLMNOPQRSTUVXYZáéíóúÁÉÍÓÚ");

                var sucess = false;

                Pinvokes.GetWindowRect(gameWindowHandler, out RECT window);

                int controlbarHeight = 30;
                int widthAdjust = 20;

                window.top = window.top + controlbarHeight;
                window.left = window.left + widthAdjust / 2;
                window.right = window.right - widthAdjust / 2;

                int width = window.right - window.left;
                int height = window.bottom - window.top;

                while (!sucess && Bot.BotStatus == BotStatusEnum.RUNNING)
                {

                    Pinvokes.SetForegroundWindow(gameWindowHandler);
                    Thread.Sleep(200);

                    var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);

                    using (Graphics graphics = Graphics.FromImage(bmp))
                    {
                        ImageAttributes attr = AdjustImage(100);
                        graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                        graphics.PixelOffsetMode = PixelOffsetMode.Half;
                        graphics.CopyFromScreen(window.left, window.top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
                        graphics.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
                    }

                    //bmp.Save(string.Concat(Environment.CurrentDirectory, "/", "pic.png"), ImageFormat.Png);

                    Pix img = PixConverter.ToPix(bmp);
                    PageIteratorLevel pageLevel = PageIteratorLevel.Word;
                    using (var page = tesEngine.Process(img))
                    {
                        var text = page.GetText();
                        using (var iterator = page.GetIterator())
                        {
                            iterator.Begin();
                            do
                            {
                                if (iterator.TryGetBoundingBox(pageLevel, out Tesseract.Rect rect))
                                {
                                    var curText = iterator.GetText(pageLevel);
                                    if (curText.NearMatchArray(Configs.ConfConstants.minerals))
                                    {
                                        Pinvokes.SetCursorPos(rect.X1 + window.left + (rect.Width / 2), rect.Y1 + window.top + (rect.Height / 2) + 10);
                                        Pinvokes.mouse_event((int)MouseEventEnum.LeftDown, 0, 0, 0, 0);
                                        Pinvokes.mouse_event((int)MouseEventEnum.LeftUp, 0, 0, 0, 0);
                                        sucess = true;
                                        Thread.Sleep(200);
                                    }
                                }
                            } while (iterator.Next(pageLevel));
                        }
                        Pinvokes.mouse_event((int)MouseEventEnum.RightDown, 0,0,0,0);
                        Pinvokes.mouse_event((int)MouseEventEnum.Move, rnd.Next(-1000, 1000), rnd.Next(-1000, 1000), 0, 0);
                        Pinvokes.mouse_event((int)MouseEventEnum.RightUp, 0, 0, 0, 0);
                    }
                    Thread.Sleep(2000);
                }

                Thread.Sleep(Configs.ConfConstants.mineralRespawn);

                Finish();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private ImageAttributes AdjustImage(int saturation)
        {
            float rWeight = 0;
            float gWeight = 0;
            float bWeight = 0;

            float a = (1.0f - saturation) * rWeight + saturation;
            float b = (1.0f - saturation) * rWeight;
            float c = (1.0f - saturation) * rWeight;
            float d = (1.0f - saturation) * gWeight;
            float e = (1.0f - saturation) * gWeight + saturation;
            float f = (1.0f - saturation) * gWeight;
            float g = (1.0f - saturation) * bWeight;
            float h = (1.0f - saturation) * bWeight;
            float i = (1.0f - saturation) * bWeight + saturation;

            float[][] ptsArray = {
                                     new float[] {a,  b,  c,  0, 0},
                                     new float[] {d,  e,  f,  0, 0},
                                     new float[] {g,  h,  i,  0, 0},
                                     new float[] {0,  0,  0,  1, 0},
                                     new float[] {0,  0,  0,  0, 1}
                                 };


            ColorMatrix clrMatrix = new ColorMatrix(ptsArray);

            ImageAttributes imageAttr = new ImageAttributes();
            
            imageAttr.SetThreshold(1f);

            imageAttr.SetColorMatrix(clrMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Default);

            return imageAttr;
        }
    }
}
