﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using GALib;
using GALib.Fitness;
using GALib.PostSelection;
using System.Windows;

namespace GA1
{
    class Program
    {


        /*
            var functionUnderStudy = new Func<double, double>(x => 0.2 * Math.Pow(x, 3) + 0.1 * Math.Pow(x, 2) - 8 * x);
            var fitFunction = new Func<double, double>(x => -(0.2 * Math.Pow(x, 3) + 0.1 * Math.Pow(x, 2) - 8 * x));
           
            var functionUnderStudy = new Func<double, double>(x => x - Math.Pow(x, 2) + Math.Pow(x, 3));
            var fitFunction = functionUnderStudy;

            var functionUnderStudy = new Func<double, double>(Math.Sin);
            var fitFunction = functionUnderStudy;
         */
        public static void Main(string[] args)
        {
            var iterations = 1000;
            var functionUnderStudy = new Func<double[], double>(x => 0.2 * Math.Pow(x[0], 3) + 0.1 * Math.Pow(x[0], 2) - 8 * x[0]);
            var fitFunction = new Func<double[], double>(x => Math.Sin(x[0]));
            var cd = new ChromosomeDefinition(10);
            var fc = new Function(functionUnderStudy, fitFunction, -7, 7);
            var rd = new ResearchDefinitions(cd, fc, 100, 0.1, 0.5);
            var listOfMediumAbsFitness = new List<double>();

            var startPop = Fitness.FitPop(
                Chromosome.NewRandomPopulation(
                    rd,
                    rd.Population));
            listOfMediumAbsFitness.Add(startPop.Sum(x => x.Fitness) / startPop.Count);

            var preselectedPop = new RouletteWheel().DrawChromosomes(startPop);

            var nextGenPop = Fitness.FitPop(PostSelection.CreateNewPopulation(preselectedPop, rd.CrossChance, rd.MutationChance));
            var bestChromosome = new BestChromosome()
            {
                bestChromosome = nextGenPop.Max(x => x),
                generation = 1
            };
            listOfMediumAbsFitness.Add(nextGenPop.Sum(x => x.Fitness) / nextGenPop.Count);

            for (int i = 1; i < iterations; i++)
            {
                nextGenPop = Fitness.FitPop(PostSelection.CreateNewPopulation(nextGenPop, rd.CrossChance, rd.MutationChance));
                if (bestChromosome.bestChromosome.AbsFitness < nextGenPop.Max(x => x.AbsFitness))
                {
                    bestChromosome.bestChromosome = nextGenPop.FirstOrDefault(x => x.AbsFitness == nextGenPop.Max(y => y.AbsFitness));
                    bestChromosome.generation = i + 1;
                }
                listOfMediumAbsFitness.Add(nextGenPop.Sum(x => x.Fitness) / nextGenPop.Count);
            }

            listOfMediumAbsFitness.ForEach(Console.WriteLine);
        }
    }
}
