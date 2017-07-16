using System;

namespace Sistemas.Lineares
{
    /// <summary>
    /// Classe contendo métodos de suporte para o cálculo de sistemas lineares.
    /// </summary>
    public class Helpers
    {
        /// <summary>
        /// Calcula o determinante de uma matriz.
        /// </summary>
        /// <param name="ordem">Ordem da matriz.</param>
        /// <param name="matriz">Matriz a ser calculado o determinante.</param>
        /// <returns>Retorna o valor do determinante.</returns>
        public static double Determinante(int ordem, double[,] matriz)
        {
            double soma = 0;
            if (ordem != 1)
            {
                double[][,] matrixaux = new double[ordem][,];
                for (int o = 0; o < matrixaux.Length; o++)
                {
                    matrixaux[o] = new double[ordem - 1, ordem - 1];
                }
                int linha = -1, coluna = -1, qualmat = -1;
                int i = 0;
                //Processo para pegar matriz interior
                for (int k = 0; k < ordem; k++)
                {
                    qualmat++;
                    linha = coluna = -1;
                    for (int j = 1; j < ordem; j++)
                    {
                        linha++;
                        coluna = -1;
                        for (int w = 0; w < ordem; w++)
                        {
                            if (w != k)
                            {
                                coluna++;
                                matrixaux[qualmat][linha, coluna] = matriz[j, w];
                            }
                        }
                    }
                    soma += Math.Pow(-1, (i + 1) + (k + 1)) * matriz[i, k] * Determinante(ordem - 1, matrixaux[qualmat]);
                }
            }
            else
            {
                soma += matriz[0, 0];
            }
            return soma;
        }
    }

    /// <summary>
    /// Classe contendo métodos utilizados para resolver sistemas lineares.
    /// </summary>
    public static class MétodosSistemasLineares
    {
        /// <summary>
        /// Resolução de um sistema linear triangular superior. 
        /// (Números no triângulo superior, zeros no triângulo inferior.)
        /// </summary>
        /// <param name="ordem">Ordem da matriz.</param>
        /// <param name="matrizA">Matriz dos coeficientes.</param>
        /// <param name="vetorB">Vetor dos termos independentes.</param>
        /// <returns>Retorna vetor solução.</returns>
        public static double[] SistemaLinearTriangularSuperior(int ordem, double[,] matrizA, double[] vetorB)
        {
            double[] vetorX = new double[ordem];
            matrizA = TrianguloSuperior(ordem, matrizA, vetorB);
            if (Helpers.Determinante(ordem, matrizA) != 0)
            {
                for (int i = vetorB.Length - 1; i >= 0; i--)
                {
                    double soma = 0;
                    for (int j = i + 1; j < vetorB.Length; j++)
                    {
                        soma += matrizA[i, j] * vetorX[j];
                    }
                    vetorX[i] = (vetorB[i] - soma) / matrizA[i, i];
                }
            }
            else
            {
                throw new Exception("Erro no calculo do determinante");
            }
            return vetorX;

        }

        /// <summary>
        /// Deixa a matriz no estilo triangulo superior.
        /// </summary>
        /// <param name="n">Ordem da matriz.</param>
        /// <param name="matriz">Matriz a ser utilizada.</param>
        /// <param name="b">Vetor b.</param>
        /// <returns>Matriz pronta para usar sts.</returns>
        private static double[,] TrianguloSuperior(int n, double[,] matriz, double[] b)
        {
            double m = 0;
            for (int j = 0; j < n - 1; j++)
            {
                for (int i = j + 1; i < n; i++)
                {
                    try
                    {
                        m = matriz[i, j] / matriz[j, j];
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    for (int k = j; k < n; k++)
                    {
                        matriz[i, k] = matriz[i, k] - m * matriz[j, k];
                    }

                    b[i] = b[i] - m * b[j];
                }
            }

            return matriz;
        }
    }
}
