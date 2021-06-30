using PwBasicBot.Actions;
using PwBasicBot.Mode.ActionsModes;

namespace PwBasicBot.Mode
{
    public class BotModes
    {
        public static BaseBotActionMode landFarmMode = new BaseBotActionMode("LandFarm", typeof(FindEnemy), typeof(LandAttack), typeof(CollectItens), typeof(Heal));
        public static BaseBotActionMode flyToHealMode = new BaseBotActionMode("FlyToHeal", typeof(FlyAway), typeof(IdleHeal));
    }
}
