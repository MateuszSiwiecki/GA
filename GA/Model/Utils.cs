using System;
using System.Globalization;
using System.Text;

namespace GA1
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
    }
}