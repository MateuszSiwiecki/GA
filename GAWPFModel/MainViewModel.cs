using System;
using System;

using OxyPlot;
using OxyPlot.Series;


namespace GAWPFModel
{

    public class MainViewModel
    {
        public MainViewModel()
        {
            this.MyModel = new PlotModel { Title = "Example 1" };
            MyModel.PlotType = PlotType.XY;
            this.MyModel.Series.Add(new FunctionSeries(Math.Cos, -10, 10, 0.001, "cos(x)"));
        }

        public PlotModel MyModel { get; private set; }
    }
}
