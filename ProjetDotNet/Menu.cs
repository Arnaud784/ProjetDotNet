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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graph graph = new Graph();
            graph.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Filtre filtre = new Filtre();
            filtre.ShowDialog();
        }
    }
}
