using Xunit;
using GALib;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xunit.Abstractions;

namespace GA1.Tests
{
    public class UtilsTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UtilsTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory()]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(1)]
        [InlineData(0)]
        public void RandomNumberDigitsTest_ValueInRange_ShouldPass(int numberOfDigits)
        {
            var output = Utils.RandomNumberDigits(numberOfDigits);
            _testOutputHelper.WriteLine($"{output}");
            Assert.True(output >= 0);
            Assert.True(output <= 100);
        }
    }
}