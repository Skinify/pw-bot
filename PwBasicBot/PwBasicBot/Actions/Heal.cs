using PwBasicBot.Enuns;
using PwBasicBot.Offsets;
using System;

namespace PwBasicBot.Actions
{
    public class Heal : BaseAction, IAction
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
            if(Bot.player.CurrentHp < Bot.player.MaxHp / 0.6)
            {
                Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, (int)KeysEnum.VK_F4, 0);
            }
            if (Bot.player.CurrentMp < Bot.player.MaxMp / 0.6)
            {
                Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, (int)KeysEnum.VK_F5, 0);
            }

            Finish();
        }
    }
}
