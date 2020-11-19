using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using GALib;
using GALib.Fitness;
using GALib.PostSelection;

namespace GA1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var iterations = 100;
            var functionUnderStudy = new Func<double, double>(x => 0.2 * Math.Pow(x, 3) + 0.1 * Math.Pow(x, 2) - 8 * x);
            var fitFunction = new Func<double, double>(x => -(0.2 * Math.Pow(x, 3) + 0.1 * Math.Pow(x, 2) - 8 * x));
            var cd = new ChromosomeDefinition(10);
            var rd = new ResearchDefinitions(functionUnderStudy, fitFunction, - 7, 7, 100, cd);


            var startPop = Fitness.FixedFitPop(
                Chromosome.NewRandomPopulation(
                    rd,
                    rd.StartPopSize));
            Console.WriteLine("\nStart pop:\n");
            Writers.WriteSortedByFitness(startPop);

            var preselectedPop = new RouletteWheel().DrawChromosomes(startPop);
            Console.WriteLine("\nPreselected:\n");
            Writers.WriteSortedByFitness(preselectedPop);

            var nextGenPop = Fitness.FixedFitPop(PostSelection.CreateNewPopulation(preselectedPop));
            var bestChromosome = new BestChromosome()
            {
                bestChromosome = nextGenPop.Max(x => x),
                generation = 1
            };

            for (int i = 1; i < iterations; i++)
            {
                nextGenPop = Fitness.FixedFitPop(PostSelection.CreateNewPopulation(nextGenPop));
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
