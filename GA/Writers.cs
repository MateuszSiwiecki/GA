using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using GALib;

namespace GA1
{
    public static class Writers
    {
        public static void WriteSortedByFitness(IEnumerable<Chromosome> list) => Write(list.OrderBy(x => x.Fitness));
        public static void WriteSortedByGene(IEnumerable<Chromosome> list) => Write(list.OrderBy(x => x.Gene));

        public static void WriteBestChromosome(BestChromosome chromosome)
        {
            Console.WriteLine($"Best chromosome from generation {chromosome.generation}: ");
            WriteChromosome(chromosome.bestChromosome);
        }
        public static void WriteSeparator() => Console.WriteLine("------------------------------");

        private static void Write(IEnumerable<Chromosome> list)
        {
            foreach (var chromosome in list) WriteChromosome(chromosome);
            WriteSeparator();
        }
        private static void WriteChromosome(Chromosome chromosome)
        => Console.WriteLine($"{chromosome.Gene} | {chromosome.GeneInBinary()} | " +
                             $"{chromosome.GeneInDecimal()} | {chromosome.Fitness} | {chromosome.AbsFitness}");
    }
}