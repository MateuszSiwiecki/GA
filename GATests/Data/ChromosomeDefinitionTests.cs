using Xunit;
using GALib;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace GA1.Tests
{
    public class ChromosomeDefinitionTests
    {
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
            var value = ChromosomeDefinition.BinaryGeneFix(valueToFix);
            int result = -1;
            _testOutputHelper.WriteLine($"Chromosome lenght = {ChromosomeDefinition.ChromosomeLength}");
            _testOutputHelper.WriteLine(value);
            Assert.True(value.Length == ChromosomeDefinition.ChromosomeLength);
            Assert.True(int.TryParse(value, out result));
        }
    }
}