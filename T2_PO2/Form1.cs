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
using T1_PO2;
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
            string func = "(x[1]-2)^4+(x[1]-2*x[2])^2";
            double[] xk = (new double[2] { 0, 3 });
            double erro = 0.01;
            int n = 2;
            double[] teste = CoordCiclicas.Calcular(func, xk, erro, n);
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine(teste[i] + "/n");
            }
        }
    }
}
