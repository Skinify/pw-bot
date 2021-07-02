using PwBasicBot.Configs;

namespace PwBasicBot.Enuns
{
    public class GameSlotsEnum
    {
        public static readonly int BASIC_ATTACK = ConfConstants.keyBindingConfig.Bindings.Get("basicAttack").Key;
        public static readonly int ZEN_HEAL = ConfConstants.keyBindingConfig.Bindings.Get("zenHeal").Key;
        public static readonly int GRAB_ITEMS = ConfConstants.keyBindingConfig.Bindings.Get("grabItems").Key;
        public static readonly int CITY_PORTAL = ConfConstants.keyBindingConfig.Bindings.Get("cityPortal").Key;
        public static readonly int FLY = ConfConstants.keyBindingConfig.Bindings.Get("fly").Key;
    }
}
