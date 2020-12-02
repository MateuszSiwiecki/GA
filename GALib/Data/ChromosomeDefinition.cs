using System;
using System.Text;

namespace GALib
{
    public class ChromosomeDefinition
    {
        public ChromosomeDefinition(int power)
        {
            if (power < 0) power = 0;
            if (power > 62) power = 62;
            if (power == 0)
            {
                GenesCount = 1;
                return;
            }
            long output = 2;
            for (int i = 1; i < power; i++)
            {
                output *= 2;
            }

            GenesCount = output;
        }
        public void SetGenestCount(int count) => GenesCount = count;
        public long GenesCount;
        public long PossibleLargestChromosome => GenesCount - 1;
        public int ChromosomeLength => (int)Math.Log2(GenesCount);

        public string BinaryGeneFix(string gene)
        {
            var newGene = new string(gene);
            for (var i = 0; i < ChromosomeLength - gene.Length; i++) newGene = $"0{newGene}";
            return newGene;
        }
    }
}