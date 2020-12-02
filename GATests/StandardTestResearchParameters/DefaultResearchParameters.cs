using System;
using GALib;

namespace GALib
{
    public static class DefaultResearchParameters
    {
        public static ResearchDefinitions GetDefaultResearchDefinitions(int pow = 8) =>
            new ResearchDefinitions(GetChromosomeDefinition(pow),
                GetFunctionDefinition(),
                10,
                0.5,
                0.5);
        public static ChromosomeDefinition GetChromosomeDefinition(int pow = 8) =>
            new ChromosomeDefinition(pow);
        public static Function GetFunctionDefinition() =>
            new Function(x => 0.2 * Math.Pow(x[0], 3) + 0.1 * Math.Pow(x[0], 2) - 8 * x[0],
                x => -(0.2 * Math.Pow(x[0], 3) + 0.1 * Math.Pow(x[0], 2) - 8 * x[0]),
                -7,
                7);

        public static Chromosome GetHigherChromosome(ResearchDefinitions rd)
        {
            var binGene = "";
            for (int i = 0; i < rd.chromosomeDefinition.ChromosomeLength; i++) binGene += '1';
            return new Chromosome(rd).SetGene(binGene);
        }
        public static Chromosome GetLowestChromosome(ResearchDefinitions rd) => new Chromosome(rd).SetGene("0");
    }
}