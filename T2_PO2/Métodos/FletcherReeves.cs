using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2_PO2.Auxiliares;

namespace T2_PO2.Métodos
{
    class FletcherReeves
    {
        public static double[] Calcular(int n, string fx, double e, string x_ini)
        {
            double[] xk = x_ini.SplitToDoubles();
            double[] grad = Gradiente.CalculaGradiente(n, fx, x_ini.SplitToDoubles()).ToArray();
            double[] gk = (double[])grad.Clone();
            double[] gk_1;
            double[] dk = gk.Negativo();
            double beta;
            while (Interpretadores.NormaVetor(grad) > e)
            {
                for (int i = 0; i < n; i++)
                {
                    string xk_s = Interpretadores.GeraVetorY(xk,Interpretadores.LambdaVDirec(dk));
                    double lamb = Newton.Calcular(0, ((Interpretadores.GeraFy(fx, xk_s)).Replace(',','.')).Replace("lamb","x[1]"), 0.1);

                    xk = Interpretadores.SubsLambda(lamb, xk_s.Replace(',', '.'));
                    gk_1 = Gradiente.CalculaGradiente(n, fx, xk).ToArray();
                    if (i >= n - 1)
                        break;
                    beta = GradConjugado.MultEscalar(gk_1, gk_1) / GradConjugado.MultEscalar(gk, gk);
                    dk = Interpretadores.SomaVetor(gk_1.Negativo(), dk.MultConstante(beta));
                    gk = (double[])gk_1.Clone();
                }
                grad = Gradiente.CalculaGradiente(n, fx, xk).ToArray();
            }
            return xk;
        }
    }
}
