using System;

namespace GALib
{
    public class Function
    {
        public Function(Func<double[], double> functionUnderStudy,
            Func<double[], double> fitFunction,
            double lowerBound,
            double upperBound)
        {
            FunctionUnderStudy = functionUnderStudy;
            FitFunction = fitFunction;
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }

        public Func<double[], double> FunctionUnderStudy { get; private set; }
        public Func<double[], double> FitFunction { get; private set; }
        public double LowerBound { get; private set; }
        public double UpperBound { get; private set; }
    }
}