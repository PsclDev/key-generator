using System;
using System.Text;

namespace Generator
{
    public static class Pattern
    {
        public static readonly char[] charsetX = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static readonly char[] charsetZ = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0' };
        public static readonly char[] charsetY = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static readonly Random random = new Random();
        public static readonly char pattern_charX = 'X';
        public static readonly char pattern_charZ = 'Z';
        public static readonly char pattern_charY = 'Y';

        public static string Generate(string pattern)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in pattern)
            {
                if (c == pattern_charX)
                {
                    sb.Append(charsetX[random.Next(0, charsetX.Length)]);
                }
                if (c == pattern_charZ)
                {
                    sb.Append(charsetZ[random.Next(0, charsetZ.Length)]);
                }
                if (c == pattern_charY)
                {
                    sb.Append(charsetY[random.Next(0, charsetY.Length)]);
                }
            }
            return sb.ToString();
        }
    }
}
