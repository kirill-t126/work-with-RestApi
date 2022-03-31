using System;
using System.Linq;

namespace RestApiExample.Utils
{
    internal static class RandomGenerator
    {
        public static string GenerateRandomText(int stringLength)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";
            return new string(Enumerable.Repeat(chars, stringLength).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}