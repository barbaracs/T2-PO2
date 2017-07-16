using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using info.lundin.math;
using T2_PO2.Auxiliares;

namespace T2_PO2.Métodos
{
    public class CoordCiclicas
    {
        public static double[] Calcular(string func, double[] xk, double erro, int n)
        {
            int k = 0;
            double lambda, norma = 1000;
            double[] d, yk, vetNorma, x;
            vetNorma = new double[n];
            d = new double[n];
            yk = new double[n];
            string lambdaD, vetYj, Fy;
            do
            {
                k++;
                x = (double[])xk.Clone();
                yk = (double[])xk.Clone();
                for (int j = 0; j < n; j++)
                {
                    /*Monta o vetor d*/
                    for (int b = 0; b < n; b++)
                        {
                            d[b] = 0;
                        }
                    d[j] = 1;
                    /**/
                    //multiplica lambda por d
                    lambdaD = Interpretadores.LambdaVDirec(d);
                    //vetor lambda*d + vetor yk
                    vetYj = Interpretadores.GeraVetorY(yk, lambdaD);
                    //substitui lambda por x nos lugares corretos -> Fy só com lambda de variável
                    Fy = Interpretadores.GeraFy(func, vetYj.Replace(',', '.'));
                    //Newton para calcular o valor de lambda
                    lambda = Newton.Calcular(0, (Fy.Replace("lamb", "x[1]")).Replace(',', '.'), 0.1);
                    //substitui o valor de lambda na função Fy -> gera vetor xk novo
                    yk = Interpretadores.SubsLambda(lambda, vetYj.Replace(',','.'));
                }
                xk = (double[])yk.Clone();
                vetNorma = Interpretadores.SubtracaoVetor(xk, x);
                //resultado da norma
                norma = Interpretadores.NormaVetor(vetNorma);
            } while (norma > erro);
            return xk;
        }
    }
}
