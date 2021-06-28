namespace PwBasicBot.Offsets.Base
{
    public class Offset
    {
        protected int pointer = 0;
        protected int[] offsets;

        public int Pointer { get => pointer; }
        public int[] Offsets { get =>  offsets; }

        public Offset(int pointer, int[] offsets)
        {
            this.pointer = pointer;
            this.offsets = offsets;
        }
    }
}
