using Xunit;
using GALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit.Abstractions;

namespace GA1.Tests
{
    public class ResearchModelTests
    {
        private int numberOfPopsToTest = 1000;
        [Fact()]
        public void NewRandomPopulationTest_RandomChromosomes_ShouldPassWithErrorMargin()
        {
            var listOfPop = ResearchModel.NewRandomPopulation(10);
            var errorMargin = 2;
            var errors = 0;
            for (int i = 0; i < listOfPop.Count - 1; i++)
            {
                if (listOfPop[i].Gene == listOfPop[i + 1].Gene) errors++;
                _testOutputHelper.WriteLine($"{listOfPop[i].Gene}");
            }
            Assert.True(errors < errorMargin);
        }

        [Fact()]
        public void FixedFitPopTest_RandomPop_ShouldPass()
        {
            var listOfPop = ResearchModel.NewRandomPopulation(10);
            var list = ResearchModel.FixedFitPop(listOfPop, out var lowestKey);
            _testOutputHelper.WriteLine($"Lowest key {lowestKey}");
            Assert.True(lowestKey > 0);
            foreach (var chromosome in list)
            {
                Assert.True(chromosome.Fitness >= 0);
                _testOutputHelper.WriteLine($"{chromosome.Fitness}");
            }
        }

        [Fact()]
        public void RouletteWheelTest_NormalPopWithFixedFitness_ShouldPass()
        {
            var testPop = ResearchModel.FixedFitPop(
                ResearchModel.NewRandomPopulation(numberOfPopsToTest));
            var outputTestPop = new RouletteWheel().DrawChromosomes(testPop);

            var fitnessSumTestPop = testPop.Sum(x => x.Fitness);
            var fitnessSumOutputTestPop = outputTestPop.Sum(x => x.Fitness);

            Assert.True(fitnessSumTestPop < fitnessSumOutputTestPop);
        }



        private readonly ITestOutputHelper _testOutputHelper;

        public ResearchModelTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
    }
}