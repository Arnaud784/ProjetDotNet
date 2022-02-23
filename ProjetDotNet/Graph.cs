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
        private double[] nucleaire;
        private double[] hydraulique;
        private double[] eolien;
        private double[] gaz;
        private double[] solaire;
        private double[] charbon;
        private double[] bioenergies;
        private double[] fioul;
        private double mNucleaire;
        private double mHydraulique;
        private double mEolien;
        private double mGaz;
        private double mSolaire;
        private double mCharbon;
        private double mBioenergies;
        private double mFioul;
        private double mTotal;

        private int period = 300;
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
                    if (!first && values[4] != "")//&& i < 100
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
        public Graph()
        {
            InitializeComponent();
            /*plotBar();
            plotScatter();
            plotLines();*/
            List<string[]> listA = readCSV("bdd.csv");

            prepareDatas(listA);

            //int pointCount = listA.Count;

            CreateGraph3(zedGraphControl3);
            CreateGraph1(zedGraphControl1);
        }

        private void prepareDatas(List<string[]> listA)
        {
            nucleaire = new double[listA.Count];
            hydraulique = new double[listA.Count];
            eolien = new double[listA.Count];
            gaz = new double[listA.Count];
            solaire = new double[listA.Count];
            charbon = new double[listA.Count];
            bioenergies = new double[listA.Count];
            fioul = new double[listA.Count];

            for (int i = 0; i < listA.Count; i++)
            {
                nucleaire[i] = Double.Parse(listA[i][10]);
                hydraulique[i] = Double.Parse(listA[i][13]);
                eolien[i] = Double.Parse(listA[i][11]);
                gaz[i] = Double.Parse(listA[i][9]);
                solaire[i] = Double.Parse(listA[i][12]);
                charbon[i] = Double.Parse(listA[i][8]);
                bioenergies[i] = Double.Parse(listA[i][15]);
                fioul[i] = Double.Parse(listA[i][7]);
            }
            mNucleaire = 0;
            mHydraulique = 0;
            mEolien = 0;
            mGaz = 0;
            mSolaire = 0;
            mCharbon = 0;
            mBioenergies = 0;
            mFioul = 0;
            for (int i = listA.Count - 1; i >= 0; i--)
            {
                mNucleaire += nucleaire[i];
                mHydraulique += hydraulique[i];
                mEolien += eolien[i];
                mGaz += gaz[i];
                mSolaire += solaire[i];
                mCharbon += charbon[i];
                mBioenergies += bioenergies[i];
                mFioul += fioul[i];

                if (i >= period)
                {
                    for (int j = 1; j < period; j++)
                    {
                        nucleaire[i] += nucleaire[i - j];
                        hydraulique[i] += hydraulique[i - j];
                        eolien[i] += eolien[i - j];
                        gaz[i] += gaz[i - j];
                        solaire[i] += solaire[i - j];
                        charbon[i] += charbon[i - j];
                        bioenergies[i] += bioenergies[i - j];
                        fioul[i] += fioul[i - j];
                    }
                    nucleaire[i] = nucleaire[i] / period;
                    hydraulique[i] = hydraulique[i] / period;
                    eolien[i] = eolien[i] / period;
                    gaz[i] = gaz[i] / period;
                    solaire[i] = solaire[i] / period;
                    charbon[i] = charbon[i] / period;
                    bioenergies[i] = bioenergies[i] / period;
                    fioul[i] = fioul[i] / period;
                }
                else
                {
                    nucleaire[i] = nucleaire[period];
                    hydraulique[i] = hydraulique[period];
                    eolien[i] = eolien[period];
                    gaz[i] = gaz[period];
                    solaire[i] = solaire[period];
                    charbon[i] = charbon[period];
                    bioenergies[i] = bioenergies[period];
                    fioul[i] = fioul[period];
                }
            }
            mNucleaire /= listA.Count;
            mHydraulique /= listA.Count;
            mEolien /= listA.Count;
            mGaz /= listA.Count;
            mSolaire /= listA.Count;
            mCharbon /= listA.Count;
            mBioenergies /= listA.Count;
            mFioul /= listA.Count;
            mTotal = mNucleaire + mHydraulique + mEolien + mGaz + mSolaire + mCharbon + mBioenergies + mFioul;
        }

        private void CreateGraph3(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            // Set the Titles
            myPane.Title.Text = "La production d'électricité en France par filière en 2021";
            myPane.XAxis.Title.Text = "Filières";
            myPane.YAxis.Title.Text = "Production en %";

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
            double[] y = { (100 * mNucleaire) / mTotal };
            double[] y2 = { (100 * mHydraulique) / mTotal };
            double[] y3 = { (100 * mEolien) / mTotal };
            double[] y4 = { (100 * mGaz) / mTotal };
            double[] y5 = { (100 * mSolaire) / mTotal };
            double[] y6 = { (100 * mCharbon) / mTotal };
            double[] y7 = { (100 * mBioenergies) / mTotal };
            double[] y8 = { (100 * mFioul) / mTotal };
            //double[] x = { 0, 900 };
            //double[] y4 = { 90, 90 };

            // Generate a black line with "Curve 4" in the legend
            //LineItem myCurve = myPane.AddCurve("Curve 4", x, y4, Color.Black, SymbolType.Circle);

            // Generate a red bar with "Curve 1" in the legend
            BarItem myBar = myPane.AddBar("Nucléaire", null, y, Color.Yellow);
            BarItem myBar2 = myPane.AddBar("Hydraulique", null, y2, Color.Turquoise);
            BarItem myBar3 = myPane.AddBar("Eolien", null, y3, Color.GreenYellow);
            BarItem myBar4 = myPane.AddBar("Gaz", null, y4, Color.Red);
            BarItem myBar5 = myPane.AddBar("Solaire", null, y5, Color.Orange);
            BarItem myBar6 = myPane.AddBar("Charbon", null, y6, Color.Brown);
            BarItem myBar7 = myPane.AddBar("Bioénergies", null, y7, Color.Green);
            BarItem myBar8 = myPane.AddBar("Fioul", null, y8, Color.Purple);
            //myBar.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red);

            if (!checkBox_nuc.Checked)
            {
                myBar.IsVisible = false;
            }
            if (!checkBox_hydra.Checked)
            {
                myBar2.IsVisible = false;
            }
            if (!checkBox_eol.Checked)
            {
                myBar3.IsVisible = false;
            }
            if (!checkBox_gaz.Checked)
            {
                myBar4.IsVisible = false;
            }
            if (!checkBox_sol.Checked)
            {
                myBar5.IsVisible = false;
            }
            if (!checkBox_charbon.Checked)
            {
                myBar6.IsVisible = false;
            }
            if (!checkBox_bio.Checked)
            {
                myBar7.IsVisible = false;
            }
            if (!checkBox_fioul.Checked)
            {
                myBar8.IsVisible = false;
            }

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

            // Add a background gradient fill to the axis frame
            myPane.Chart.Fill = new Fill(Color.White,
                Color.FromArgb(214, 246, 232), -45F);

            // Fill the Axis and Pane backgrounds
            //myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 90F);
            //myPane.Fill = new Fill(Color.FromArgb(250, 250, 255));

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zgc.AxisChange();
        }

        private void CreateGraph1(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            // Set the Titles
            myPane.Title.Text = "La production d'électricité en France par filière en 2021";
            myPane.XAxis.Title.Text = "Temps";
            myPane.YAxis.Title.Text = "Production en MW";
            myPane.XAxis.Scale.Max = nucleaire.Length;
            myPane.XAxis.Scale.Min = period;

            // Make up some data arrays based on the Sine function
            double x;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            PointPairList list4 = new PointPairList();
            PointPairList list5 = new PointPairList();
            PointPairList list6 = new PointPairList();
            PointPairList list7 = new PointPairList();
            PointPairList list8 = new PointPairList();
            for (int i = 0; i < nucleaire.Length; i++)
            {
                x = (double)i;
                //y1 = 1.5 + Math.Sin((double)i * 0.2);
                //y2 = 3.0 * (1.5 + Math.Sin((double)i * 0.2));
                double somme = 0;
                if (checkBox_nuc.Checked)
                {
                    somme += nucleaire[i];
                    list1.Add(x, somme);
                }
                if (checkBox_hydra.Checked)
                {
                    somme += hydraulique[i];
                    list2.Add(x, somme);
                }
                if (checkBox_eol.Checked)
                {
                    somme += eolien[i];
                    list3.Add(x, somme);
                }
                if (checkBox_gaz.Checked)
                {
                    somme += gaz[i];
                    list4.Add(x, somme);
                }
                if (checkBox_sol.Checked)
                {
                    somme += solaire[i];
                    list5.Add(x, somme);
                }
                if (checkBox_charbon.Checked)
                {
                    somme += charbon[i];
                    list6.Add(x, somme);
                }
                if (checkBox_bio.Checked)
                {
                    somme += bioenergies[i];
                    list7.Add(x, somme);
                }
                if (checkBox_fioul.Checked)
                {
                    somme += fioul[i];
                    list8.Add(x, somme);
                }
            }

            // Generate a red curve with diamond
            // symbols, and "Porsche" in the legend
            LineItem myCurve = myPane.AddCurve("Nucléaire",
                  list1, Color.Yellow, SymbolType.Diamond);
            // Generate a blue curve with circle
            // symbols, and "Piper" in the legend
            LineItem myCurve2 = myPane.AddCurve("Hydraulique",
                  list2, Color.Turquoise, SymbolType.Circle);
            LineItem myCurve3 = myPane.AddCurve("Eolien",
                  list3, Color.GreenYellow, SymbolType.Circle);
            LineItem myCurve4 = myPane.AddCurve("Gaz",
                  list4, Color.Red, SymbolType.Circle);
            LineItem myCurve5 = myPane.AddCurve("Solaire",
                  list5, Color.Orange, SymbolType.Circle);
            LineItem myCurve6 = myPane.AddCurve("Charbon",
                  list6, Color.Brown, SymbolType.Circle);
            LineItem myCurve7 = myPane.AddCurve("Bioénergies",
                  list7, Color.Green, SymbolType.Circle);
            LineItem myCurve8 = myPane.AddCurve("Fioul",
                  list8, Color.Purple, SymbolType.Circle);

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
            myCurve4.Line.Width = 2.0F;
            myCurve5.Line.Width = 2.0F;
            myCurve6.Line.Width = 2.0F;
            myCurve7.Line.Width = 2.0F;
            myCurve8.Line.Width = 2.0F;

            // Fill the area under the curves
            myCurve.Line.Fill = new Fill(Color.White, Color.Yellow, 45F);
            myCurve2.Line.Fill = new Fill(Color.White, Color.Turquoise, 45F);
            myCurve3.Line.Fill = new Fill(Color.White, Color.GreenYellow, 45F);
            myCurve4.Line.Fill = new Fill(Color.White, Color.Red, 45F);
            myCurve5.Line.Fill = new Fill(Color.White, Color.Orange, 45F);
            myCurve6.Line.Fill = new Fill(Color.White, Color.Brown, 45F);
            myCurve7.Line.Fill = new Fill(Color.White, Color.Green, 45F);
            myCurve8.Line.Fill = new Fill(Color.White, Color.Purple, 45F);

            // Increase the symbol sizes, and fill them with solid white
            /*myCurve.Symbol.Size = 8.0F;
            myCurve2.Symbol.Size = 8.0F;
            myCurve.Symbol.Fill = new Fill(Color.White);
            myCurve2.Symbol.Fill = new Fill(Color.White);*/
            myCurve.Symbol.IsVisible = false;
            myCurve2.Symbol.IsVisible = false;
            myCurve3.Symbol.IsVisible = false;
            myCurve4.Symbol.IsVisible = false;
            myCurve5.Symbol.IsVisible = false;
            myCurve6.Symbol.IsVisible = false;
            myCurve7.Symbol.IsVisible = false;
            myCurve8.Symbol.IsVisible = false;

            if (!checkBox_nuc.Checked)
            {
                myCurve.IsVisible = false;
            }
            if (!checkBox_hydra.Checked)
            {
                myCurve2.IsVisible = false;
            }
            if (!checkBox_eol.Checked)
            {
                myCurve3.IsVisible = false;
            }
            if (!checkBox_gaz.Checked)
            {
                myCurve4.IsVisible = false;
            }
            if (!checkBox_sol.Checked)
            {
                myCurve5.IsVisible = false;
            }
            if (!checkBox_charbon.Checked)
            {
                myCurve6.IsVisible = false;
            }
            if (!checkBox_bio.Checked)
            {
                myCurve7.IsVisible = false;
            }
            if (!checkBox_fioul.Checked)
            {
                myCurve8.IsVisible = false;
            }


            // Add a background gradient fill to the axis frame
            myPane.Chart.Fill = new Fill(Color.White,
                Color.FromArgb(214, 246, 232), -45F);

            // Add a caption and an arrow
            /*TextObj myText = new TextObj("Interesting\nPoint", 230F, 70F);
            myText.FontSpec.FontColor = Color.Red;
            myText.Location.AlignH = AlignH.Center;
            myText.Location.AlignV = AlignV.Top;
            myPane.GraphObjList.Add(myText);
            ArrowObj myArrow = new ArrowObj(Color.Red, 12F, 230F, 70F, 280F, 55F);
            myPane.GraphObjList.Add(myArrow);*/
        }

            private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkboxChange(object sender, EventArgs e)
        {
            zedGraphControl3.GraphPane.CurveList.Clear();
            zedGraphControl3.GraphPane.GraphObjList.Clear();
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            CreateGraph3(zedGraphControl3);
            CreateGraph1(zedGraphControl1);
            zedGraphControl3.Refresh();
            zedGraphControl1.Refresh();
        }
    }
}
