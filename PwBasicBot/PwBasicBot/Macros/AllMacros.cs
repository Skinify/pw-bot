using PwBasicBot.Configs;
using PwBasicBot.Macros.Base;

namespace PwBasicBot.Macros
{
    public class AllMacros
    {
        public static MacroAction attackMacro = new MacroAction(
            ConfConstants.macroConfig.Macros.Get("attack").Timeout,
            ConfConstants.macroConfig.Macros.Get("attack").MinMP,
            ConfConstants.macroConfig.Macros.Get("attack").Key
        );

        public static MacroAction buffMacro = new MacroAction(
            ConfConstants.macroConfig.Macros.Get("buff").Timeout,
            ConfConstants.macroConfig.Macros.Get("buff").MinMP,
            ConfConstants.macroConfig.Macros.Get("buff").Key
        );
    }
}
