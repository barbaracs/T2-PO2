using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2_PO2.Auxiliares;

namespace T2_PO2.Métodos
{
    class DavidonFletcherPowell
    {
        public static double[,] MatrizSimetricaPositivaDefinida(int n)
        {
            double[,] m = new double[n, n];
            for (int i = 0; i < n; i++)
                m[i,i] = 1;
            return m;
        }

        public static double[,] SomaMatriz(double[,] m, double[,] n)
        {
            double[,] result = (double[,])m.Clone();
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    result[i,j] += n[i, j];

            return result;
        }

        public static double[,] SubtracaoMatriz(double[,] m, double[,] n)
        {
            double[,] result = (double[,])m.Clone();
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    result[i, j] -= n[i, j];

            return result;
        }

        public static double[] Calcular(int n, string fx, double e, string x_ini)
        {
            double[] x0 = x_ini.SplitToDoubles();
            double[] xk;
            double[] gk = (double[])Gradiente.CalculaGradiente(n, fx, x0).ToArray().Clone();
            double[] gk_1;
            double[] dk;
            double[] qk;
            double[] pk;
            double[] xi;
            double lambdak;
            double[,] Sk = MatrizSimetricaPositivaDefinida(n);
            int k, i;
            k = i = 0;
            volta:
            xk = (double[])x0.Clone();
            while (Interpretadores.NormaVetor(gk) > e)
            {
                dk = GradConjugado.MultMatriz(Sk, gk.ToMatriz()).ToVector().Negativo();

                string vy = Interpretadores.GeraVetorY(xk, Interpretadores.LambdaVDirec(dk));
                string fy = Interpretadores.GeraFy(fx, vy.Replace(',', '.')).Replace("lamb", "x[1]");
                lambdak = Newton.Calcular(3, fy , 0.1);

                xk = Interpretadores.SubsLambda(lambdak, vy.Replace(',', '.'));

                if(k < n - 1)
                {
                    gk_1 = Gradiente.CalculaGradiente(n, fx, xk).ToArray();

                    qk = Interpretadores.SubtracaoVetor(gk_1, gk);

                    pk = dk.MultConstante(lambdak);


                    var parte1 = GradConjugado.MultMatriz(pk.ToMatriz(), pk.TranspVetor()).DivideConstante(GradConjugado.MultEscalar(pk, qk));
                    var parte2 = GradConjugado.MultMatriz(GradConjugado.MultMatriz(GradConjugado.MultMatriz(Sk, qk.ToMatriz()), qk.TranspVetor()), Sk).DivideConstante(GradConjugado.MultEscalar((GradConjugado.MultMatriz(qk.TranspVetor(), Sk)).ToVector(), qk));

                    Sk = SubtracaoMatriz(SomaMatriz(Sk, parte1), parte2);

                    k += 1;
                    gk = (double[])gk_1.Clone();
                }
                else
                {
                    xi = (double[])xk.Clone();
                    i += 1;
                    x0 = (double[])xk.Clone();
                    gk = Gradiente.CalculaGradiente(n, fx, x0).ToArray();
                    k = 0;
                    goto volta;
                }
            }
            return xk;
        }
    }
}
