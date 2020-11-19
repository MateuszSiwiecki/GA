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
            var rand = new Random();
            long result = rand.Next((Int32)(0 >> 32), (Int32)(max >> 32));
            result = (result << 32);
            result = result | (long)rand.Next((Int32)0, (Int32)max);
            return result;
        }
    }
}