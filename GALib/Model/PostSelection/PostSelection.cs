using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace GALib.PostSelection
{
    public class PostSelection
    {
        public static List<Chromosome> CreateNewPopulation(List<Chromosome> oldPop, double mixChance, double mutationChance)
        {
            var output = new List<Chromosome>();
            bool even = oldPop.Count % 2 == 0;
            var cycles = even
                ? oldPop.Count
                : oldPop.Count - 2;
            for (var i = 0; i < cycles; i += 2) output.AddRange(MixChromosomes(oldPop.PickRandom(), oldPop.PickRandom(), mixChance));
            if (!even) output.Add(oldPop.Last());
            for (var i = 0; i < output.Count; i++) output[i] = MutateChromosome(output[i], mutationChance);
            return output;
        }

        public static List<Chromosome> MixChromosomes(Chromosome a, Chromosome b, double mixChance)
        {
            if (mixChance < new Random().NextDouble())
            {
                return new List<Chromosome>
                {
                    a, b
                };
            }
            var sbA = new StringBuilder();
            var sbB = new StringBuilder();
            var aBinaryGene = a.GeneInBinary();
            var bBinaryGene = b.GeneInBinary();

            var pointOfCrossing = new Random().Next(1, aBinaryGene.Length);

            sbA.Append(aBinaryGene.Substring(0, pointOfCrossing));
            sbA.Append(bBinaryGene.Substring(pointOfCrossing));

            sbB.Append(bBinaryGene.Substring(0, pointOfCrossing));
            sbB.Append(aBinaryGene.Substring(pointOfCrossing));

            return new List<Chromosome>
            {
                new Chromosome(a.rd).SetGene(sbA.ToString()), new Chromosome(a.rd).SetGene(sbB.ToString())
            };
        }

        public static Chromosome MutateChromosome(Chromosome chromosome, double mutationChance)
        {
            var rnd = new Random();
            if (!(mutationChance > rnd.NextDouble())) return chromosome;

            var geneInBin = new string(chromosome.GeneInBinary());
            var index = rnd.Next(geneInBin.Length - 1);
            var byteToInsert = int.Parse(geneInBin[index].ToString());
            byteToInsert = Math.Abs(byteToInsert - 1);

            geneInBin = geneInBin.Replace(index, byteToInsert.ToString());

            chromosome.SetGene(geneInBin);

            return chromosome;
        }
    }
}