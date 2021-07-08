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

            Timer verifyFlyingTimer = new Timer(5000);
            verifyFlyingTimer.Elapsed += (sender, e) => VerifyIsFlying(sender, e , gameWindowHandler);
            //verifyFlyingTimer.Start();

            int tentativas = 6;

            int startingFightAux = 0;

            while (Bot.BotStatus == BotStatusEnum.RUNNING)
            {
                var targetNpc = Memory.ReadPointerOffsets<int>(Bot.gameModuleAddress, AllOffsets.isTargetingNpc);

                if (Configs.ConfConstants.prioritizeMobs.Length > 0)
                {
                    tentativas--;
                    var targetName = Memory.ReadString(Bot.gameModuleAddress, AllOffsets.targetName, Configs.ConfConstants.namesLength);
                    if (targetName.MatchArray(Configs.ConfConstants.prioritizeMobs))
                    {
                        tentativas = 0;
                    }
                }
                else
                {
                    tentativas = 0;
                }

                if ((targetNpc == 1 && tentativas <= 0) || (startingFightAux == 0 && targetNpc == 1))
                {
                    break;
                }
                else
                {
                    Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, (int)KeysEnum.VK_TAB, 0);
                }
                startingFightAux++;
                Thread.Sleep(100);
            }

            Finish();
        }

        private void VerifyIsFlying(object source, ElapsedEventArgs e, IntPtr gameWindowHandler)
        {
            if (Memory.ReadPointerOffsets<int>(Bot.gameModuleAddress, AllOffsets.isFlying) == 1)
            {
                Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, GameSlotsEnum.FLY, 0);
            }
        }

    }
}
