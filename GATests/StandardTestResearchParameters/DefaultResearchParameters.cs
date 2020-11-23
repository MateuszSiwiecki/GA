﻿using System;
using GALib;

namespace GALib
{
    public static class DefaultResearchParameters
    {
        public static ResearchDefinitions GetDefaultResearchDefinitions() =>
            new ResearchDefinitions(
                x => 0.2 * Math.Pow(x[0], 3) + 0.1 * Math.Pow(x[0], 2) - 8 * x[0],
                x => -(0.2 * Math.Pow(x[0], 3) + 0.1 * Math.Pow(x[0], 2) - 8 * x[0]),
                -7,
                7,
                10,
                GetChromosomeDefinition());
        public static ChromosomeDefinition GetChromosomeDefinition() =>
            new ChromosomeDefinition(8);
    }
}