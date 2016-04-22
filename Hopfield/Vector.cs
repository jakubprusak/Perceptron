using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopfield
{
    public class Vector
    {
        private readonly double[,] _mother = null;

        public Vector(int numberOfrows, int numberOfColumns)
        {
            this._mother = new double[numberOfrows, numberOfColumns];
        }

        public int NumberOfRows
        {
            get { return this._mother.GetLength(0); }
        }

        public int NumberOfColumns
        {
            get { return this._mother.GetLength(1); }
        }

        public double this[int i, int j]
        {
            get { return this._mother[i, j]; }

            set { this._mother[i, j] = value; }
        }

        public static Vector operator *(Vector m1, Vector m2)
        {
            Vector result = new Vector(m1.NumberOfRows, m2.NumberOfColumns);

            for (int i = 0; i < m1.NumberOfRows; i++)
            {
                for (int j = 0; j < m2.NumberOfColumns; j++)
                {
                    double suma = 0;

                    for (int k = 0; k < m1.NumberOfColumns; k++)
                    {
                        suma += m1[i, k]*m2[k, j];
                    }

                    result[i, j] = suma;
                }
            }

            return result;
        }

        public double Wartosc(int i, int j)
        {
            return this[i, j];
        }

        public static Vector operator *(double s, Vector m)
        {
            Vector wynik = new Vector(m.NumberOfRows, m.NumberOfColumns);

            for (int i = 0; i < m.NumberOfRows; i++)
            {
                for (int j = 0; j < m.NumberOfColumns; j++)
                {
                    wynik[i, j] = s*m[i, j];
                }
            }

            return wynik;
        }

        public static Vector operator *(Vector m, double s)
        {
            Vector wynik = new Vector(m.NumberOfRows, m.NumberOfColumns);

            for (int i = 0; i < m.NumberOfRows; i++)
            {
                for (int j = 0; j < m.NumberOfColumns; j++)
                {
                    wynik[i, j] = s*m[i, j];
                }
            }

            return wynik;
        }

        public static Vector operator +(Vector m1, Vector m2)
        {

            Vector result = new Vector(m1.NumberOfRows, m1.NumberOfColumns);

            for (int i = 0; i < m1.NumberOfRows; i++)
            {
                for (int j = 0; j < m1.NumberOfColumns; j++)
                {
                    result[i, j] = m1[i, j] + m2[i, j];
                }
            }

            return result;
        }

        public static Vector operator -(Vector m1, Vector m2)
        {

            Vector wynik = new Vector(m1.NumberOfRows, m1.NumberOfColumns);

            for (int i = 0; i < m1.NumberOfRows; i++)
            {
                for (int j = 0; j < m1.NumberOfColumns; j++)
                {
                    wynik[i, j] = m1[i, j] - m2[i, j];
                }
            }

            return wynik;
        }

        public static bool operator ==(Vector m1, Vector m2)
        {

            for (int i = 0; i < m1.NumberOfRows; i++)
            {
                for (int j = 0; j < m1.NumberOfColumns; j++)
                {
                    if (m1[i, j] != m2[i, j])
                        return false;
                }
            }

            return true;
        }

        public static bool operator !=(Vector m1, Vector m2)
        {

            for (int i = 0; i < m1.NumberOfRows; i++)
            {
                for (int j = 0; j < m1.NumberOfColumns; j++)
                {
                    if (m1[i, j] != m2[i, j])
                        return true;
                }
            }

            return false;
        }

        public Vector Row(int indeks)
        {
            Vector m = new Vector(1, this.NumberOfColumns);

            for (int i = 0; i < this.NumberOfColumns; i++)
            {
                m[0, i] = this[indeks, i];
            }

            return m;
        }

        public Vector Column(int indeks)
        {
            Vector m = new Vector(this.NumberOfRows, 1);

            for (int i = 0; i < this.NumberOfRows; i++)
            {
                m[i, 0] = this[i, indeks];
            }

            return m;
        }

        public Vector Transposition()
        {
            Vector transponowana = new Vector(this.NumberOfColumns, this.NumberOfRows);

            for (int i = 0; i < this.NumberOfRows; i++)
            {
                for (int j = 0; j < this.NumberOfColumns; j++)
                {
                    transponowana[j, i] = this[i, j];
                }
            }

            return transponowana;
        }

        public Vector Copy()
        {
            Vector m = new Vector(this.NumberOfRows, this.NumberOfColumns);

            for (int i = 0; i < this.NumberOfRows; i++)
            {
                for (int j = 0; j < this.NumberOfColumns; j++)
                {
                    m[i, j] = this[i, j];
                }
            }

            return m;
        }
    }
}
