using System;

namespace GALib
{
    public class BestChromosome : IComparable<Chromosome>
    {
        public int generation;
        public Chromosome bestChromosome;
        public int CompareTo(Chromosome other) => (int)(bestChromosome.AbsFitness - other.AbsFitness);
    }
}