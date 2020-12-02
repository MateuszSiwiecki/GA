using System.Collections.Generic;
using System.Linq;

namespace GALib
{
    public abstract class Selection
    {
        /// <summary>
        /// Draw random number from 0 to 100, then compare with probability table.
        /// </summary>
        /// <param name="listOfChromosomes"></param>
        /// <param name="probabilityTable">The probability of individual chromosome</param>
        /// <returns></returns>
        protected virtual Chromosome DrawChromosome(List<Chromosome> listOfChromosomes, double[] probabilityTable)
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

        protected double[] CountProbabilityByNonNegativeFitness(List<Chromosome> listOfChromosomes)
        {
            var sum = listOfChromosomes.Sum(chromosome => chromosome.Fitness);
            return listOfChromosomes.Select(x => x.Fitness * 100 / sum).ToArray();
        }

        public abstract List<Chromosome> DrawChromosomes(List<Chromosome> listOfChromosomes);
    }
}