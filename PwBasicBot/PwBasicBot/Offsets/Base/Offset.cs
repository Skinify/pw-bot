namespace PwBasicBot.Offsets.Base
{
    public class Offset
    {
        protected int pointer = 0;
        protected int[] offsets;
        protected int tempAddress;

        public int Pointer { get => pointer; }
        public int[] Offsets { get =>  offsets; }
        public int TempAddress { get => tempAddress; }


        public Offset(int pointer, int[] offsets, int tempAddress = 0)
        {
            this.pointer = pointer;
            this.offsets = offsets;
            this.tempAddress = tempAddress;
        }
    }
}
