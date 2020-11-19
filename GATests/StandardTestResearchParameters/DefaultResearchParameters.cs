using System;
using GALib;

namespace GALib
{
    public static class DefaultResearchParameters
    {
        public static ResearchDefinitions GetDefaultResearchDefinitions(ChromosomeDefinition cd) =>
            new ResearchDefinitions(
                new Func<double, double>(x => 0.2 * Math.Pow(x, 3) + 0.1 * Math.Pow(x, 2) - 8 * x),
                new Func<double, double>(x => -(0.2 * Math.Pow(x, 3) + 0.1 * Math.Pow(x, 2) - 8 * x)),
                -7,
                7,
                10,
                cd);
        public static ChromosomeDefinition GetChromosomeDefinition() =>
            new ChromosomeDefinition(512);
    }
}