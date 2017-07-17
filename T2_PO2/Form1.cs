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
using System.Reflection;

namespace T2_PO2
{
    public partial class Form1 : Form
    {
        enum Métodos
        {
            [Description("Coordenadas Cíclicas")]
            Coordenadas_Cíclicas,
            [Description("Hooke and Jeeves")]
            Hooke_and_Jeeves,
            [Description("Gradiente")]
            Gradiente,
            [Description("Newton")]
            Newton,
            [Description("Gradiente Conj. Gen.")]
            Gradiente_Conj_Gen,
            [Description("Fletcher and Reeves")]
            Fletcher_and_Reeves,
            [Description("Davidon-Fletcher-Powell")]
            Davidon_Fletcher_Powell
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }

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

            string f = "(x[1]-2)^4+(x[1]-2*x[2])^2";
            double[] xk = { 0, 3 };
            double erro = 0.01;
            Console.WriteLine(f);
            int n = 2;
            var t = HookeJeeves.Calcular(f, xk, erro, n);

            //double[] xk = { 0, 3 };
            //double erro = 0.01;
            //Console.WriteLine(f);
            //int n = 2;
            //var t = CoordCiclicas.Calcular(f, xk, erro, n);

            //Console.WriteLine(t[0]);
            //Console.WriteLine(t[1]);

            //string f = "x[1]^3-x[1]^2+2x[2]^2-2x[2]";
            //var t = FletcherReeves.Calcular(2, f, 0.01, "1 1");

            var t = DavidonFletcherPowell.Calcular(2, f, 0.1, "0 0");
        }

        Métodos tipo_selec;
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            
            foreach (var item in controle.Controls.OfType<GroupBox>())
            {
                item.Visible = false;
            }
            var obj_selec = flowSelect.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            obj_selec.Visible = true;
            string selected = obj_selec?.Text;

            tipo_selec = GetValueFromDescription<Métodos>(selected);
            switch (tipo_selec)
            {
                case Métodos.Coordenadas_Cíclicas:
                    ciclicasGroupBox.Visible = true;
                    break;
                case Métodos.Hooke_and_Jeeves:
                    hookeGroupBox.Visible = true;
                    break;
                case Métodos.Gradiente:
                    gradGroupBox.Visible = true;
                    break;
                case Métodos.Newton:
                    newtonGroupBox.Visible = true;
                    break;
                case Métodos.Gradiente_Conj_Gen:
                    gradConjGroupBox.Visible = true;
                    break;
                case Métodos.Fletcher_and_Reeves:
                    fletchGroupBox.Visible = true;
                    break;
                case Métodos.Davidon_Fletcher_Powell:
                    davGroupBox.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            switch (tipo_selec)
            {
                case Métodos.Coordenadas_Cíclicas:
                    var xotimo = CoordCiclicas.Calcular(funcCiclicasTextBox.Text, (x1CiclicasTextBox.Text).SplitToDoubles(), double.Parse(eCiclicasNumericUpDown.Value.ToString()), int.Parse(nCiclicasNumericUpDown.Value.ToString()));
                    xotimoCiclicasTextBox.Text = xotimo.ParaString();
                    break;
                case Métodos.Hooke_and_Jeeves:
                    string f = fHookeTextBox.Text;
                    string x1 = x1HookeTextBox.Text;
                    double err = double.Parse(eHookeNumericUpDown.Value.ToString());
                    int n = int.Parse(nHookeNumericUpDown.Value.ToString());
                    
                    break;
                case Métodos.Gradiente:
                    f = fGradTextBox.Text;
                    x1 = x1GradTextBox.Text;
                    err = double.Parse(eGradNumericUpDown.Value.ToString());
                    n = int.Parse(nGradNumericUpDown.Value.ToString());
                    xotimo = Gradiente.Calcular(n, f, err, x1);
                    xotimoGradTextBox.Text = xotimo.ParaString();
                    break;
                case Métodos.Newton:
                    break;
                case Métodos.Gradiente_Conj_Gen:
                    break;
                case Métodos.Fletcher_and_Reeves:
                    break;
                case Métodos.Davidon_Fletcher_Powell:
                    break;
                default:
                    break;
            }
        }
    }
}
