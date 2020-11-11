using Xunit;
using GA1;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace GA1.Tests
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
            var valueFirst = ResearchDefinitions.GetElementOfNPosition(a);
            var valueSecond = ResearchDefinitions.GetElementOfNPosition(b);
            _testOutputHelper.WriteLine($"{valueFirst} : {valueSecond}");
            Assert.False(valueFirst == valueSecond);
        }
    }
}