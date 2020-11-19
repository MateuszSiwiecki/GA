using Xunit;
using GALib.PostSelection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace GALib.PostSelection.Tests
{
    public class PostSelectionTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public PostSelectionTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact()]
        public void MixChromosomesTest_NormalRandomChromosomes_ShouldPass()
        {
            var rd = DefaultResearchParameters.GetDefaultResearchDefinitions();
            var chromosomeA = Chromosome.NewRandomChromosome(rd);
            var chromosomeB = Chromosome.NewRandomChromosome(rd);

            var output = PostSelection.MixChromosomes(chromosomeA, chromosomeB);

            _testOutputHelper.WriteLine($"{output[0].Gene}");
            _testOutputHelper.WriteLine($"{output[1].Gene}");
            _testOutputHelper.WriteLine($"{chromosomeA.Gene}");
            _testOutputHelper.WriteLine($"{chromosomeB.Gene}");
            
            Assert.NotEqual(output[0].Gene, output[1].Gene);
            Assert.NotEqual(output[0].Gene, chromosomeA.Gene);
            Assert.NotEqual(output[0].Gene, chromosomeB.Gene);
            Assert.NotEqual(output[1].Gene, chromosomeA.Gene);
            Assert.NotEqual(output[1].Gene, chromosomeB.Gene);
        }
    }
}