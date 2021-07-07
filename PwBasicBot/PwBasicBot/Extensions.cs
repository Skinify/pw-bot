namespace PwBasicBot
{
    public static class Extensions
    {
        public static bool MatchArray(this string text, params string[] values)
        {
            text = text.ToLower();
            for(int count = 0; count < values.Length; count++)
            {
                string value = values[count].ToLower().Replace(" ","");
                if (text.Contains(value))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsNumber(this string text)
        {
            return int.TryParse(text, out _);
        }
    }
}
