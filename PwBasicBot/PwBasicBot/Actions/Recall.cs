using PwBasicBot.Enuns;
using System;
using System.Threading;
using System.Timers;

namespace PwBasicBot.Actions
{
    public class Recall : BaseAction, IAction
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

            Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, GameSlotsEnum.CITY_PORTAL, 0);
            Thread.Sleep(20000);
            Finish();
        }

        private void OnGiveUp(Object source, ElapsedEventArgs e)
        {
            Finish();
        }
    }
}
