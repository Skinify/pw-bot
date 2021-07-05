using PwBasicBot.Configs;

namespace PwBasicBot.Enuns
{
    public class GameSlotsEnum
    {
        public static int BASIC_ATTACK;
        public static int ZEN_HEAL;
        public static int GRAB_ITEMS;
        public static int CITY_PORTAL;
        public static int FLY;

        static GameSlotsEnum()
        {
            Reset();
        }

        public static void Reset()
        {
            BASIC_ATTACK = ConfConstants.keyBindingConfig.Bindings.Get("basicAttack").Key;
            ZEN_HEAL = ConfConstants.keyBindingConfig.Bindings.Get("zenHeal").Key;
            GRAB_ITEMS = ConfConstants.keyBindingConfig.Bindings.Get("grabItems").Key;
            CITY_PORTAL = ConfConstants.keyBindingConfig.Bindings.Get("cityPortal").Key;
            FLY = ConfConstants.keyBindingConfig.Bindings.Get("fly").Key;
        }
    }
}
