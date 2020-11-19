using System;
using System.Collections.Generic;
using System.Linq;

namespace GALib.Fitness
{
    public static class Fitness
    {
        public static List<Chromosome> FitPop(List<Chromosome> listOfChromosomes)
        {
            foreach (var chromosome in listOfChromosomes) chromosome.SetFitness();
            return listOfChromosomes;
        }

        public static List<Chromosome> FixedFitPop(List<Chromosome> listOfChromosomes, out double lowestKey)
        {
            listOfChromosomes = FitPop(listOfChromosomes);
            lowestKey = Math.Abs(listOfChromosomes.Min(x => x.Fitness));
            var tempLowestKey = lowestKey;
            foreach (var chromosome in listOfChromosomes) chromosome.Fitness += tempLowestKey;
            return listOfChromosomes;
        }

        public static List<Chromosome> FixedFitPop(List<Chromosome> listOfChromosomes)
            => FixedFitPop(listOfChromosomes, out _);
    }
}