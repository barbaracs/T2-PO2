using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2_PO2.Auxiliares;

namespace T2_PO2.Métodos
{
    class Gradiente
    {
        /// <summary>
        /// Calcula o gradiente da função em determinado ponto.
        /// </summary>
        /// <param name="n">Número de variáveis.</param>
        /// <param name="fx">Função a ser calculado o gradiente.</param>
        /// <param name="x">Ponto a ser obtido o gradiente.</param>
        /// <returns>Retorna o valor do gradiente no ponto x.</returns>
        public static IEnumerable<double> CalculaGradiente(int n, string fx, double[] x)
        {
            for (int i = 0; i < n; i++)
            {
                yield return DerivadasMultivariaveis.Derivada1(n, fx, x, i);
            }
        }

        /// <summary>
        /// Minimiza F(x) utilizando o método do Gradiente.
        /// </summary>
        /// <param name="n">Número de variáveis.</param>
        /// <param name="fx">Função a ser minimizada.</param>
        /// <param name="e">Erro.</param>
        /// <param name="x_ini">X inicial.</param>
        /// <returns>Retorna o X ótimo.</returns>
        public static double[] Calcular(int n, string fx, double e, string x_ini)
        {
            int k = 0;
            double[] x = Interpretadores.SplitToDoubles(x_ini);
            double[] gradiente = CalculaGradiente(n, fx, x).ToArray();
            double[] d = new double[n];
            while (Math.Abs(Interpretadores.NormaVetor(gradiente)) >= e)
            {
                for (int i = 0; i < gradiente.Length; i++)
                {
                    d[i] = -gradiente[i];
                }
                string yj = Interpretadores.GeraVetorY(x, Interpretadores.LambdaVDirec(d));
                string f = Interpretadores.GeraFy(fx, yj);
                var lambda = Newton.Calcular(0, (f.Replace("lamb", "x[1]")).Replace(',','.'), 0.1);
                x = Interpretadores.SubsLambda(lambda, yj.Replace(',','.'));
                gradiente = CalculaGradiente(n, fx, x).ToArray();
                k += 1;
            }

            return x;
        }
    }
}
