using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace PwBasicBot.Configs
{
    public class ConfConstants
    {
        public static readonly BindingSection keyBindingConfig = ConfigurationManager.GetSection("Binding") as BindingSection;        
        public static readonly MacroSection macroConfig = ConfigurationManager.GetSection("Macro") as MacroSection;
        public static readonly ItemSection itemConfig = ConfigurationManager.GetSection("Item") as ItemSection;
        public static readonly TmpAdressSection tmpAddressConfig = ConfigurationManager.GetSection("TmpAdress") as TmpAdressSection;
        public static readonly int cityRecall = Convert.ToInt32(ConfigurationManager.AppSettings["cityRecall"]);
        public static readonly int mineralRespawn = Convert.ToInt32(ConfigurationManager.AppSettings["mineralRespawn"]);
        public static readonly string[] minerals = ConfigurationManager.AppSettings["minerals"].Split(',');
    }
}
