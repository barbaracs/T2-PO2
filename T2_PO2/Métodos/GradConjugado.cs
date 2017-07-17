using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2_PO2.Auxiliares;

namespace T2_PO2.Métodos
{
    class GradConjugado
    {
        public static double[,] MultMatriz(double[,] m, double[,] n)
        {
            if (m.GetLength(1) != n.GetLength(0))
                return null;
            double[,] res = new double[m.GetLength(0), n.GetLength(1)];

            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < n.GetLength(1); j++)
                    for (int k = 0; k < n.GetLength(0); k++)
                        res[i,j] += m[i, k] * n[k, j];

            return res;
        }

        public static double MultEscalar(double[] a, double[] b)
        {
            double result = 0;
            for (int i = 0; i < a.Length; i++)
                result += a[i] * b[i];
            return result;
        }

        public static double[] Calcular(int n, double e, string fx,string x_ini)
        {
            var aux = Interpretadores.SplitToDoubles(x_ini);
            double[,] xk = new double[n, 1];
            double[] xk_1 = (double[])xk.ToVector().Clone();
            double[] gk = new double[n];
            double[] gk_1 = new double[n];
            double[] dk = new double[n];
            double[] dk_1 = new double[n];
            double[,] Hess;
            double lambda, beta;
            //Passa x_ini para matriz para poder multiplicar
            for (int i = 0; i < xk.GetLength(0); i++)
                xk[i, 0] = aux[i];
            //g0
            Passo1:
            gk = Gradiente.CalculaGradiente(n, fx, xk.ToVector()).ToArray();
            gk_1 = (double[])gk.Clone();
            for (int i = 0; i < gk.Length; i++)
                dk[i] = -gk[i];
            for (int k = 0; k < n; k++)
            {
                Hess = NewtonMulti.Hessiano(2, fx, xk.ToVector());
                double[,] dk_transp = dk.TranspVetor();
                double[,] dk_Hess = MultMatriz(dk_transp, Hess);
                double[] dk_H_assist = dk_Hess.ToVector();

                lambda = -(MultEscalar(gk, dk) / MultEscalar(dk_H_assist, dk));

                xk_1 = Interpretadores.SomaVetor(xk.ToVector(), dk.MultConstante(lambda));
                gk_1 = Gradiente.CalculaGradiente(n, fx, xk_1).ToArray();

                if (k == n - 1)
                    if (Interpretadores.NormaVetor(gk_1) <= e)
                        break;
                    else
                    {
                        for (int i = 0; i < xk.Length; i++)
                            xk[i, 0] = xk_1[i];
                        goto Passo1;
                    }
                beta = MultEscalar(MultMatriz(gk_1.TranspVetor(), Hess).ToVector(), dk) / MultEscalar(dk_H_assist, dk);
                dk_1 = Interpretadores.SomaVetor(gk_1.Negativo(), dk.MultConstante(beta));
                
                dk = (double[])dk_1.Clone();
                gk = (double[])gk_1.Clone();
                for (int i = 0; i < xk.Length; i++)
                    xk[i, 0] = xk_1[i];
            }
            return xk_1;
        }
    }
}
