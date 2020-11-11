using Xunit;
using GA1;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace GA1.Tests
{
    public class ResearchModelTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ResearchModelTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

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
            foreach (var chromosome in list)
            {
                _testOutputHelper.WriteLine($"{chromosome.Fitness}");
            }
            Assert.Contains(list, pair => pair.Fitness >= 0);
        }
    }
}