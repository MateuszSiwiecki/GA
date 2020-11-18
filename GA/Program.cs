using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using GALib;
using GALib.PostSelection;

namespace GA1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var iterations = 100;

            ResearchDefinitions.SetResearch(-7, 7, 100, 2048);


            var startPop = ResearchModel.FixedFitPop(
                ResearchModel.NewRandomPopulation(
                ResearchDefinitions.StartPopSize));
            Console.WriteLine("\nStart pop:\n");
            Writers.WriteSortedByFitness(startPop);

            var preselectedPop = new RouletteWheel().DrawChromosomes(startPop);
            Console.WriteLine("\nPreselected:\n");
            Writers.WriteSortedByFitness(preselectedPop);

            var nextGenPop = ResearchModel.FixedFitPop(PostSelection.CreateNewPopulation(preselectedPop));
            var bestChromosome = new BestChromosome()
            {
                bestChromosome = nextGenPop.Max(x => x),
                generation = 1
            };

            for (int i = 1; i < iterations; i++)
            {
                nextGenPop = ResearchModel.FixedFitPop(PostSelection.CreateNewPopulation(nextGenPop));
                if (bestChromosome.bestChromosome.AbsFitness < nextGenPop.Max(x => x.AbsFitness))
                {
                    bestChromosome.bestChromosome = nextGenPop.FirstOrDefault(x => x.AbsFitness == nextGenPop.Max(y => y.AbsFitness));
                    bestChromosome.generation = i + 1;
                }

                Console.WriteLine($"Generation {i + 1}");
                Console.WriteLine("NextGenPop:\n");
                Writers.WriteSortedByFitness(nextGenPop);
            }
            Writers.WriteBestChromosome(bestChromosome);
        }
    }
}
