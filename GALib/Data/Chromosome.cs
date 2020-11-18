using System;

namespace GALib
{
    public class Chromosome : IComparable<Chromosome>
    {
        public Chromosome()
        {
            
        }

        public Chromosome(Chromosome oldChromosome)
        {
            this._gene = oldChromosome._gene;
            this.Fitness = oldChromosome.Fitness;
        }

        public static Chromosome NewRandomChromosome()
        => new Chromosome
        {
            Gene = new Random().Next(ChromosomeDefinition.PossibleLargestChromosome)
        };
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

        public double Fitness;

        public double GeneInDecimal() => ResearchDefinitions.GetElementOfNPosition(Gene);
        public string GeneInBinary() => ChromosomeDefinition.BinaryGeneFix(Convert.ToString(Gene, 2));

        public Chromosome SetGene(string geneInBinary)
        {
            _gene = Convert.ToInt32(geneInBinary, 2);
            return this;
        }
        public double CalculateFitness() => ResearchDefinitions.FitFunction(GeneInDecimal());
        public void SetFitness() => Fitness = CalculateFitness();
        public int CompareTo(Chromosome other) => _gene - other._gene;
    }
}