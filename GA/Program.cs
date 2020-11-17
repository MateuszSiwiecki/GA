using System;

namespace GA1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var startPop = ResearchModel.NewRandomPopulation(ResearchDefinitions.StartPop);
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
