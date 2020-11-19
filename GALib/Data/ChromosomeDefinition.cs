using System;
using System.Text;

namespace GALib
{
    public class ChromosomeDefinition
    {
        public ChromosomeDefinition()
        {
            
        }

        public ChromosomeDefinition(int genesCount)
        {
            GenesCount = genesCount;
        }
        public void SetGenestCount(int count) => GenesCount = count;
        public int GenesCount;
        public int PossibleLargestChromosome => GenesCount - 1;
        public int ChromosomeLength => (int)Math.Log2(GenesCount);

        public string BinaryGeneFix(string gene)
        {
            var newGene = new string(gene);
            for (var i = 0; i < ChromosomeLength - gene.Length; i++) newGene = $"0{newGene}";
            return newGene;
        }
    }
}