using PwBasicBot.Enuns;
using System;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace PwBasicBot.Actions
{
    public class FlyAway : BaseAction, IAction
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
            ActionStatus = ActionStatusEnum.RUNNING;
            Pinvokes.SetForegroundWindow(gameWindowHandler);
            Thread.Sleep(500);
            Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, (int)KeysEnum.VK_ESCAPE, 0);
            Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, GameSlotsEnum.FLY, 0);
            Pinvokes.keybd_event((byte)KeysEnum.VK_SPACE, 0xb9, 0, UIntPtr.Zero);
            Thread.Sleep(20000);
            Pinvokes.keybd_event((byte)KeysEnum.VK_SPACE, 0xb9, 0x0002, UIntPtr.Zero);
            Finish();
        } 
    }
}
