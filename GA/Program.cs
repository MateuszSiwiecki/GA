using System;
using GALib;
using GALib.PostSelection;

namespace GA1
{
    class Program
    {
        public static void Main(string[] args)
        {
            ResearchDefinitions.SetResearch(-7, 7, 10);

            var startPop = ResearchModel.FixedFitPop(
                ResearchModel.NewRandomPopulation(
                ResearchDefinitions.StartPopSize));
            Console.WriteLine("\nStart pop:\n");
            Writers.WriteSortedByFitness(startPop);

            var preselectedPop = new RouletteWheel().DrawChromosomes(startPop);
            Console.WriteLine("\nPreselected:\n");
            Writers.WriteSortedByFitness(preselectedPop);

            var nextGenPop = ResearchModel.FixedFitPop(PostSelection.CreateNewPopulation(preselectedPop));
            Console.WriteLine("\nNextGenPop:\n");
            Writers.WriteSortedByFitness(nextGenPop);

        }
    }
}
