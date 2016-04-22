using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopfield
{
    public class Result
    {
        public int T { get; set; }          //czas / kolejna iteracja
        public Vector X { get; set; }      //wektor wejściowy
        public double Energia { get; set; } //Energia w danym korku algorytmu

        //Poszczególne składowe wektroa wejściowego na potrzeby prezentacji wyniku
        public double X0 { get { return X[0, 0]; } }
        public double X1 { get { return X[1, 0]; } }
        public double X2 { get { return X[2, 0]; } }
    }
}
