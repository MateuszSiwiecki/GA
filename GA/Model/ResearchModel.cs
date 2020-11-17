using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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

        private static List<Chromosome> FitPop(List<Chromosome> listOfChromosomes)
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

        public static List<Chromosome> RouletteWheel(List<Chromosome> listOfChromosomes)
        {
            var sum = listOfChromosomes.Sum(chromosome => chromosome.Fitness);
            var probabilityTable = listOfChromosomes.Select(x => x.Fitness * 100 / sum);
            var preselectionChromosomes = new List<Chromosome>();
            for (int i = 0; i < listOfChromosomes.Count; i++)
            {
                var random = Utils.RandomNumberDigits(3);
            }

            return preselectionChromosomes;
        }
    }
}