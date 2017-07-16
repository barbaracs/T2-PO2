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
            string f = "(Euler^x[1])-x[1]^3+1";

            var res = Newton.Calcular(-1, f, 0.01);
            Console.WriteLine(res);

            string f1 = "(x[1]-2)^4 + (x[1]-2x[2])^2";
            string f2 = "x[1]^2-2x[1]x[2]+4x[2]^2";
            var res1 = Gradiente.Calcular(2, f2, 0.1, "1 1");
            foreach (var item in res1)
            {
                Console.WriteLine(item);
            }
        }
    }
}
