using System;

namespace GA1
{
    public class Chromosome
    {
        private int _gene;

        public int Gene
        {
            get
            {
                if (_gene < 0) return 0; //check for any incorrect
                return _gene >= ChromosomeDefinition.PossibleLargestChromosome
                    ? ChromosomeDefinition.PossibleLargestChromosome
                    : _gene;
            }
            set => _gene = value;
        }

        public double GeneInDecimal() => ResearchDefinitions.GetElementOfNPosition(Gene);
        public string GeneInBinary() => ChromosomeDefinition.BinaryGeneFix(Convert.ToString(Gene, 2));
}
}