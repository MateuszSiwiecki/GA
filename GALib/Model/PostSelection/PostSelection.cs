using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace GALib.PostSelection
{
    public class PostSelection
    {
        public static List<Chromosome> CreateNewPopulation(List<Chromosome> oldPop)
        {
            var output = new List<Chromosome>();
            bool even = oldPop.Count % 2 == 0;
            var cycles = even
                ? oldPop.Count
                : oldPop.Count - 2;
            for (var i = 0; i < cycles; i += 2) output.AddRange(MixChromosomes(oldPop.PickRandom(), oldPop.PickRandom()));
            if(!even) output.Add(oldPop.Last());
            return output;
        }

        public static List<Chromosome> MixChromosomes(Chromosome a, Chromosome b)
        {
            var sbA = new StringBuilder();
            var sbB = new StringBuilder();
            var aBinaryGene = a.GeneInBinary();
            var bBinaryGene = b.GeneInBinary();
            var rnd = new Random();
            for (int i = 0; i < aBinaryGene.Length; i++)
            {
                if (rnd.Next(2) == 1)
                {
                    sbA.Append(aBinaryGene[i]);
                    sbB.Append(bBinaryGene[i]);
                }
                else
                {
                    sbA.Append(bBinaryGene[i]);
                    sbB.Append(aBinaryGene[i]);
                }
            }

            return new List<Chromosome>
            {
                new Chromosome().SetGene(sbA.ToString()), new Chromosome().SetGene(sbB.ToString())
            };
        }
    }
}