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
            var cd = DefaultResearchParameters.GetChromosomeDefinition();
            var rd = DefaultResearchParameters.GetDefaultResearchDefinitions(cd);
            var chromosome = new Chromosome(rd, cd);
            chromosome.SetGene(binary);
            _testOutputHelper.WriteLine($"{chromosome.Gene} {expectedGene}");
            Assert.True(chromosome.Gene == expectedGene);
        }

        [Fact()]
        public void CalculateFitnessTest_CheckFitnessForRandomGenes_ShouldPass()
        {
            var cd = DefaultResearchParameters.GetChromosomeDefinition();
            var rd = DefaultResearchParameters.GetDefaultResearchDefinitions(cd);
            var chromosomes = ResearchModel.NewRandomPopulation(rd, cd, rd.StartPopSize);
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
            var cd = DefaultResearchParameters.GetChromosomeDefinition();
            var rd = DefaultResearchParameters.GetDefaultResearchDefinitions(cd);
            var aChromosome = new Chromosome(rd, cd)
            {
                AbsFitness = aFitness
            };
            var bChromosome = new Chromosome(rd, cd)
            {
                AbsFitness = bFitness
            };
            Assert.True(aChromosome.CompareTo(bChromosome) > 0);
        }
    }
}