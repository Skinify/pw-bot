using PwBasicBot.Enuns;
using System;
using System.Threading;

namespace PwBasicBot.Actions
{
    public class CollectItens : BaseAction, IAction
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

            for (int count = 0; count < 6; count++)
            {
                Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, GameSlotsEnum.GRAB_ITEMS, 0);
                Thread.Sleep(300);
            }

            Finish();
        }
    }
}
