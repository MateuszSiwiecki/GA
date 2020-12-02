using System;

namespace GALib
{
    public class ResearchDefinitions
    {
        public ChromosomeDefinition chromosomeDefinition;
        public Function function;
        public ResearchDefinitions()
        { }

        public ResearchDefinitions(ChromosomeDefinition chromosomeDefinition,
            Function function,
            int population,
            double mutationChance,
            double crossChance)
        {
            this.chromosomeDefinition = chromosomeDefinition;
            this.function = function;
            Population = population;
            MutationChance = mutationChance;
            CrossChance = crossChance;
        }

        public double LowerBound => function.LowerBound;
        public double UpperBound => function.UpperBound;
        public Func<double[], double> FunctionUnderStudy => function.FunctionUnderStudy;
        public Func<double[], double> FitFunction => function.FitFunction;
        public double MutationChance { get; private set; }
        public double CrossChance { get; private set; }
        public int Population { get; private set; }
        public double ROfSeries => (UpperBound - LowerBound) / chromosomeDefinition.GenesCount;
        public double GetElementOfNPosition(long nPosition) => LowerBound + ROfSeries * nPosition;
    }
}