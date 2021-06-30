using PwBasicBot.Enuns;
using PwBasicBot.Offsets;
using System;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace PwBasicBot.Actions
{
    public class FindEnemy : BaseAction, IAction
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

            Timer verifyFlyingTimer = new Timer(30000);
            verifyFlyingTimer.Elapsed += (sender, e) => VerifyIsFlying(sender, e , gameWindowHandler);
            verifyFlyingTimer.Start();

            while (true)
            {
                var targetNpc = Memory.ReadPointerOffsets<int>(Bot.gameModuleAddress, AllOffsets.isTargetingNpc);
                if (targetNpc == 1)
                {
                    break;
                }
                else
                {
                    Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, (int)KeysEnum.VK_TAB, 0);
                }
                Thread.Sleep(500);
            }

            Finish();
        }

        private void VerifyIsFlying(object source, ElapsedEventArgs e, IntPtr gameWindowHandler)
        {
            if (Memory.ReadPointerOffsets<int>(Bot.gameModuleAddress, AllOffsets.isFlying) == 1)
            {
                Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, (int)KeysEnum.VK_F6, 0);
            }
        }

    }
}
