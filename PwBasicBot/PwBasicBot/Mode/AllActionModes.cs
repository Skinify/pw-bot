using PwBasicBot.Actions;
using PwBasicBot.Mode.ActionsModes;

namespace PwBasicBot.Mode
{
    public class AllActionModes
    {
        public static ActionMode landFarmMode = new ActionMode("LandFarm", typeof(FindEnemy), typeof(LandAttack), typeof(CollectItens), typeof(Heal));
        public static ActionMode flyToHealMode = new ActionMode("Heal", /*typeof(FlyAway),*/ typeof(IdleHeal));
    }
}
