using Xunit;
using GALib;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace GALib.Tests
{
    public class ChromosomeTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ChromosomeTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory()]
        [InlineData("001", 1)]
        [InlineData("101", 5)]
        [InlineData("1111", 15)]
        [InlineData("1010", 10)]
        public void SetGeneTest(string binary, int expectedGene)
        {
            var rd = DefaultResearchParameters.GetDefaultResearchDefinitions();
            var chromosome = new Chromosome(rd);
            chromosome.SetGene(binary);
            _testOutputHelper.WriteLine($"{chromosome.Gene} {expectedGene}");
            Assert.True(chromosome.Gene == expectedGene);
        }
        [Theory()]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(62)]
        public void GeneInBinaryTest_CheckForLengthOfGene_ShouldPass(int pow)
        {
            var rd = DefaultResearchParameters.GetDefaultResearchDefinitions(pow);
            var rndChromosome = Chromosome.NewRandomChromosome(rd);
            Assert.True(rndChromosome.GeneInBinary().Length == pow);
            _testOutputHelper.WriteLine(rndChromosome.GeneInBinary());
        }

        [Fact()]
        public void CalculateFitnessTest_CheckFitnessForRandomGenes_ShouldPass()
        {
            var rd = DefaultResearchParameters.GetDefaultResearchDefinitions();
            var chromosomes = Chromosome.NewRandomPopulation(rd, rd.Population);
            foreach (var chromosome in chromosomes)
            {
                chromosome.SetFitness();
            }

            var errors = 0;
            for (int i = 0; i < chromosomes.Count - 1; i++)
            {
                if (chromosomes[i].Fitness == chromosomes[i + 1].Fitness) errors++;
                _testOutputHelper.WriteLine($"Fitness of {i}: {chromosomes[i].Fitness}, gene {chromosomes[i].Gene}");
            }

            Assert.True(errors == 0);
        }

        [Theory()]
        [InlineData(3, 2)]
        [InlineData(3, -2)]
        [InlineData(-2, -3)]
        [InlineData(0, -2)]
        public void CompareToTest_AShouldBeHigher_ShouldPass(double aFitness, double bFitness)
        {
            var rd = DefaultResearchParameters.GetDefaultResearchDefinitions();
            var aChromosome = new Chromosome(rd)
            {
                AbsFitness = aFitness
            };
            var bChromosome = new Chromosome(rd)
            {
                AbsFitness = bFitness
            };
            Assert.True(aChromosome.CompareTo(bChromosome) > 0);
        }
    }
}