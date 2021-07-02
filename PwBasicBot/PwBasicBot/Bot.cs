using PwBasicBot.Actions;
using PwBasicBot.Enuns;
using PwBasicBot.Mode;
using PwBasicBot.Mode.ActionsModes;
using PwBasicBot.Offsets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace PwBasicBot
{
    public class Bot
    {
        public BotStatusEnum botStatus;

        private readonly Process gameProcess;

        public static int gameModuleAddress;
        public static int gameModuleValue;

        private const int ACTION_QUEUE_SIZE = 4;
        private const int ACTION_TIMEOUT = 300;
        private const int ITEM_TIMEOUT = 100;
        private const int REFRESH_RATE = 500;

        private Timer actionTimer;
        private Timer itemsTimer;
        private CancellationTokenSource cancellationToken;

        public Queue<IAction> actionQueue;
        public Queue<IAction> itensQueue;
        public IAction currentAction;
        public IAction currentItem;
        public ActionMode baseBotActionMode;

        public static Character player;

        public Logger logger;

        public Bot(Process process)
        {
            gameProcess = process;
            Memory.Attatch(gameProcess.ProcessName);
            gameModuleAddress = Memory.GetModuleAddress(string.Concat(gameProcess.ProcessName, ".exe"));
            gameModuleValue = Memory.ReadMemory<int>(gameModuleAddress);
            actionQueue = new Queue<IAction>();
            itensQueue = new Queue<IAction>();
            player = new Character();
            logger = new Logger(this);
            cancellationToken = new CancellationTokenSource();
            //var AAAAA = Memory.ReadMemory<IntPtr>(gameModuleAddress + AllOffsets.hpOffset.Pointer);
        }

        public void Start()
        {
            botStatus = BotStatusEnum.STARTING;
            Thread gameAtt = new Thread(OnGameUpdate);
            gameAtt.Start();
        } 

        private void OnGameUpdate()
        {
            try
            {
                botStatus = BotStatusEnum.RUNNING;

                actionTimer = new Timer(ACTION_TIMEOUT);
                actionTimer.Elapsed += DoAction; 
                actionTimer.AutoReset = true;
                actionTimer.Enabled = true;

                itemsTimer = new Timer(ITEM_TIMEOUT);
                itemsTimer.Elapsed += UseItem;
                itemsTimer.AutoReset = true;
                itemsTimer.Enabled = true;

                baseBotActionMode = AllActionModes.landFarmMode;

                while (botStatus == BotStatusEnum.RUNNING)
                {
                    AttPlayerStatus();
                    logger.Log();
                    Task.Delay(REFRESH_RATE, cancellationToken.Token).ConfigureAwait(false);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void VerifyNeedItem()
        {
            if (player.CurrentHp < player.MaxHp * 0.8 && player.CurrentHp != 0)
            {
                var recoverHp = new RecoverHp();
                if (!itensQueue.Contains(recoverHp))
                {
                    itensQueue.Enqueue(recoverHp);
                }
            }

            if (player.CurrentMp < player.MaxMp * 0.8 && player.CurrentMp != 0)
            {
                var recoverMp = new RecoverMp();
                if (!itensQueue.Contains(recoverMp))
                {
                    itensQueue.Enqueue(recoverMp);
                }
            }
        }

        private void UseItem(object source, ElapsedEventArgs e)
        {
            if (currentItem != null)
            {
                if (currentItem.GetActionStatus() == ActionStatusEnum.STARTING)
                {
                    currentItem.Start(gameProcess.MainWindowHandle);
                    return;
                }

                if (currentItem.GetActionStatus() == ActionStatusEnum.RUNNING)
                    return;

                if (currentItem.GetActionStatus() == ActionStatusEnum.FINISHED)
                    currentItem = null;
            }
            else if (itensQueue.Count > 0)
            {
                currentItem = itensQueue.Dequeue();
            }

            VerifyNeedItem();
        }

        private void DoAction(object source, ElapsedEventArgs e)
        {
            if (currentAction != null)
            {
                if (currentAction.GetActionStatus() == ActionStatusEnum.STARTING){
                    currentAction.Start(gameProcess.MainWindowHandle);
                    return;
                }

                if (currentAction.GetActionStatus() == ActionStatusEnum.RUNNING)
                    return;

                if (currentAction.GetActionStatus() == ActionStatusEnum.FINISHED)
                    currentAction = null;
            }
            else if(actionQueue.Count > 0)
            {
                currentAction = actionQueue.Dequeue();
            }

            FindNewAction();
        }

        private void FindNewAction()
        {
            if (actionQueue.Count > ACTION_QUEUE_SIZE)
                return;

            if(player.CurrentHp < player.MaxHp * 0.6 && !player.Fighting)
            {
                ChangeBotMode(AllActionModes.flyToHealMode);
            }
            else
            {
                ChangeBotMode(AllActionModes.landFarmMode);
            }

            Type nextActionType = baseBotActionMode.NextAction();
            actionQueue.Enqueue((IAction)Activator.CreateInstance(nextActionType));
        }

        private void ChangeBotMode(ActionMode mode)
        {
            if (baseBotActionMode == mode)
                return;

            baseBotActionMode = mode;
            ActionMode.ResetCounter();
            actionQueue.Clear();
        }

        private void AttPlayerStatus()
        {
            player.CurrentHp = Memory.ReadPointerOffsets<int>(gameModuleAddress, AllOffsets.currentHp);
            player.MaxHp = Memory.ReadPointerOffsets<int>(gameModuleAddress, AllOffsets.maxHp);
            player.CurrentMp = Memory.ReadPointerOffsets<int>(gameModuleAddress, AllOffsets.currentMp);
            player.MaxMp = Memory.ReadPointerOffsets<int>(gameModuleAddress, AllOffsets.maxMp);
            player.Level = Memory.ReadPointerOffsets<int>(gameModuleAddress, AllOffsets.level);
            player.Cultivo = Memory.ReadPointerOffsets<int>(gameModuleAddress, AllOffsets.cultivo);
            player.CurrentChi = Memory.ReadPointerOffsets<int>(gameModuleAddress, AllOffsets.currentChi);
            player.MaxChi = Memory.ReadPointerOffsets<int>(gameModuleAddress, AllOffsets.maxChi);
            player.Gold = Memory.ReadPointerOffsets<int>(gameModuleAddress, AllOffsets.gold);
            player.Fighting = Memory.ReadPointerOffsets<int>(gameModuleAddress, AllOffsets.isTargetingNpc) == 1;

            Pinvokes.PostMessage(gameProcess.MainWindowHandle, (uint)KeyStatusEnum.WM_KEYDOWN, (int)KeysEnum.VK_Y_KEY, 0);

        }

    }
}
