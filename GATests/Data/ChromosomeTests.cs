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
            var chromosome = new Chromosome();
            chromosome.SetGene(binary);
            Assert.True(chromosome.Gene == expectedGene);
        }

        [Fact()]
        public void CalculateFitnessTest_CheckFitnessForRandomGenes_ShouldPass()
        {
            ResearchDefinitions.SetResearch(-7, 7, 10);
            var chromosomes = ResearchModel.NewRandomPopulation(ResearchDefinitions.StartPopSize);
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
    }
}