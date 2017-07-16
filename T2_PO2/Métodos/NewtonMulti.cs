using Sistemas.Lineares;
using System;
using System.Linq;
using T2_PO2.Auxiliares;

namespace T2_PO2.Métodos
{
    class NewtonMulti
    {
        /// <summary>
        /// Calcula o Hessiano do ponto x.
        /// </summary>
        /// <param name="n">Ordem da função.</param>
        /// <param name="fx">Função.</param>
        /// <param name="x">Ponto a ser obtido hessiano.</param>
        /// <returns>Retorna hessiano.</returns>
        public static double[,] Hessiano(int n, string fx, double[] x)
        {
            double[,] Hess = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Hess[i, j] = DerivadasMultivariaveis.DerivadaParcial2(n, fx, x, i, j);
                }
            }
            return Hess;
        }

        public static double[] Calcular(int n, string fx, double e, string x_ini)
        {
            double[] xk = Interpretadores.SplitToDoubles(x_ini);
            double[] x = new double[n];
            for (int i = 0; i < x.Length; i++)
                x[i] = double.MaxValue;
            double[] Grad = Gradiente.CalculaGradiente(n, fx, xk).ToArray();
            double[] W;
            double[,] Hess;
            while (Math.Abs(Interpretadores.NormaVetor(Grad)) >= e)
            {
                Hess = Hessiano(n, fx, xk);
                for (int i = 0; i < Grad.Length; i++)
                {
                    Grad[i] = -Grad[i];
                }
                W = MétodosSistemasLineares.SistemaLinearTriangularSuperior(n, Hess, Grad);
                for (int i = 0; i < xk.Length; i++)
                    x[i] = xk[i];
                xk = Interpretadores.SomaVetor(xk, W);
                if (Interpretadores.NormaVetor(Interpretadores.SubtracaoVetor(xk, x)) <= e)
                    break;
                Grad = Gradiente.CalculaGradiente(n, fx, xk).ToArray();
            }
            return xk;
        }
    }
}
