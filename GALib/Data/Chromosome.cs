using System;
using System.Reflection.PortableExecutable;

namespace GALib
{
    public class Chromosome : IComparable<Chromosome>
    {
        public readonly ResearchDefinitions rd;
        public readonly ChromosomeDefinition cd;
        public Chromosome(ResearchDefinitions rd, ChromosomeDefinition cd)
        {
            this.rd = rd;
            this.cd = cd;
        }

        public Chromosome(Chromosome oldChromosome)
        {
            this.rd = oldChromosome.rd;
            this.cd = oldChromosome.cd;
            this._gene = oldChromosome._gene;
            this.Fitness = oldChromosome.Fitness;
            this.AbsFitness = oldChromosome.AbsFitness;
        }

        public static Chromosome NewRandomChromosome(ResearchDefinitions rd, ChromosomeDefinition cd)
        => new Chromosome(rd, cd)
        {
            Gene = new Random().Next(cd.GenesCount)
        };
        private int _gene;

        public int Gene
        {
            get
            {
                if (_gene < 0) return 0; //check for any incorrect
                return _gene >= cd.PossibleLargestChromosome
                    ? cd.PossibleLargestChromosome
                    : _gene;
            }
            set => _gene = value;
        }

        public double Fitness;
        public double AbsFitness;

        public double GeneInDecimal() => rd.GetElementOfNPosition(Gene);
        public string GeneInBinary() => cd.BinaryGeneFix(Convert.ToString(Gene, 2));

        public Chromosome SetGene(string geneInBinary)
        {
            _gene = Convert.ToInt32(geneInBinary, 2);
            return this;
        }
        public double CalculateFitness() => rd.FitFunction(GeneInDecimal());
        public void SetFitness() => Fitness = AbsFitness = CalculateFitness();
        public int CompareTo(Chromosome other) => (int)(AbsFitness - other.AbsFitness);
    }
}