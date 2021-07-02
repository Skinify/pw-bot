using PwBasicBot.Enuns;
using PwBasicBot.Items;
using PwBasicBot.Offsets;
using System;
using System.Threading;

namespace PwBasicBot.Actions
{
    public class RecoverHp : BaseAction, IAction
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

            while(ActionStatus == ActionStatusEnum.RUNNING)
            {
                if (AllItems.hpPotion.ready)
                {
                    AllItems.hpPotion.UseItem(gameWindowHandler);
                    Finish();
                }
                Thread.Sleep(100);
            }
            Finish();
        }
    }
}
