using PwBasicBot.Enuns;
using PwBasicBot.Items;
using PwBasicBot.Macros;
using PwBasicBot.Offsets;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace PwBasicBot.Configs
{
    public class ConfConstants
    {
        public static BindingSection keyBindingConfig;
        public static MacroSection macroConfig;
        public static ItemSection itemConfig;
        public static TmpAdressSection tmpAddressConfig;
        public static int cityRecall;
        public static int mineralRespawn;
        public static int tryGetDropNTimes;
        public static int namesLength;
        public static string[] minerals;
        public static string[] prioritizeMobs;

        static ConfConstants()
        {
            Reset();
        }

        public static void Reset()
        {
            keyBindingConfig = ConfigurationManager.GetSection("Binding") as BindingSection;
            macroConfig = ConfigurationManager.GetSection("Macro") as MacroSection;
            itemConfig = ConfigurationManager.GetSection("Item") as ItemSection;
            tmpAddressConfig = ConfigurationManager.GetSection("TmpAdress") as TmpAdressSection;
            cityRecall = Convert.ToInt32(ConfigurationManager.AppSettings["cityRecall"]);
            mineralRespawn = Convert.ToInt32(ConfigurationManager.AppSettings["mineralRespawn"]);
            mineralRespawn = Convert.ToInt32(ConfigurationManager.AppSettings["mineralRespawn"]);
            tryGetDropNTimes = Convert.ToInt32(ConfigurationManager.AppSettings["tryGetDropNTimes"]);
            namesLength = Convert.ToInt32(ConfigurationManager.AppSettings["namesLength"]);
            minerals = ConfigurationManager.AppSettings["minerals"].Split(',');
            prioritizeMobs = ConfigurationManager.AppSettings["prioritizeMobs"].Split(',');
            AllOffsets.Reset();
            AllMacros.Reset();
            AllItems.Reset();
            GameSlotsEnum.Reset();
        }

    }
}
