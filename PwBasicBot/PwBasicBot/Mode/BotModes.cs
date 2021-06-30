using PwBasicBot.Actions;
using PwBasicBot.Mode.ActionsModes;

namespace PwBasicBot.Mode
{
    public class BotModes
    {
        public static BaseBotActionMode farmMode = new BaseBotActionMode("Farm", typeof(FindEnemy), typeof(Attack), typeof(CollectItens), typeof(Heal));
        public static BaseBotActionMode runMode = new BaseBotActionMode("Run", typeof(FlyAway), typeof(Idle));
    }
}
