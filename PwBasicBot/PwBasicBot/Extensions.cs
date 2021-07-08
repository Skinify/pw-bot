using System;

namespace PwBasicBot
{
    public static class Extensions
    {
        public static bool MatchArray(this string text, params string[] values)
        {
            text = text.ToLower().Replace(" ", "");
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

        public static bool NearMatchArray(this string text, params string[] values)
        {
            text = text.ToLower().Replace(" ", "");

            for (int count = 0; count < values.Length; count++)
            {
                string value = values[count].ToLower().Replace(" ", "");
                if(text.NearMatch(value) < 4)
                {
                    return true;
                }
            }

            return false;
        }


        //Levenshtein
        public static int NearMatch(this string value, string text)
        {
            int n = text.Length;
            int m = value.Length;
            int[,] d = new int[n + 1, m + 1];
            if (n == 0)
            {
                return m;
            }
            if (m == 0)
            {
                return n;
            }
            for (int i = 0; i <= n; d[i, 0] = i++)
                ;
            for (int j = 0; j <= m; d[0, j] = j++)
                ;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (value[j - 1] == text[i - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            return d[n, m];
        }

        public static bool IsNumber(this string text)
        {
            return int.TryParse(text, out _);
        }
    }
}
