using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using info.lundin.math;
using T1_PO2.Métodos;
using T2_PO2.Auxiliares;

namespace T2_PO2.Métodos
{
    public class CoordCiclicas
    {
        Newton minimiza = new Newton();
        public static double[] Calcular(string func, double[] xk, double erro, int n)
        {
            int k = 0;
            double[] d, yk, valorAnt, valorFim, vetNorma;
            d = new double[n];
            valorAnt = new double[n];
            valorFim = new double[n];
            vetNorma = new double[n];
            double? lambda, valorNorma = 100000;
            string l_direc, vetYj, Fy;
            do
            {   
                /*Copia o ultimo vetor yk+1 calculado para poder calcular a norma no final*/
                for (int i = 0; i < n; i++)
                {
                    valorAnt[i] = valorFim[i];
                }
                /**/
                k++;
                yk = xk;
                for (int l = 0; l < n; k++)
                {
                    /*Monta o vetor d*/
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            d[j] = 0;
                        }
                        d[i] = 1;
                    }
                    /**/
                    l_direc = Interpretadores.LambdaVDirec(d);             //calcula o vetor lambda*direcao
                    vetYj = Interpretadores.GeraVetorY(yk, l_direc);       //Gera vetor Yj para calcular o valor de lambda
                    Fy = Interpretadores.GeraFy(func, vetYj);              //Gera a função com lambda substituído nos x corretos 
                    minimiza.infos.func = Fy;
                    minimiza.infos.a = xk[n - 1];
                    minimiza.infos.e = erro;
                    lambda = minimiza.Calcular();                          //valor do lambda pra ser substituído
                    valorFim = Interpretadores.SubsLambda((double)lambda, Fy);  //valor final do Y
                    vetNorma = Interpretadores.SubtracaoVetor(valorFim, valorAnt);
                    valorNorma = Interpretadores.NormaVetor(vetNorma);
                }
            } while ((valorNorma) < erro);
            return valorFim;
        }
    }
}