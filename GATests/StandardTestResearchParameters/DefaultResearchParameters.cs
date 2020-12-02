using System;
using GALib;

namespace GALib
{
    public static class DefaultResearchParameters
    {
        public static ResearchDefinitions GetDefaultResearchDefinitions() =>
            new ResearchDefinitions(GetChromosomeDefinition(),
                GetFunctionDefinition(),
                10,
                0.5,
                0.5);
        public static ChromosomeDefinition GetChromosomeDefinition() =>
            new ChromosomeDefinition(8);
        public static Function GetFunctionDefinition() =>
            new Function(x => 0.2 * Math.Pow(x[0], 3) + 0.1 * Math.Pow(x[0], 2) - 8 * x[0],
                x => -(0.2 * Math.Pow(x[0], 3) + 0.1 * Math.Pow(x[0], 2) - 8 * x[0]),
                -7,
                7);
    }
}