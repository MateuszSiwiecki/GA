using Xunit;
using GALib;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace GA1.Tests
{
    public class ChromosomeTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ChromosomeTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
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