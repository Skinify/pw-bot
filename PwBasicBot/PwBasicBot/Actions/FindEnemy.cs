using PwBasicBot.Enuns;
using PwBasicBot.Offsets;
using System;

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
            Pinvokes.PostMessage(gameWindowHandler, (uint)KeyStatusEnum.WM_KEYDOWN, (int)KeysEnum.VK_TAB, 0);
            
            var target = Memory.ReadPointerOffsets<int>(Bot.gameModuleAddress, AllOffsets.isTargeting);

            if (target == 1)
            {
                var targetNpc = Memory.ReadPointerOffsets<int>(Bot.gameModuleAddress, AllOffsets.isTargetingNpc);
                if (targetNpc == 1)
                {
                    Finish();
                }
            }


            /*
             
            Ler memoria e verificar se esta completo a action

             */
            Finish();
        }
    }
}
