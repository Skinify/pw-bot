using PwBasicBot.Enuns;
using System;
using System.Threading;

namespace PwBasicBot.Actions
{
    public class Idle : BaseAction, IAction
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
            Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, (int)KeysEnum.VK_F8, 0);
            while(Bot.player.CurrentHp != Bot.player.MaxHp)
            {
                Thread.Sleep(1000);
            }
            Finish();
        }
    }
}
