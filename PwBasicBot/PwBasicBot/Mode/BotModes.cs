using PwBasicBot.Actions;
using PwBasicBot.Mode.ActionsModes;

namespace PwBasicBot.Mode
{
    public class BotModes
    {
        public static BaseBotActionMode farmMode = new BaseBotActionMode(typeof(FindEnemy), typeof(Attack), typeof(CollectItens), typeof(Heal));
    }
}
