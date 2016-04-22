using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopfield
{
    public static class HopfieldAlgorytm
    {
        public static int StaticIterator = 10;

        public static IEnumerable<Result> RunASynchronic(Vector x0, Vector w)
        {
            int i = 0, j = 0;
            List<Result> result = new List<Result>();
            Vector actualVector = x0.Transposition();

            while (i <= StaticIterator)
            {
                for (int k = 0; k < x0.NumberOfColumns; k++)
                {
                    double energy = CountEneryInTheASynchronicMehod(actualVector, w);
                    result.Add(new Result() { T = i, X = actualVector.Copy(), Energia = energy });

                    Vector nextVector = ActivationFunction((w * actualVector));
                    actualVector[k, 0] = nextVector[k, 0];
                }
                

                if (j < x0.NumberOfColumns - 1)
                {
                    j = j + 1;
                }
                else
                {
                    j = 0;
                }

                i = i + 1;
            }

            return result;
        }
       
        public static IEnumerable<Result> RunSynchronic(Vector x0, Vector w)
        {
            int i = 0, j = 0;
            List<Result> result = new List<Result>();
            Vector actualVector = x0.Transposition();

            while (i <= StaticIterator)
            {
                double energy = CountEneryInTheASynchronicMehod(actualVector, w);
                result.Add(new Result() { T = i, X = actualVector.Copy(), Energia = energy });

                Vector nextVector = ActivationFunction((w * actualVector));
                actualVector = nextVector;

                if (j < x0.NumberOfColumns - 1)
                {
                    j = j + 1;
                }
                else
                {
                    j = 0;
                }

                i = i + 1;
            }

            return result;
        }

        private static double CountEneryInTheASynchronicMehod(Vector x, Vector w)
        {
            double energia = 0;

            for (int i = 0; i < w.NumberOfRows; i++)
            {
                for (int j = 0; j < w.NumberOfColumns; j++)
                {
                    energia = energia + (w[i, j]*x[i, 0]*x[j, 0]);
                }
            }

            return -0.5 * energia;
        }

        private static Vector ActivationFunction(Vector m)
        {
            Vector m2 = new Vector(m.NumberOfRows, m.NumberOfColumns);
            for (int i = 0; i < m.NumberOfRows; i++)
            {
                for (int j = 0; j < m.NumberOfColumns; j++)
                {
                    m2[i, j] = m[i, j] > 0 ? 1 : 0;
                }
            }

            return m2;
        }


        private static double ActivationFunction(double m)
        {
            return m > 0 ? 1 : 0;
        }
    }
}
