using System.Text;

namespace Generator
{
    public static class Key
    {
        public static string Generate(string pattern)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in pattern)
            {
                if (c == Pattern.pattern_charX)
                {
                    sb.Append(Pattern.charsetX[Pattern.random.Next(0, Pattern.charsetX.Length)]);
                }
                else if (c == Pattern.pattern_charZ)
                {
                    sb.Append(Pattern.charsetZ[Pattern.random.Next(0, Pattern.charsetZ.Length)]);
                }
                else if (c == Pattern.pattern_charY)
                {
                    sb.Append(Pattern.charsetY[Pattern.random.Next(0, Pattern.charsetY.Length)]);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
