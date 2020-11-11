using Xunit;
using GA1;
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
            var chromosomes = ResearchModel.NewRandomPopulation(10);
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