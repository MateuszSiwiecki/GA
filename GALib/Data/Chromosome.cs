using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace GALib
{
    public class Chromosome : IComparable<Chromosome>
    {
        public readonly ResearchDefinitions rd;
        public Chromosome(ResearchDefinitions rd)
        {
            this.rd = rd;
        }

        public Chromosome(Chromosome oldChromosome)
        {
            this.rd = oldChromosome.rd;
            this._gene = oldChromosome._gene;
            this.Fitness = oldChromosome.Fitness;
            this.AbsFitness = oldChromosome.AbsFitness;
        }
        public static List<Chromosome> NewRandomPopulation(ResearchDefinitions rd, int chromosomeCount)
        {
            var list = new List<Chromosome>();
            for (var i = 0; i < chromosomeCount; i++) list.Add(Chromosome.NewRandomChromosome(rd));
            return list;
        }

        public static Chromosome NewRandomChromosome(ResearchDefinitions rd)
        => new Chromosome(rd)
        {
            Gene = Utils.LongRandom(rd.cd.GenesCount)
        };
        private long _gene;

        public long Gene
        {
            get
            {
                if (_gene < 0) return 0; //check for any incorrect
                return _gene >= rd.cd.PossibleLargestChromosome
                    ? rd.cd.PossibleLargestChromosome
                    : _gene;
            }
            set => _gene = value;
        }

        public double Fitness;
        public double AbsFitness;

        public double GeneInDecimal() => rd.GetElementOfNPosition(Gene);
        public string GeneInBinary() => rd.cd.BinaryGeneFix(Convert.ToString(Gene, 2));

        public Chromosome SetGene(string geneInBinary)
        {
            _gene = Convert.ToInt64(geneInBinary, 2);
            return this;
        }
        public double CalculateFitness() => rd.FitFunction(GeneInDecimal());
        public void SetFitness() => Fitness = AbsFitness = CalculateFitness();
        public int CompareTo(Chromosome other) => (int)(AbsFitness - other.AbsFitness);
    }
}