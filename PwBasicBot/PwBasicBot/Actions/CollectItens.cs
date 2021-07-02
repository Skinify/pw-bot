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

            for (int count = 0; count < 5; count++)
            {
                Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, (int)KeysEnum.VK_F2, 0);
                Thread.Sleep(300);
            }

            Finish();
        }
    }
}
