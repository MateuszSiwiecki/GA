using System;
using System.Text;

namespace GALib
{
    public static class ChromosomeDefinition
    {
        public static readonly int GenesCount = 128;
        public static int PossibleLargestChromosome => GenesCount - 1;
        public static int ChromosomeLength => (int)Math.Log2(GenesCount);

        public static string BinaryGeneFix(string gene)
        {
            var newGene = new string(gene);
            for (var i = 0; i < ChromosomeLength - gene.Length; i++) newGene = $"0{newGene}";
            return newGene;
        }
    }
}