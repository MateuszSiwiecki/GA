using System;
using System.Text;

namespace GA1
{
    public static class ChromosomeDefinition
    {
        public static readonly int GenesCount = 128;
        public static int PossibleLargestChromosome => GenesCount - 1;
        public static int ChromosomeLength => (int)Math.Log2(GenesCount) - 1;

        public static string BinaryGeneFix(string gene)
        {
            for (var i = 0; i < ChromosomeLength - gene.Length; i++) gene = $"0{gene}";
            return gene;
        }
    }
}