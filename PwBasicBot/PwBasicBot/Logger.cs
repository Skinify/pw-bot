﻿using PwBasicBot.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwBasicBot
{
    public class Logger
    {
        private readonly Bot bot;
        
        public Logger(Bot bot)
        {
            this.bot = bot;
            Console.CursorVisible = false;
        }

       public void Log() {
            var whiteSpace = new StringBuilder();
            whiteSpace.Append(' ', 30);
            Console.SetCursorPosition(0, 0);
            var sb = new StringBuilder();

            sb.AppendLine(string.Concat("Status do bot: ", Enum.GetName(typeof(BotStatusEnum), bot.botStatus), whiteSpace));
            sb.AppendLine("-------------------------------");
            sb.AppendLine(string.Concat("Modo do bot: ", bot.baseBotActionMode.modeName, whiteSpace));
            sb.AppendLine(string.Concat("Proxima ação: ", bot.currentAction != null ? bot.currentAction.GetType().Name : "Carregando", whiteSpace));
            sb.AppendLine(string.Concat("Fila de ações: ", GetNextActions(bot.actionQueue), whiteSpace));
            sb.AppendLine("-------------------------------");
            sb.AppendLine(string.Concat("Vida personagem: ", Bot.player.CurrentHp, whiteSpace));
            sb.AppendLine(string.Concat("Mp personagem: ", Bot.player.CurrentMp, whiteSpace));

            Console.Write(sb);
       }

        private string GetNextActions(Queue<IAction> actionQueue)
        {
            Queue<IAction> actionQueueClone = new Queue<IAction>(actionQueue);

            StringBuilder sb = new StringBuilder();

            for(int count = 0; count < actionQueue.Count; count++)
            {
                sb.Append(actionQueueClone.Dequeue().GetType().Name);
                if (count != actionQueue.Count - 1)
                    sb.Append(" -> ");
            }

            if(sb.Length > 0)
            {
                return sb.ToString();
            }

            return "Carregando";
        }
    }
}