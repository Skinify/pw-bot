using PwBasicBot.Enuns;
using System;
using System.Timers;

namespace PwBasicBot.Macros.Base
{
    public class MacroAction
    {
        private readonly Timer macroTimeOut;
        private readonly int key;
        private readonly int minMp;
        public bool ready;

        public MacroAction(int macroTimeOut, int minMp, int key)
        {
            this.minMp = minMp;
            this.key = key;
            this.ready = true;
            this.macroTimeOut = new Timer(macroTimeOut)
            {
                Enabled = true,
                AutoReset = false
            };
            this.macroTimeOut.Elapsed += OnMacroReady;
        }

        public void UseMacro(IntPtr gameWindowHandler)
        {
            if(Bot.player.CurrentMp > minMp){
                if (ready)
                {
                    Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, key, 0);
                    macroTimeOut.Start();
                    ready = false;
                }
            }
        }

        private void OnMacroReady(object sender, ElapsedEventArgs e)
        {
            this.ready = true;
            macroTimeOut.Stop();
        }
    }
}
