using PwBasicBot.Enuns;
using System;
using System.Timers;

namespace PwBasicBot.Items.Base
{
    public class UsableItem
    {
        private readonly Timer itemCoolDown;
        private readonly int key;
        public bool ready;

        public UsableItem(int itemCoolDown, int key)
        {
            this.key = key;
            this.ready = true;
            this.itemCoolDown = new Timer(itemCoolDown)
            {
                Enabled = true,
                AutoReset = false
            };
            this.itemCoolDown.Elapsed += OnItemReady;
        }

        public void UseItem(IntPtr gameWindowHandler)
        {
            if (ready)
            {
                Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, key, 0);
                itemCoolDown.Start();
                ready = false;
            }
        }

        private void OnItemReady(object sender, ElapsedEventArgs e)
        {
            this.ready = true;
            itemCoolDown.Stop();
        }
    }
}
