using PwBasicBot.Enuns;
using PwBasicBot.Offsets;
using System;
using System.Threading;

namespace PwBasicBot.Actions
{
    public class IdleHeal : BaseAction, IAction
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

            Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, (int)KeysEnum.VK_ESCAPE, 0);

            Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, GameSlotsEnum.ZEN_HEAL, 0);

            while (Bot.player.CurrentHp != Bot.player.MaxHp && Memory.ReadPointerOffsets<int>(Bot.gameModuleAddress, AllOffsets.isTargetingNpc) == 0)
            {
                Thread.Sleep(1000); 
            }
             
            Finish();
        } 
    }
}
