using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using info.lundin.math;

namespace T2_PO2.Auxiliares
{
    class Interpretadores
    {
        /// <summary>
        /// Calcula a norma do vetor fornecido.
        /// </summary>
        /// <param name="vetor"></param>
        /// <returns></returns>
        public static double NormaVetor(double[] vetor)
        {
            double resultado = 0;
            for (int i = 0; i < vetor.Length; i++)
            {
                resultado += Math.Pow(vetor[i], 2);
            }
            return Math.Sqrt(resultado);
        }

        /// <summary>
        /// Subtrai vetor x de y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double[] SubtracaoVetor(double[] x, double[] y)
        {
            double[] resultado = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                resultado[i] = x[i] - y[i];
            }
            return resultado;
        }

        /// <summary>
        /// Substitui o valor encontrado para lambda no vetor Y e retorna o vetor
        /// </summary>
        /// <param name="lambda">Valor minimizado</param>
        /// <param name="yj">Vetor Yj</param>
        /// <returns></returns>
        public static double[] SubsLambda(double lambda, string yj)
        {
            ExpressionParser parser = new ExpressionParser();
            parser.Values.Add("lamb", lambda);
            string[] splited = SplitToStrings(yj);
            double[] resultado = new double[splited.Length];

            for (int i = 0; i < splited.Length; i++)
            {
                resultado[i] = parser.Parse(splited[i]);
            }

            return resultado;
        }

        /// <summary>
        /// Gera F(yj) que sera minimizada para encontrar lambda.
        /// </summary>
        /// <param name="fx">F(x) onde x é um vetor do Rn.</param>
        /// <param name="vety">Vetor y gerado dado uma direção.</param>
        /// <returns></returns>
        public static string GeraFy(string fx, string vety)
        {
            string[] y = SplitToStrings(vety);
            for (int i = 0; i < y.Length; i++)
            {
                fx = fx.Replace("x[" + i.ToString() + "]", "(" + y[i] + ")");
            }
            return fx;
        }

        /// <summary>
        /// Separa a string que representa um vetor transposto em um vetor.
        /// </summary>
        /// <param name="vector">Vetor transposto a ser separado.</param>
        /// <returns></returns>
        public static string[] SplitToStrings(string vector)
        {
            return vector.Split(' ');
        }

        /// <summary>
        /// Função que retorna lamda multiplicado por uma direção dada.
        /// </summary>
        /// <param name="dj">Direção</param>
        /// <returns></returns>
        public static string LambdaVDirec(double[] dj)
        {
            string resultado = "";
            for (int i = 0; i < dj.Length; i++)
            {
                resultado += i == 0 ? dj[i].ToString() + "*lamb" : " " + dj[i].ToString() + "*lamb";
            }
            return resultado;
        }

        /// <summary>
        /// Gera vetor Yj dado uma direção*lambda.
        /// </summary>
        /// <param name="yj">yj anterior</param>
        /// <param name="vetorLambDirec">Gerado a partir de dj e lambda</param>
        /// <returns></returns>
        public static string GeraVetorY(double[] yj ,string vetorLambDirec)
        {
            string resultado = "";
            string[] vetorSplit = SplitToStrings(vetorLambDirec);
            for (int i = 0; i < yj.Length; i++)
            {
                resultado += i == 0 ? yj[i].ToString() + "+" + vetorSplit[i] : " " + yj[i].ToString() + "+" + vetorSplit[i];
            }
            return resultado;
        }
    }
}
