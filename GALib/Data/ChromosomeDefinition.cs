using System;
using System.Text;

namespace GALib
{
    public class ChromosomeDefinition
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="power">Max = 30, min = 1</param>
        public ChromosomeDefinition(int power)
        {
            power = power <= 30 ? power : 30;
            power = power > 0 ? power : 1;
            GenesCount = (long)Math.Pow(2, power);
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