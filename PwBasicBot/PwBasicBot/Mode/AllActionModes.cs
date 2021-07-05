using PwBasicBot.Actions;
using PwBasicBot.Mode.ActionsModes;

namespace PwBasicBot.Mode
{
    public class AllActionModes
    {
        public static ActionMode landFarmMode = new ActionMode("LandFarm", typeof(FindEnemy), typeof(LandAttack), typeof(CollectItens));
        public static ActionMode flyToHealMode = new ActionMode("Heal", /*typeof(FlyAway),*/ typeof(IdleHeal));
        public static ActionMode baseRecallMode = new ActionMode("Recall", /*typeof(FlyAway),*/ typeof(Recall));
        public static ActionMode farmMinerals = new ActionMode("FarmMinerals", typeof(CollectMineral));
    }
}
