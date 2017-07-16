using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1_PO2.Helpers;

namespace T2_PO2.Auxiliares
{
    class Newton : DerivadasMultivariaveis
    {
        public static double Calcular(double a, string func, double ep)
        {
            //Derivadas re = new Derivadas();
            double xk = a;
            double x;
            double parada = 1000;
            //re.infos.a = xk;
            //re.infos.func = func;
            //re.infos.e = 0.01;
            //var resul = re.Derivada_1(xk);
            while (Math.Abs(Derivada1(1, func, new double[1] { xk }, 0)) > ep && parada > ep)
            {
                x = xk;
                double der1 = Derivada1(1, func, new double[1] { x }, 0);
                double der2 = Derivada2(1, func, new double[1] { x }, 0);
                if (der2 != 0)
                    xk = x - (der1 / der2);
                else
                {
                    Console.WriteLine("Erro inesperado! Divisão por 0.");
                    throw new Exception("div 0");
                }
                parada = (Math.Abs(xk - x)) / (Math.Abs(xk) > 1 ? Math.Abs(xk) : 1);
            }

            return xk;
        }
    }
}
