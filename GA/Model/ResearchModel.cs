using System.Collections.Generic;

namespace GA1
{
    public static class ResearchModel
    {
        public static List<Chromosome> NewRandomPopulation(int chromosomeCount)
        {
            var list = new List<Chromosome>();
            for (var i = 0; i < chromosomeCount; i++) list.Add(Chromosome.NewRandomChromosome());
            return list;
        }
    }
}