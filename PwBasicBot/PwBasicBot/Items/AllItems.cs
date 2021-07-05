using PwBasicBot.Configs;
using PwBasicBot.Items.Base;

namespace PwBasicBot.Items
{
    public class AllItems
    {
        public static UsableItem hpPotion;
        public static UsableItem mpPotion;
        static AllItems()
        {
            Reset();
        }

        public static void Reset()
        {
            hpPotion = new UsableItem(ConfConstants.itemConfig.Items.Get("hpPot").CoolDown, ConfConstants.itemConfig.Items.Get("hpPot").Key);
            mpPotion = new UsableItem(ConfConstants.itemConfig.Items.Get("mpPot").CoolDown, ConfConstants.itemConfig.Items.Get("mpPot").Key);
        }
    }
}
