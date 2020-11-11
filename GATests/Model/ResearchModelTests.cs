using Xunit;
using GA1;
using System;
using System.Collections.Generic;
using System.Text;

namespace GA1.Tests
{
    public class ResearchModelTests
    {
        [Fact()]
        public void NewRandomPopulationTest_RandomChromosomes_ShouldPassWithErrorMargin()
        {
            var listOfPop = ResearchModel.NewRandomPopulation(10);
            var errorMargin = 2;
            var errors = 0;
            for (int i = 0; i < listOfPop.Count - 1; i++)
            {
                if(listOfPop[i].Gene == listOfPop[i+1].Gene) errors++;
            }
            Assert.True(errors < errorMargin);
        }
    }
}