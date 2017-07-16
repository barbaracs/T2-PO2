using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using info.lundin.math;
using T2_PO2.Auxiliares;
using T2_PO2.Métodos;

namespace T2_PO2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calcDavButton_Click(object sender, EventArgs e)
        {
            string f = "(x[1]-2)^4+(x[1]-2*x[2])^2";
            double[] xk = {0, 3};
            double erro = 0.01;
            Console.WriteLine(f);
            int n = 2;
            var t = CoordCiclicas.Calcular(f, xk, erro, n);
            
            Console.WriteLine(t[0]);
            Console.WriteLine(t[1]);

        }
    }
}
