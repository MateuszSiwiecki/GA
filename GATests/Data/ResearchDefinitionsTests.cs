using Xunit;
using Xunit.Abstractions;

namespace GALib.Tests
{
    public class ResearchDefinitionsTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ResearchDefinitionsTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(0, 4)]
        [InlineData(0, 3)]
        [InlineData(0, 2)]
        [InlineData(1, 2)]
        public void GetElementOfNPositionTest_CheckIfValueAreDifferent_ShouldPass(int a, int b)
        {
            var rd = DefaultResearchParameters.GetDefaultResearchDefinitions();
            var valueFirst = rd.GetElementOfNPosition(a);
            var valueSecond = rd.GetElementOfNPosition(b);
            _testOutputHelper.WriteLine($"{valueFirst} : {valueSecond}");
            Assert.False(valueFirst == valueSecond);
        }

        [Fact]
        public void GetElementOfNPositionTest_CheckCorrectness_LowestElement_ShouldPass()
        {
            var rd = DefaultResearchParameters.GetDefaultResearchDefinitions();
            var lowestElement = rd.GetElementOfNPosition(0);
            Assert.True(lowestElement == rd.LowerBound);
        }
        [Fact]
        public void GetElementOfNPositionTest_CheckCorrectness_HighestElement_ShouldPass()
        {
            var rd = DefaultResearchParameters.GetDefaultResearchDefinitions();
            var highestElement = rd.GetElementOfNPosition(rd.chromosomeDefinition.GenesCount);
            Assert.True(highestElement == rd.UpperBound);
        }
    }
}