using System;

namespace GALib
{
    public static class ResearchDefinitions
    {
        public static void SetResearch(double lowerBound, double upperBound, int startPop, int genesCount)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
            StartPopSize = startPop;
            ChromosomeDefinition.SetGenestCount(genesCount);
        }
        public static double LowerBound { get; private set; }
        public static double UpperBound { get; private set; }
        public static int StartPopSize { get; private set; }
        public static double FunctionUnderStudy(double x)
            => (0.2 * Math.Pow(x, 3)) + (0.1 * Math.Pow(x, 2)) - (8 * x);
        public static double FitFunction(double x) => -FunctionUnderStudy(x);
        public static double ROfSeries => (UpperBound - LowerBound) / ChromosomeDefinition.GenesCount;
        public static double GetElementOfNPosition(int nPosition) => LowerBound + ROfSeries * nPosition;
    }
}