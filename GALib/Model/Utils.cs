using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GALib
{
    public static class Utils
    {
        public static double RandomNumberDigits(int numberOfRandomDigitsAfterComa)
        {
            var sb = new StringBuilder();
            var random = new Random();
            sb.Append(random.Next(100));
            sb.Append(",");
            for (var i = 0; i < numberOfRandomDigitsAfterComa; i++) sb.Append(random.Next(9));
            return double.Parse(sb.ToString(), NumberStyles.Float);
        }

        public static Chromosome PickRandom(this List<Chromosome> list)
        {
            var toReturn = list[new Random().Next(list.Count)];
            list.Remove(toReturn);
            return toReturn;
        }
        public static long LongRandom(long max)
        {
            if (max >> 32 <= 0) return new Random().Next((int) max);
            var rand = new Random();
            long result = rand.Next((int)(max >> 32));
            result <<= 32;
            result |= rand.Next(int.MaxValue);
            return result;
        }
    }
}