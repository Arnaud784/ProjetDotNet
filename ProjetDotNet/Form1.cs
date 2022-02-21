using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetDotNet
{
    public partial class Form1 : Form
    {
        private Random rand = new Random(0);
        private double[] RandomWalk(int points = 5, double start = 100, double mult = 50)
        {
            // return an array of difting random numbers
            double[] values = new double[points];
            values[0] = start;
            for (int i = 1; i < points; i++)
                values[i] = values[i - 1] + (rand.NextDouble() - .5) * mult;
            return values;
        }
        public Form1()
        {
            InitializeComponent();
            plotBar();
            plotScatter();
            plotLines();
        }

        public void plotBar()
        {
            // generate some random Y data
            int pointCount = 5;
            double[] xs = RandomWalk(pointCount);
            double[] ys1 = RandomWalk(pointCount);
            double[] ys2 = RandomWalk(pointCount);

            // clear old curves
            zedGraphControl1.GraphPane.CurveList.Clear();

            // plot the data as bars
            zedGraphControl1.GraphPane.AddBar("Group A", xs, ys1, Color.Blue);
            zedGraphControl1.GraphPane.AddBar("Group B", xs, ys2, Color.Red);

            // style the plot
            zedGraphControl1.GraphPane.Title.Text = $"Bar Plot ({pointCount:n0} points)";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Horizontal Axis Label";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Vertical Axis Label";

            // auto-axis and update the display
            zedGraphControl1.GraphPane.XAxis.ResetAutoScale(zedGraphControl1.GraphPane, CreateGraphics());
            zedGraphControl1.GraphPane.YAxis.ResetAutoScale(zedGraphControl1.GraphPane, CreateGraphics());
            zedGraphControl1.Refresh();
        }

        public void plotScatter()
        {
            // generate some random Y data
            int pointCount = 100;
            double[] xs1 = RandomWalk(pointCount);
            double[] ys1 = RandomWalk(pointCount);
            double[] xs2 = RandomWalk(pointCount);
            double[] ys2 = RandomWalk(pointCount);

            // clear old curves
            zedGraphControl2.GraphPane.CurveList.Clear();

            // plot the data as curves
            var curve1 = zedGraphControl2.GraphPane.AddCurve("Series A", xs1, ys1, Color.Blue);
            curve1.Line.IsAntiAlias = true;

            var curve2 = zedGraphControl2.GraphPane.AddCurve("Series B", xs2, ys2, Color.Red);
            curve2.Line.IsAntiAlias = true;

            // style the plot
            zedGraphControl2.GraphPane.Title.Text = $"Scatter Plot ({pointCount:n0} points)";
            zedGraphControl2.GraphPane.XAxis.Title.Text = "Horizontal Axis Label";
            zedGraphControl2.GraphPane.YAxis.Title.Text = "Vertical Axis Label";

            // auto-axis and update the display
            zedGraphControl2.GraphPane.XAxis.ResetAutoScale(zedGraphControl2.GraphPane, CreateGraphics());
            zedGraphControl2.GraphPane.YAxis.ResetAutoScale(zedGraphControl2.GraphPane, CreateGraphics());
            zedGraphControl2.Refresh();
        }

        public void plotLines()
        {
            // generate some random Y data
            int pointCount = 100_000;
            double[] xs = RandomWalk(pointCount);
            double[] ys1 = RandomWalk(pointCount);
            double[] ys2 = RandomWalk(pointCount);

            // clear old curves
            zedGraphControl3.GraphPane.CurveList.Clear();

            // plot the data as curves
            var curve1 = zedGraphControl3.GraphPane.AddCurve("Series A", xs, ys1, Color.Blue);
            curve1.Line.IsAntiAlias = true;
            curve1.Symbol.IsVisible = false;

            var curve2 = zedGraphControl3.GraphPane.AddCurve("Series B", xs, ys2, Color.Red);
            curve2.Line.IsAntiAlias = true;
            curve2.Symbol.IsVisible = false;

            // style the plot
            zedGraphControl3.GraphPane.Title.Text = $"Scatter Plot ({pointCount:n0} points)";
            zedGraphControl3.GraphPane.XAxis.Title.Text = "Horizontal Axis Label";
            zedGraphControl3.GraphPane.YAxis.Title.Text = "Vertical Axis Label";

            // auto-axis and update the display
            zedGraphControl3.GraphPane.XAxis.ResetAutoScale(zedGraphControl3.GraphPane, CreateGraphics());
            zedGraphControl3.GraphPane.YAxis.ResetAutoScale(zedGraphControl3.GraphPane, CreateGraphics());
            zedGraphControl3.Refresh();
        }
    }
}
