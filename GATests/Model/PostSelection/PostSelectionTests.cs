using Xunit;
using GALib.PostSelection;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Theory()]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(62)]
        public void MixChromosomesTest_EdgeChromosomes_NormalPower_ShouldPass(int pow)
        {
            var rd = DefaultResearchParameters.GetDefaultResearchDefinitions(pow);
            var highestChromosome = DefaultResearchParameters.GetHigherChromosome(rd);
            var lowestChromosome = DefaultResearchParameters.GetLowestChromosome(rd);

            _testOutputHelper.WriteLine(highestChromosome.GeneInBinary());
            _testOutputHelper.WriteLine(lowestChromosome.GeneInBinary());

            var output = PostSelection.MixChromosomes(highestChromosome, lowestChromosome, 1);
            foreach (var chromosome in output)
            {
                Assert.Contains("1", chromosome.GeneInBinary());
                Assert.Contains("0", chromosome.GeneInBinary());
                _testOutputHelper.WriteLine(chromosome.GeneInBinary());
            }
        }
        [Theory()]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(15)]
        public void MixChromosomesTest_NormalChromosome_NormalPower_TestOutputLength_ShouldPass(int pow)
        {
            var rd = DefaultResearchParameters.GetDefaultResearchDefinitions(pow);
            var chromosomeA = Chromosome.NewRandomChromosome(rd);
            var chromosomeB = Chromosome.NewRandomChromosome(rd);

            _testOutputHelper.WriteLine(chromosomeA.GeneInBinary());
            _testOutputHelper.WriteLine(chromosomeB.GeneInBinary());

            var output = PostSelection.MixChromosomes(chromosomeA, chromosomeB, 1);
            foreach (var chromosome in output)
            {
                Assert.True(chromosome.GeneInBinary().Length == pow);
                _testOutputHelper.WriteLine(chromosome.GeneInBinary());
            }
        }

        [Fact]
        public void MixChromosomesTest_TryFindCrossingPointOnEndAllel_ShouldPass()
        {
            var rd = DefaultResearchParameters.GetDefaultResearchDefinitions(4);
            var highestChromosome = DefaultResearchParameters.GetHigherChromosome(rd);
            var lowestChromosome = DefaultResearchParameters.GetLowestChromosome(rd);
            var output = new List<Chromosome>();
            var found = false;
            for (int i = 0; i < 1000; i++)
            {
                output = PostSelection.MixChromosomes(highestChromosome, lowestChromosome, 1);
                if (output.All(x => x.GeneInBinary() != "1110")) continue;
                found = true;
                break;
            }
            _testOutputHelper.WriteLine(output[0].GeneInBinary());
            _testOutputHelper.WriteLine(output[1].GeneInBinary());
            Assert.True(found);
        }
    }
}