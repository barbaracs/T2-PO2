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
            //string f = "(Euler^x[1])-x[1]^3+1";

            //var res = Newton.Calcular(-1, f, 0.01);
            //Console.WriteLine(res);

            //string f1 = "(x[1]-2)^4 + (x[1]-2x[2])^2";
            //string f2 = "x[1]^2-2x[1]x[2]+4x[2]^2";
            //var res1 = Gradiente.Calcular(2, f2, 0.1, "1 1");
            //foreach (var item in res1)
            //{
            //    Console.WriteLine(item);
            //}
            double[,] A = new double[2, 2] {
                { 3, 2 },
                { 1, 2 }
            };
            double[] B = new double[2]
            {
                10,
                5
            };
            //foreach (var item in NewtonMulti.SS(2, A, B))
            //{
            //    Console.WriteLine(item);
            //}
            //double[] x0 = new double[2] { 0, 2 };
            //string f3 = "2x[1]^2+2x[1]x[2]+x[2]^2+x[1]+x[2]";
            //var x = NewtonMulti.Calcular(2, f3, 0.1, "2 2");
            //double[,] M = new double[2, 2]
            //{
            //    { 2, 1 },
            //    { 1, 4 }
            //};
            //double[,] N = new double[2, 2]
            //{
            //    { 2, 2 },
            //    { 3, 4 }
            //};

            //var r = GradConjugado.MultMatriz(M, N);
            //for (int i = 0; i < r.GetLength(0); i++)
            //{
            //    for (int j = 0; j < r.GetLength(1); j++)
            //    {
            //        Console.WriteLine(r[i, j]);
            //    }
            //}

            //string f4 = "x[1]^2+3x[1]^3+2x[1]";
            //var asd = DerivadasMultivariaveis.Derivada2(1, f4, new double[1] { 0.5 }, 0);

            //double[,] Q = new double[2, 2]
            //{
            //    { 5, 1 },
            //    { 1, 2 }
            //};

            //double[] b = new double[2] { 24, 12 };

            //var t = GradConjugado.Calcular(2, 0.2, "0 0", Q, "24 12");
        }
    }
}
