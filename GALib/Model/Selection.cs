using System.Collections.Generic;
using System.Linq;

namespace GALib
{
    public static class Selection
    {
        public static List<Chromosome> RouletteWheel(List<Chromosome> listOfChromosomes)
        {
            var probabilityTable = CountProbabilityByNonNegativeFitness(listOfChromosomes);

            var preselectionChromosomes = new List<Chromosome>();
            for (var i = 0; i < listOfChromosomes.Count; i++)
                preselectionChromosomes.Add(DrawChromosome(listOfChromosomes, probabilityTable));

            return preselectionChromosomes;
        }

        private static Chromosome DrawChromosome(List<Chromosome> listOfChromosomes, double[] probabilityTable)
        {
            var random = Utils.RandomNumberDigits(3);
            var index = -1;
            double lowerProb = 0, upperProb = 0;
            for (int j = 0; j < probabilityTable.Length; j++)
            {
                upperProb += probabilityTable[j];
                if (!(lowerProb < random) || !(random < upperProb))
                {
                    lowerProb = upperProb;
                    continue;
                }
                index = j;
                break;
            }

            return new Chromosome(listOfChromosomes[index]);
        }

        private static double[] CountProbabilityByNonNegativeFitness(List<Chromosome> listOfChromosomes)
        {
            var sum = listOfChromosomes.Sum(chromosome => chromosome.Fitness);
            return listOfChromosomes.Select(x => x.Fitness * 100 / sum).ToArray();
        }
    }
}