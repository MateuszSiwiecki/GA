using System;
using GALib;

namespace GA1
{
    class Program
    {
        public static void Main(string[] args)
        {
            ResearchDefinitions.SetResearch(-7, -7, 10);
            var startPop = ResearchModel.NewRandomPopulation(ResearchDefinitions.StartPopSize);
            startPop.Sort();
            ResearchModel.FixedFitPop(startPop);
            Console.WriteLine("Start pop:");
            foreach (var chromosome in startPop)
            {
                Console.WriteLine($"{chromosome.Gene} | {chromosome.GeneInBinary()} | {chromosome.GeneInDecimal()} | {chromosome.Fitness}");
            }
            var nextPop = ResearchModel.RouletteWheel(startPop);
            nextPop.Sort();

            Console.WriteLine("Next pop:");
            foreach (var chromosome in nextPop)
            {
                Console.WriteLine($"{chromosome.Gene} | {chromosome.GeneInBinary()} | {chromosome.GeneInDecimal()} | {chromosome.Fitness}");
            }

        }
    }
}
