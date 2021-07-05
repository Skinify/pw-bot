using PwBasicBot.Offsets.Base;

namespace PwBasicBot.Offsets
{
    public class AllOffsets
    {
        public static Offset exp, level, cultivo, currentHp, maxHp, currentMp, maxMp, currentChi, maxChi, gold, isTargeting, isTargetingNpc, isFlying, name;
        static AllOffsets()
        {
            Reset();
        }
        public static void Reset()
        {
            exp = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4B0 },
                Configs.ConfConstants.tmpAddressConfig.Addresses.Get("exp").Address);

            level = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4A0 },
                Configs.ConfConstants.tmpAddressConfig.Addresses.Get("level").Address);

            cultivo = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4A4 },
                Configs.ConfConstants.tmpAddressConfig.Addresses.Get("cultivo").Address);

            currentHp = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4A8 },
                Configs.ConfConstants.tmpAddressConfig.Addresses.Get("currentHp").Address);
            maxHp = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4F4 },
                Configs.ConfConstants.tmpAddressConfig.Addresses.Get("maxHp").Address);

            currentMp = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4AC },
                Configs.ConfConstants.tmpAddressConfig.Addresses.Get("currentMp").Address);
            maxMp = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4F8 },
                Configs.ConfConstants.tmpAddressConfig.Addresses.Get("maxMp").Address);
            currentChi = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4BC },
                Configs.ConfConstants.tmpAddressConfig.Addresses.Get("currentChi").Address);

            maxChi = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x574 },
                Configs.ConfConstants.tmpAddressConfig.Addresses.Get("maxChi").Address);

            gold = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x578 },
                Configs.ConfConstants.tmpAddressConfig.Addresses.Get("gold").Address);

            isTargeting = new Offset(3058812, new int[] { 0x850, 0x4, 0x84, 0x4, 0x4, 0x4, 0x3c },
                Configs.ConfConstants.tmpAddressConfig.Addresses.Get("isTargeting").Address);

            isTargetingNpc = new Offset(8896520, new int[] { 0x13c, 0x418, 0x1c8, 0xa2c, 0x8, 0xc18, 0x90 },
                Configs.ConfConstants.tmpAddressConfig.Addresses.Get("isTargetingNpc").Address);

            isFlying = new Offset(9068672, new int[] { 0x84, 0xf04, 0x2a4, 0x334, 0x4c, 0x2c, 0x3c },
                Configs.ConfConstants.tmpAddressConfig.Addresses.Get("isFlying").Address);

            name = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x6B0 },
                Configs.ConfConstants.tmpAddressConfig.Addresses.Get("name").Address);
        }

        /*
        public static Offset exp = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4B0 },
            Configs.ConfConstants.tmpAddressConfig.Addresses.Get("exp").Address);

        public static Offset level = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4A0 },
            Configs.ConfConstants.tmpAddressConfig.Addresses.Get("level").Address);

        public static Offset cultivo = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4A4 },
            Configs.ConfConstants.tmpAddressConfig.Addresses.Get("cultivo").Address);

        public static Offset currentHp = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4A8 },
            Configs.ConfConstants.tmpAddressConfig.Addresses.Get("currentHp").Address);
        public static Offset maxHp = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4F4 },
            Configs.ConfConstants.tmpAddressConfig.Addresses.Get("maxHp").Address);

        public static Offset currentMp = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4AC },
            Configs.ConfConstants.tmpAddressConfig.Addresses.Get("currentMp").Address);
        public static Offset maxMp = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4F8 },
            Configs.ConfConstants.tmpAddressConfig.Addresses.Get("maxMp").Address);
        public static Offset currentChi = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x4BC },
            Configs.ConfConstants.tmpAddressConfig.Addresses.Get("currentChi").Address);

        public static Offset maxChi = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x574 },
            Configs.ConfConstants.tmpAddressConfig.Addresses.Get("maxChi").Address);

        public static Offset gold = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x578 },
            Configs.ConfConstants.tmpAddressConfig.Addresses.Get("gold").Address);

        public static Offset isTargeting = new Offset(3058812, new int[] { 0x850, 0x4, 0x84, 0x4, 0x4, 0x4, 0x3c },
            Configs.ConfConstants.tmpAddressConfig.Addresses.Get("isTargeting").Address);
        public static Offset isTargetingNpc = new Offset(8896520, new int[] { 0x13c, 0x418, 0x1c8, 0xa2c, 0x8, 0xc18, 0x90 },
            Configs.ConfConstants.tmpAddressConfig.Addresses.Get("isTargetingNpc").Address);

        public static Offset isFlying = new Offset(9068672, new int[] { 0x84, 0xf04, 0x2a4, 0x334, 0x4c, 0x2c, 0x3c },
            Configs.ConfConstants.tmpAddressConfig.Addresses.Get("isFlying").Address);

        public static Offset name = new Offset(2848492, new int[] { 0, 0, 0xb4, 0x48, 0x2c, 0xa30, 0x6B0 },
            Configs.ConfConstants.tmpAddressConfig.Addresses.Get("name").Address);
        */
    }
}
