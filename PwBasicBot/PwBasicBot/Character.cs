namespace PwBasicBot
{
    public class Character
    {

        public string PlayerName { get; set; }

        public float Exp { get; set; }
        public int Level { get; set; }
        public int Cultivo { get; set; }

        public int MaxHp { get; set; }
        public int CurrentHp { get; set; }
        public int MaxMp { get; set; }
        public int CurrentMp { get; set; }
        public int MaxChi { get; set; }
        public int CurrentChi { get; set; }


        public float PosX { get; set; }
        public float PoxY { get; set; }
        public float PoxZ { get; set; }

        public float Gold { get; set; }
        
        public Character()
        {

        }
        public Character(int maxHp, int maxMp, int level)
        {
            MaxHp = maxHp;
            MaxMp = maxMp;
            Level = level;
        }
    }
}
