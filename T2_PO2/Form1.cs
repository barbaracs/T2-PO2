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
using T1_PO2.Métodos;
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
            var lambdir = Interpretadores.LambdaVDirec(new double[3] { 0, 1, 2 });
            var y = Interpretadores.GeraVetorY(new double[3] { 5, 4, 3 }, lambdir);
            var fx = "x[1]^2+(x[1]*x[2])^2";
            var fy = Interpretadores.GeraFy(fx, y);
            Console.WriteLine(y);
            Console.WriteLine(Interpretadores.SubsLambda(2, y));
        }
    }
}
