using System.Configuration;

namespace PwBasicBot.Configs
{
    public class ConfConstants
    {
        public static readonly KeyBindingSection keyBindingConfig = ConfigurationManager.GetSection("KeyBinding") as KeyBindingSection;
        public static readonly TempAddressSection tempAddressConfig = ConfigurationManager.GetSection("TempAddress") as TempAddressSection;
        public static readonly MacroSection macroConfig = ConfigurationManager.GetSection("Macro") as MacroSection;
    }
}
