using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ZedGraph;

namespace ProjetDotNet
{
    public partial class Graph : Form
    {
        private Random rand = new Random(0);
        /*
         * Génère une liste aléatoire 
         */
        private double[] RandomWalk(int points = 5, double start = 100, double mult = 50)
        {
            // return an array of difting random numbers
            double[] values = new double[points];
            values[0] = start;
            for (int i = 1; i < points; i++)
                values[i] = values[i - 1] + (rand.NextDouble() - .5) * mult;
            return values;
        }
<<<<<<< HEAD:ProjetDotNet/Form1.cs
        /*
         * Lis un fichier csv du nom donnée
         */
        private List<string[]> readCSV(string fileName)
        {
            using (var reader = new StreamReader(@fileName))
            {
                Boolean first = true;
                List<string[]> listA = new List<string[]>();
                List<string> listB = new List<string>();
                int i = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    if (!first && values[4] != "" && i < 200)
                    {
                        values[0] = i.ToString();
                        listA.Add(values);
                        i++;
                        //listB.Add(values[1]);
                    } else {
                        first = false;
                    }
                }
                return listA;
            }
        }
        public Form1()
=======
        public Graph()
>>>>>>> origin/main:ProjetDotNet/Graph.cs
        {
            InitializeComponent();
            /*plotBar();
            plotScatter();
            plotLines();*/
            List<string[]> listA = readCSV("bdd.csv");
            double[] xs = new double[listA.Count];
            string[] xsStr = new string[listA.Count];
            double[] ys1 = new double[listA.Count];
            for (int i = 0; i < listA.Count; i++)
            {
                xs[i] = Double.Parse(listA[i][0]);
                xsStr[i] = listA[i][2];
                ys1[i] = Double.Parse(listA[i][4]);
            }
            int pointCount = listA.Count;
            // clear old curves
            zedGraphControl1.GraphPane.CurveList.Clear();

            // plot the data as bars
            zedGraphControl1.GraphPane.AddBar("Group A", xs, ys1, Color.Blue);

            // style the plot
            zedGraphControl1.GraphPane.Title.Text = $"Bar Plot ({pointCount:n0} points)";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Horizontal Axis Label";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Vertical Axis Label";

            // auto-axis and update the display
            zedGraphControl1.GraphPane.XAxis.ResetAutoScale(zedGraphControl1.GraphPane, CreateGraphics());
            zedGraphControl1.GraphPane.YAxis.ResetAutoScale(zedGraphControl1.GraphPane, CreateGraphics());
            zedGraphControl1.Refresh();


            /*foreach (string[] line in listA)
            {
                Console.WriteLine(line[0]+" : "+line[5]);
            }*/

            // clear old curves
            /*zedGraphControl3.GraphPane.CurveList.Clear();

            // plot the data as curves
            var curve1 = zedGraphControl3.GraphPane.AddCurve("Series A", xs, ys1, Color.Blue);
            curve1.Line.IsAntiAlias = true;
            curve1.Symbol.IsVisible = false;

            // style the plot
            zedGraphControl3.GraphPane.Title.Text = $"Scatter Plot ({pointCount:n0} points)";
            zedGraphControl3.GraphPane.XAxis.Title.Text = "Horizontal Axis Label";
            zedGraphControl3.GraphPane.YAxis.Title.Text = "Vertical Axis Label";

            // auto-axis and update the display
            zedGraphControl3.GraphPane.XAxis.ResetAutoScale(zedGraphControl3.GraphPane, CreateGraphics());
            zedGraphControl3.GraphPane.YAxis.ResetAutoScale(zedGraphControl3.GraphPane, CreateGraphics());
            zedGraphControl3.Refresh();*/

            CreateGraph(zedGraphControl3);
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

<<<<<<< HEAD:ProjetDotNet/Form1.cs
        private void CreateGraph(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            // Set the Titles
            myPane.Title.Text = "La production d'électricité par filière";
            myPane.XAxis.Title.Text = "Filières";
            myPane.YAxis.Title.Text = "Production en MW";

            //Grid
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.DashOn = 10;
            myPane.XAxis.MajorGrid.DashOff = 5;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.DashOn = 10;
            myPane.YAxis.MajorGrid.DashOff = 5;
            myPane.YAxis.MinorGrid.IsVisible = true;
            myPane.YAxis.MinorGrid.DashOn = 1;
            myPane.YAxis.MinorGrid.DashOff = 2;
            myPane.XAxis.MinorGrid.IsVisible = true;
            myPane.XAxis.MinorGrid.DashOn = 1;
            myPane.XAxis.MinorGrid.DashOff = 2;

            // Make up some random data points
            //string[] labels = { "Fioul", "Charbon", "Gaz", "Nucléaire", "Eolien", "Solaire", "Hydraulique", "Bioénergies" };
            string[] labels = { "" };
           // double[] a = { 1, 2, 8, 61, 10, 4, 12, 2 };
            double[] y = { 61 };
            double[] y2 = { 12 };
            double[] y3 = { 10 };
            double[] y4 = { 8 };
            double[] y5 = { 4 };
            double[] y6 = { 2 };
            double[] y7 = { 2 };
            double[] y8 = { 1 };
            //double[] x = { 0, 900 };
            //double[] y4 = { 90, 90 };

            // Generate a black line with "Curve 4" in the legend
            //LineItem myCurve = myPane.AddCurve("Curve 4", x, y4, Color.Black, SymbolType.Circle);

            // Generate a red bar with "Curve 1" in the legend
            BarItem myBar = myPane.AddBar("Nucléaire", null, y, Color.Yellow);
            BarItem myBar2 = myPane.AddBar("Hydraulique", null, y2, Color.Blue);
            BarItem myBar3 = myPane.AddBar("Eolien", null, y3, Color.GreenYellow);
            BarItem myBar4 = myPane.AddBar("Gaz", null, y4, Color.Red);
            BarItem myBar5 = myPane.AddBar("Solaire", null, y5, Color.Orange);
            BarItem myBar6 = myPane.AddBar("Charbon", null, y6, Color.Brown);
            BarItem myBar7 = myPane.AddBar("Bioénergies", null, y7, Color.Green);
            BarItem myBar8 = myPane.AddBar("Fioul", null, y8, Color.Purple);
            //myBar.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red);

            // Fix up the curve attributes a little
            /*myCurve.Symbol.Size = 8.0F;
            myCurve.Symbol.Fill = new Fill(Color.White);
            myCurve.Line.Width = 2.0F;

            // Fix up the curve attributes a little
            myCurve.Symbol.Size = 8.0F;
            myCurve.Symbol.Fill = new Fill(Color.White);
            myCurve.Line.Width = 2.0F;*/

            // Draw the X tics between the labels instead of 
            // at the labels
            myPane.XAxis.MajorTic.IsBetweenLabels = true;

            // Set the XAxis labels
            myPane.XAxis.Scale.TextLabels = labels;
            // Set the XAxis to Text type
            myPane.XAxis.Type = AxisType.Text;

            // Fill the Axis and Pane backgrounds
            //myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 90F);
            //myPane.Fill = new Fill(Color.FromArgb(250, 250, 255));

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zgc.AxisChange();
=======
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
>>>>>>> origin/main:ProjetDotNet/Graph.cs
        }
    }
}
