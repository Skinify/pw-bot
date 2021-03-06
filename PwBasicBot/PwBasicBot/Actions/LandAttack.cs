using PwBasicBot.Enuns;
using PwBasicBot.Offsets;
using System;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace PwBasicBot.Actions
{
    public class LandAttack : BaseAction, IAction
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

            /*
            if(Memory.ReadPointerOffsets<int>(Bot.gameModuleAddress, AllOffsets.isFlying) == 1)
            {
                Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, (int)KeysEnum.VK_F6, 0);
            }*/

            if (Macros.AllMacros.buffMacro.ready)
            {
                Macros.AllMacros.buffMacro.UseMacro(gameWindowHandler);
            }

            Timer fightTimeout = new Timer(30000);
            fightTimeout.Elapsed += OnGiveUp;
            fightTimeout.Start();
            while(Memory.ReadPointerOffsets<int>(Bot.gameModuleAddress, AllOffsets.isTargetingNpc) == 1 && 
                ActionStatus != ActionStatusEnum.FINISHED && 
                Bot.BotStatus == BotStatusEnum.RUNNING)
            {
                
                if (Macros.AllMacros.attackMacro.ready)
                {
                    Macros.AllMacros.attackMacro.UseMacro(gameWindowHandler);
                }
                else
                {
                    Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, (int)GameSlotsEnum.BASIC_ATTACK, 0);
                }
                Thread.Sleep(1000);
            }

            Finish();
        }

        private void OnGiveUp(Object source, ElapsedEventArgs e)
        {
            Finish();
        }
    }
}
