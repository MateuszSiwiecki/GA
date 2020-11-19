using System;

namespace GALib
{
    public class ResearchDefinitions
    {
        public ChromosomeDefinition cd;
        public ResearchDefinitions()
        { }

        public ResearchDefinitions(dynamic functionUnderStudy, dynamic fitFunction, double lowerBound, double upperBound, int startPop, ChromosomeDefinition cd)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
            StartPopSize = startPop;
            FunctionUnderStudy = functionUnderStudy;
            this.cd = cd;
            FitFunction = fitFunction;
        }
        public double LowerBound { get; private set; }
        public double UpperBound { get; private set; }
        public int StartPopSize { get; private set; }
        public dynamic FunctionUnderStudy;
        public dynamic FitFunction;
        public double ROfSeries => (UpperBound - LowerBound) / cd.GenesCount;
        public double GetElementOfNPosition(int nPosition) => LowerBound + ROfSeries * nPosition;
    }
}