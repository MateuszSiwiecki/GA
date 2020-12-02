using System;

namespace GALib
{
    public class ResearchDefinitions
    {
        public ChromosomeDefinition cd;
        public ResearchDefinitions()
        { }

        public ResearchDefinitions(Func<double[], double> functionUnderStudy,
            Func<double[], double> fitFunction,
            double lowerBound,
            double upperBound,
            int startPop,
            double mutationChance,
            double crossChance,
            ChromosomeDefinition cd)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
            StartPopSize = startPop;
            MutationChance = mutationChance;
            CrossChance = crossChance;
            FunctionUnderStudy = functionUnderStudy;
            this.cd = cd;
            FitFunction = fitFunction;
        }
        public double LowerBound { get; private set; }
        public double UpperBound { get; private set; }
        public double MutationChance { get; private set; }
        public double CrossChance { get; private set; }
        public int StartPopSize { get; private set; }
        public Func<double[], double> FunctionUnderStudy;
        public Func<double[], double> FitFunction;
        public double ROfSeries => (UpperBound - LowerBound) / cd.GenesCount;
        public double GetElementOfNPosition(long nPosition) => LowerBound + ROfSeries * nPosition;
    }
}