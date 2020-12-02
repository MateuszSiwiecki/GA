using System.Collections.Generic;

namespace GALib
{
    public class RouletteWheel : Selection
    {
        public override List<Chromosome> DrawChromosomes(List<Chromosome> listOfChromosomes)
        {
            var probabilityTable = CountProbabilityByNonNegativeFitness(listOfChromosomes);

            var preselectionChromosomes = new List<Chromosome>();
            for (var i = 0; i < listOfChromosomes.Count; i++)
                preselectionChromosomes.Add(DrawChromosome(listOfChromosomes, probabilityTable));

            return preselectionChromosomes;
        }
    }
}