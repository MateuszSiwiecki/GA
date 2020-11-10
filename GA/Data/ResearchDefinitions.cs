using System;

namespace GA1
{
    public static class ResearchDefinitions
    {
        public static double LowerBound = -7;
        public static double UpperBound = -7;
        public static double FunctionUnderStudy(double x)
            => (0.2 * Math.Pow(x, 3)) + (0.1 * Math.Pow(x, 2)) - (8 * x);
        public static double FitFunction(double x) => -FunctionUnderStudy(x);
        public static double ROfSeries => (UpperBound - LowerBound) / ChromosomeDefinition.GenesCount;
        public static double GetElementOfNPosition(int nPosition) => LowerBound + ROfSeries * nPosition;
    }
}