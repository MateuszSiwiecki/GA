using System;
using System.Collections.Generic;
using System.Linq;

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

        public static Dictionary<double, Chromosome> FitPop(IEnumerable<Chromosome> listOfChromosomes)
            => listOfChromosomes.ToDictionary(chromosome => chromosome.Fitness());

        public static Dictionary<double, Chromosome> FixedFitPop(IEnumerable<Chromosome> listOfChromosomes)
        {
            var fitPop = FitPop(listOfChromosomes);
            var lowestKey = fitPop.Keys.Min();
            var newDic = fitPop.
                ToDictionary(chromosome => chromosome.Key + Math.Abs(lowestKey),
                    chromosome => chromosome.Value);
            return newDic;
        }
    }
}