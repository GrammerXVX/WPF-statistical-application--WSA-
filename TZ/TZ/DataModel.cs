using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace TZ
{
    class DataModel
    {
        public PlotModel MyModel { private set; get; }
        private FunctionSeries ProcessFunction;
        private DataPoint Data;

        public DataModel()
        {
            MyModel = new PlotModel();
            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Day", Minimum = 1 });
            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Steps" });
        }
        public PlotModel DataViewModel(Person p)
        {
            MyModel.Series.Clear();
            MyModel.ResetAllAxes();
            ProcessFunction = new FunctionSeries();
            for (int x = 1; x < p.DaySteps.Count+1; x++)
            {
                Data = new DataPoint(x, p.DaySteps[x - 1]);
                ProcessFunction.Points.Add(Data);
            }
            MyModel.Series.Add(ProcessFunction);
            MyModel.InvalidatePlot(true);
            return MyModel;
        }
    }
}
