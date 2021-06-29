﻿using PwBasicBot.Actions;
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
        public BotStatusEnum BotStatus { get; private set; }

        private readonly Process gameProcess;

        public static int gameModuleAddress;
        public static int gameModuleValue;

        private const int ACTION_QUEUE_SIZE = 4;
        private const int ACTION_TIMEOUT = 300;
        private const int REFRESH_RATE = 500;

        private Timer actionTimer;
        private Queue<IAction> actionQueue;
        private IAction currentAction;
        private CancellationTokenSource cancellationToken;
        private BaseBotActionMode baseBotActionMode;

        public static Character player;

        public Bot(Process process)
        {
            gameProcess = process;
            Memory.Attatch(gameProcess.ProcessName);
            gameModuleAddress = Memory.GetModuleAddress(string.Concat(gameProcess.ProcessName, ".exe"));
            gameModuleValue = Memory.ReadMemory<int>(gameModuleAddress);
            actionQueue = new Queue<IAction>();
            player = new Character();
            //var AAAAA = Memory.ReadMemory<IntPtr>(gameModuleAddress + AllOffsets.hpOffset.Pointer);
        }

        public void Start()
        {
            BotStatus = BotStatusEnum.STARTING;
            Thread gameAtt = new Thread(OnGameUpdate);
            gameAtt.Start();
        } 

        public void OnGameUpdate()
        {
            try
            {
                BotStatus = BotStatusEnum.RUNNING;

                cancellationToken = new CancellationTokenSource();

                actionTimer = new Timer(ACTION_TIMEOUT);
                actionTimer.Elapsed += DoAction; 
                actionTimer.AutoReset = true;
                actionTimer.Enabled = true;

                baseBotActionMode = BotModes.farmMode;

                while (BotStatus == BotStatusEnum.RUNNING)
                {
                    AttPlayerStatus();
                    Task.Delay(REFRESH_RATE, cancellationToken.Token).ConfigureAwait(false);
                }
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        private void DoAction(Object source, ElapsedEventArgs e)
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

            /*
            if (BotStatus == BotStatusEnum.RUNNING)
                actionTimer.Start();*/
        }

        private void FindNewAction()
        {
            if (actionQueue.Count > ACTION_QUEUE_SIZE)
                return;
            Type nextActionType = baseBotActionMode.NextAction();
            actionQueue.Enqueue((IAction)Activator.CreateInstance(nextActionType));
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

            /*
            if(player.CurrentHp == 0)
            {
                BotStatus = BotStatusEnum.STOPING;
            }*/

            //player.PlayerName = Memory.ReadPointerOffsets<string>(gameModuleAddress, AllOffsets.name);
        }

    }
}
