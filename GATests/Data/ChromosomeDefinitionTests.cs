using Xunit;
using GALib;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace GALib.Tests
{
    public class ChromosomeDefinitionTests
    {
        [Theory()]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void ChromosomeDefinitionTest(int pow)
        {
            var cd = new ChromosomeDefinition(pow);
            Assert.Equal(Math.Pow(2, pow), cd.GenesCount);
        }
    
        private readonly ITestOutputHelper _testOutputHelper;

        public ChromosomeDefinitionTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData("1")]
        [InlineData("100")]
        [InlineData("101")]
        [InlineData("101010")]
        [InlineData("11")]
        public void BinaryGeneFixTest_NormalData_ShouldPass(string valueToFix)
        {
            var cd = DefaultResearchParameters.GetChromosomeDefinition();
            var value = cd.BinaryGeneFix(valueToFix);
            int result = -1;
            _testOutputHelper.WriteLine($"Chromosome lenght = {cd.ChromosomeLength}");
            _testOutputHelper.WriteLine(value);
            Assert.True(value.Length == cd.ChromosomeLength);
            Assert.True(int.TryParse(value, out result));
        }
    }
}