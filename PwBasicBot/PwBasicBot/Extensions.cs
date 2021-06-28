namespace PwBasicBot
{
    public static class Extensions
    {
        public static T[] ConcatSingle<T>(this T[] arrayItem, T item)
        {
            T[] array = new T[arrayItem.Length + 1];
            for(int count = 0; count < arrayItem.Length; count++)
            {
                array[count] = arrayItem[count];
            }
            array[arrayItem.Length] = item;
            return array;
        }
    }
}
