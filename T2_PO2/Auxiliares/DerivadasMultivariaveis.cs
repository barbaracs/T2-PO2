using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using info.lundin.math;

namespace T2_PO2.Auxiliares
{
    class DerivadasMultivariaveis
    {
        /// <summary>
        /// Calcula a primeira derivada no ponto x.
        /// </summary>
        /// <param name="n">Quantidade de variáveis.</param>
        /// <param name="fx">Função a ser derivada.</param>
        /// <param name="x">Ponto a ser calculada a derivada.</param>
        /// <param name="k">Variável a ser derivada.</param>
        /// <returns>Retorna o valor da derivada no ponto x</returns>
        public static double Derivada1(int n, string fx, double[] x,int k)
        {
            //Necessário para o interpretador de funções
            fx = Interpretadores.RemoveChaves(fx);
            ExpressionParser parser = new ExpressionParser();
            //Cria vetor X para ser interpretado
            DoubleValue[] X = new DoubleValue[n];
            for (int i = 0; i < X.Length; i++)
            {
                X[i] = new DoubleValue();
                X[i].Value = x[i];
                parser.Values.Add("x"+(i+1), X[i]);
            }

            double h = 0.5;
            double fx_linha = 0, auxfx_linha = 0, f1, f2;

            do
            {
                auxfx_linha = fx_linha;
                X[k].Value = x[k] + h;
                f1 = parser.Parse(fx);
                X[k].Value = x[k] - h;
                f2 = parser.Parse(fx);
                fx_linha = (f1 - f2) / (2 * h);
                h /= 2;
            } while (Math.Abs(fx_linha - auxfx_linha) > 0.00001);

            return fx_linha;
        }

        /// <summary>
        /// Calcula a segunda derivada no ponto x.
        /// </summary>
        /// <param name="n">Quantidade de variáveis.</param>
        /// <param name="fx">Função a ser derivada.</param>
        /// <param name="x">Ponto a ser calculada a derivada.</param>
        /// <param name="k">Variável a ser derivada.</param>
        /// <returns>Retorna o valor da derivada no ponto x</returns>
        public static double Derivada2(int n, string fx, double[] x, int k)
        {
            //Necessário para o interpretador de funções
            fx = Interpretadores.RemoveChaves(fx);
            ExpressionParser parser = new ExpressionParser();
            //Cria vetor X para ser interpretado
            DoubleValue[] X = new DoubleValue[n];
            for (int i = 0; i < X.Length; i++)
            {
                X[i] = new DoubleValue();
                X[i].Value = x[i];
                parser.Values.Add("x" + (i + 1), X[i]);
            }

            double h = 0.5;
            double fx_linha = 0, auxfx_linha = 0, f1, f2, f3;

            do
            {
                auxfx_linha = fx_linha;
                X[k].Value = x[k] + (2 * h);
                f1 = parser.Parse(fx);
                X[k].Value = x[k];
                f2 = parser.Parse(fx);
                X[k].Value = x[k] - (2 * h);
                f3 = parser.Parse(fx);

                fx_linha = (f1 - (2 * f2) + f3) / (4 * Math.Pow(h, 2));
                h /= 2;
            } while ((Math.Abs(fx_linha - auxfx_linha)) > 0.00001);

            return fx_linha;
        }

        public static double DerivadaParcial2(int n, string fx, double[] x, int k, int j)
        {
            fx = Interpretadores.RemoveChaves(fx);
            ExpressionParser parser = new ExpressionParser();
            //Cria vetor X para ser interpretado
            DoubleValue[] X = new DoubleValue[n];
            for (int i = 0; i < X.Length; i++)
            {
                X[i] = new DoubleValue();
                X[i].Value = x[i];
                parser.Values.Add("x" + (i + 1), X[i]);
            }

            if (k == j)
            {
                double h = 0.5;
                double fx_linha = 0, auxfx_linha = 0, f1, f2, f3;

                do
                {
                    auxfx_linha = fx_linha;
                    X[k].Value = x[k] + 2 * h;
                    f1 = parser.Parse(fx);
                    X[k].Value = x[k];
                    f2 = parser.Parse(fx);
                    X[k].Value = x[k] - 2 * h;
                    f3 = parser.Parse(fx);
                    fx_linha = (f1 - 2*f2 + f3) / (4 * h * h);
                    h /= 2;
                } while (Math.Abs(fx_linha - auxfx_linha) > 0.0000001);

                return fx_linha;
            }
            else
            {
                double h = 0.5;
                double fx_linha = 0, auxfx_linha = 0, f1, f2, f3, f4;

                do
                {
                    auxfx_linha = fx_linha;
                    X[k].Value = x[k] + h;
                    X[j].Value = x[j] + h;
                    f1 = parser.Parse(fx);
                    X[k].Value = x[k] - h;
                    X[j].Value = x[j] + h;
                    f2 = parser.Parse(fx);
                    X[k].Value = x[k] + h;
                    X[j].Value = x[j] - h;
                    f3 = parser.Parse(fx);
                    X[k].Value = x[k] - h;
                    X[j].Value = x[j] - h;
                    f4 = parser.Parse(fx);
                    fx_linha = (f1 - f2 - f3 + f4) / (4 * h * h);
                    h /= 2;
                } while (Math.Abs(fx_linha - auxfx_linha) > 0.0000001);

                return fx_linha;
            }
        }
    }
}
