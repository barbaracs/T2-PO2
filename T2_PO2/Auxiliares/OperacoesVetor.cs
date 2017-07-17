using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_PO2.Auxiliares
{
    static class OperacoesVetor
    {
        public static double[] ToVector(this double[,] m)
        {
            if (m.GetLength(0) == 1)
            {
                double[] result = new double[m.GetLength(1)];
                for (int i = 0; i < m.GetLength(1); i++)
                    result[i] = m[0, i];
                return result;
            }
            else if (m.GetLength(1) == 1)
            {
                double[] result = new double[m.GetLength(0)];
                for (int i = 0; i < m.GetLength(0); i++)
                    result[i] = m[i, 0];
                return result;
            }
            return null;
        }

        public static double[,] TranspVetor(this double[] v)
        {
            double[,] result = new double[1, v.Length];
            for (int i = 0; i < result.GetLength(1); i++)
                result[0, i] = v[i];
            return result;
        }

        public static double[,] ToMatriz(this double[] v)
        {
            double[,] result = new double[v.Length, 1];
            for (int i = 0; i < result.GetLength(0); i++)
                result[i, 0] = v[i];

            return result;
        }

        public static double[] MultConstante(this double[] v, double k)
        {
            double[] result = new double[v.Length];

            for (int i = 0; i < result.Length; i++)
                result[i] = v[i] * k;

            return result;
        }

        public static double[] Negativo(this double[] v)
        {
            double[] result = new double[v.Length];
            for (int i = 0; i < v.Length; i++)
                result[i] = -v[i];

            return result;
        }


        public static double[,] DivideConstante(this double[,] m, double k)
        {
            double[,] result = (double[,])m.Clone();
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    result[i, j] /= k;
            return result;
        }

        public static string ParaString(this double[] v)
        {
            string result = "";
            result += v[0];
            for (int i = 1; i < v.Length; i++)
            {
                result += " " + v[i];
            }
            Console.WriteLine(result);
            return result;
        }
    }

    static class Help
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source==null || action==null)
                throw new Exception("null");
            foreach (T element in source)
            {
                action(element);
            }
        }
    }
}
