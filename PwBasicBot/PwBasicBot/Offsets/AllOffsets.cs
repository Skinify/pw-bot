using PwBasicBot.Offsets.Base;

namespace PwBasicBot.Offsets
{
    public class AllOffsets
    {
        public static Offset exp = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4B0 },
            Configs.ConfConstants.tempAddressConfig.Addresses.Get("exp").Address);

        public static Offset level = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4A0 },
            Configs.ConfConstants.tempAddressConfig.Addresses.Get("exp").Address);

        public static Offset cultivo = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4A4 },
            Configs.ConfConstants.tempAddressConfig.Addresses.Get("exp").Address);

        public static Offset currentHp = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4A8 },
            Configs.ConfConstants.tempAddressConfig.Addresses.Get("exp").Address);
        public static Offset maxHp = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4F4 },
            Configs.ConfConstants.tempAddressConfig.Addresses.Get("exp").Address);

        public static Offset currentMp = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4AC },
            Configs.ConfConstants.tempAddressConfig.Addresses.Get("exp").Address);
        public static Offset maxMp = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4F8 },
            Configs.ConfConstants.tempAddressConfig.Addresses.Get("exp").Address);
        public static Offset currentChi = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4BC },
            Configs.ConfConstants.tempAddressConfig.Addresses.Get("exp").Address);

        public static Offset maxChi = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x574 },
            Configs.ConfConstants.tempAddressConfig.Addresses.Get("exp").Address);

        public static Offset gold = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x578 },
            Configs.ConfConstants.tempAddressConfig.Addresses.Get("exp").Address);

        public static Offset isTargeting = new Offset(3058812, new int[] { 0x850, 0x4, 0x84, 0x4, 0x4, 0x4, 0x3c },
            Configs.ConfConstants.tempAddressConfig.Addresses.Get("exp").Address);
        public static Offset isTargetingNpc = new Offset(8896520, new int[] { 0x13c, 0x418, 0x1c8, 0xa2c, 0x8, 0xc18, 0x90 },
            Configs.ConfConstants.tempAddressConfig.Addresses.Get("exp").Address);

        public static Offset isFlying = new Offset(9068672, new int[] { 0x84, 0xf04, 0x2a4, 0x334, 0x4c, 0x2c, 0x3c },
            Configs.ConfConstants.tempAddressConfig.Addresses.Get("exp").Address);

        public static Offset name = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x6B0 },
            Configs.ConfConstants.tempAddressConfig.Addresses.Get("exp").Address);
    }
}
