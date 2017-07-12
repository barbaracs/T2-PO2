using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using info.lundin.math;
using T1_PO2.Métodos;

namespace T2_PO2.Métodos
{
    public class CoordCiclicas
    {
        Newton minimiza = new Newton();
        public void Calcular(string func, double[] xk, double erro, int n)
        {
            minimiza.infos.func = func;
            minimiza.infos.a = xk[n-1];
            minimiza.infos.e = erro;
            int k = 0;
            double[] d, xk, xk1;
            string yj, yj1, funcyj;
            do
            {
                k++;
                yj = xk;
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
                yj = fazyj();
                lamb = Newton(gerafunc(yj), xk[n-j], erro);
                yj = calcyj(lamb);
                xk1 = yj1;
            } while ((xk1 - xk) < erro);
        }
    }
}
