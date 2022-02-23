using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using ZedGraph;

namespace ProjetDotNet
{
    public partial class Filtre : Form
    {
        private double[] conso;
        private double[] predict1;
        private double[] predict2;
        private string date = null;
        List<string[]> listA;
        private int period = 300;
        public Filtre()
        {
            InitializeComponent();

            listA = readCSV("bdd.csv");
            prepareDatas(listA);
            CreateGraph1(zedGraphControl1);
        }

        /*
         * Lis un fichier csv du nom donnée
         */
        private List<string[]> readCSV(string fileName)
        {
            using (var reader = new StreamReader(@fileName))
            {
                Boolean first = true;
                List<string[]> listA = new List<string[]>();
                int i = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    if (!first && values[4] != "")//&& i < 100
                    {
                        values[0] = i.ToString();
                        listA.Add(values);
                        i++;
                    }
                    else
                    {
                        first = false;
                    }
                }
                return listA;
            }
        }

        private void prepareDatas(List<string[]> listA)
        {
            int listeSize = listA.Count;

            conso = new double[listeSize];
            predict1 = new double[listeSize];
            predict2 = new double[listeSize];

            for (int i = 0; i < listeSize; i++)
            {
                conso[i] = Double.Parse(listA[i][4]);
                predict1[i] = Double.Parse(listA[i][5]);
                predict2[i] = Double.Parse(listA[i][6]);
            }
            for (int i = listeSize - 1; i >= 0; i--)
            {
                if (i >= period)
                {
                    for (int j = 1; j < period; j++)
                    {
                        conso[i] += conso[i - j];
                        predict1[i] += predict1[i - j];
                        predict2[i] += predict2[i - j];
                    }
                    conso[i] = conso[i] / period;
                    predict1[i] = predict1[i] / period;
                    predict2[i] = predict2[i] / period;
                }
                else
                {
                    conso[i] = conso[period];
                    predict1[i] = predict1[period];
                    predict2[i] = predict2[period];
                }
            }
        }
        private void prepareDayDatas(List<string[]> listA)
        {
            int daySize = 0;
            foreach (string[] val in listA)
            {
                if (val[2] == date)
                {
                    daySize++;
                }
            }
            int listeSize = listA.Count;

            conso = new double[daySize];
            predict1 = new double[daySize];
            predict2 = new double[daySize];

            int j = 0;
            for (int i = 0; i < listeSize; i++)
            {
                if (listA[i][2] == date)
                {
                    conso[j] = Double.Parse(listA[i][4]);
                    predict1[j] = Double.Parse(listA[i][5]);
                    predict2[j] = Double.Parse(listA[i][6]);
                    j++;
                }
            }
        }

        private void CreateGraph1(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            // Set the Titles
            myPane.Title.Text = "La consommation d'électricité en France en 2020";
            if (date != null)
            {
                myPane.Title.Text = "La consommation d'électricité en France le " + date;
            }
            myPane.XAxis.Title.Text = "Temps (par intervalle de 30 min)";
            myPane.YAxis.Title.Text = "Consommationon en MW";
            myPane.XAxis.Scale.Max = conso.Length - 1;
            //myPane.YAxis.Scale.Min = 0;
            if (date == null)
            {
                myPane.XAxis.Scale.Min = period;
            }
            else
            {
                myPane.XAxis.Scale.Min = 0;
            }

            // Make up some data arrays based on the Sine function
            double x;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            for (int i = 0; i < conso.Length; i++)
            {
                x = (double)i;
                list1.Add(x, conso[i]);
                list2.Add(x, predict1[i]);
                list3.Add(x, predict2[i]);
            }

            // Generate a red curve with diamond
            // symbols, and "Porsche" in the legend
            // Generate a blue curve with circle
            // symbols, and "Piper" in the legend
            LineItem myCurve2 = myPane.AddCurve("Prévision J-1",
                  list2, Color.Black, SymbolType.Circle);
            LineItem myCurve3 = myPane.AddCurve("Prévision J",
                  list3, Color.Purple, SymbolType.Circle);
            LineItem myCurve = myPane.AddCurve("Consommation réalisée",
                  list1, Color.Turquoise, SymbolType.Diamond);

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zgc.AxisChange();

            // Change the color of the title
            //myPane.Title.FontSpec.FontColor = Color.Green;

            // Add gridlines to the plot, and make them gray
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.Color = Color.LightGray;
            myPane.YAxis.MajorGrid.Color = Color.LightGray;

            // Move the legend location
            //myPane.Legend.Position = ZedGraph.LegendPos.Bottom;

            // Make both curves thicker
            myCurve.Line.Width = 2.0F;
            myCurve2.Line.Width = 2.0F;
            myCurve3.Line.Width = 2.0F;

            if (date == null)
            {
                myCurve2.IsVisible = false;
                myCurve3.IsVisible = false;
            }

            // Fill the area under the curves
            myCurve.Line.Fill = new Fill(Color.White, Color.Turquoise, 45F);
            /*myCurve2.Line.Fill = new Fill(Color.White, Color.Turquoise, 45F);
            myCurve3.Line.Fill = new Fill(Color.White, Color.GreenYellow, 45F);*/

            // Increase the symbol sizes, and fill them with solid white
            /*myCurve.Symbol.Size = 8.0F;
            myCurve2.Symbol.Size = 8.0F;
            myCurve.Symbol.Fill = new Fill(Color.White);
            myCurve2.Symbol.Fill = new Fill(Color.White);*/
            myCurve.Symbol.IsVisible = false;
            myCurve2.Symbol.IsVisible = false;
            myCurve3.Symbol.IsVisible = false;

            // Add a background gradient fill to the axis frame
            myPane.Chart.Fill = new Fill(Color.White,
                Color.FromArgb(214, 246, 232), -45F);
            myPane.Border.IsVisible = false;
            myPane.Chart.Border.IsVisible = false;
            myPane.Fill = new Fill(Color.MediumAquamarine);
        }

        private void refreshGraph()
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            CreateGraph1(zedGraphControl1);
            zedGraphControl1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            date = null;
            prepareDatas(listA);
            refreshGraph();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value.GetDateTimeFormats()[4];
            prepareDayDatas(listA);
            refreshGraph();
        }
    }
}
