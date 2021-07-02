using System.Configuration;

namespace PwBasicBot.Configs
{
    public class ConfConstants
    {
        public static readonly BindingSection keyBindingConfig = ConfigurationManager.GetSection("Binding") as BindingSection;        
        public static readonly MacroSection macroConfig = ConfigurationManager.GetSection("Macro") as MacroSection;
        public static readonly TmpAdressSection tmpAddressConfig = ConfigurationManager.GetSection("TmpAdress") as TmpAdressSection;
    }
}
