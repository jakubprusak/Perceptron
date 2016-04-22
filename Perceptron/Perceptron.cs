using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    public class Perceptron
    {
        List<VectorData> _vectorSheet;
        private int _iteration;
        private int _correctAnswers;
        private float _weight1;
        private float _weight2;
        private bool _ready;
        private const float Threshold = 0.5F;
        private const float Correction = 0.2F;


        public List<VectorData> VectorSheet
        {
            get
            {
                return this._vectorSheet;
            }
            set
            {
                _vectorSheet = value;
            }
        }


        public float Weight1
        {
            get
            {
                return this._weight1;
            }
        }


        public float Weight2
        {
            get
            {
                return this._weight2;
            }
        }

        public bool Ready
        {
            get
            {
                return this._ready;
            }
            set
            {
                _ready = value;
            }
        }



        public Perceptron()
        {
            _vectorSheet = new List<VectorData>();
            _iteration = 0;
            _weight1 = 0.1F;
            _weight2 = 0.1F;
            _ready = false;
            _correctAnswers = 0;
        }

        public void Train()
        {
            if (_iteration == _vectorSheet.Count)
            {
                _iteration = 0;
                _correctAnswers = 0;
            }
            float sum = (_vectorSheet[_iteration].input_1 * _weight1) + (_vectorSheet[_iteration].input_2 * _weight2);
            int output = (sum >= Threshold) ? 1 : 0;
            bool changes = false;
            if (output != _vectorSheet[_iteration].output)
            {
                if (_vectorSheet[_iteration].input_1 == 1)
                    _weight1 += Correction;
                if (_vectorSheet[_iteration].input_2 == 1)
                    _weight2 += Correction;
                changes = true;
                _correctAnswers -= 1;
            }
            else
            {
                _correctAnswers++;
                if (_correctAnswers == _vectorSheet.Count)
                    _ready = true;
            }
            Dump(output, changes);
            _iteration++;
        }

        public int Ask(uint input_1, uint input_2)
        {
            float sum = (input_1 * _weight1) + (input_2 * _weight2);
            int output = (sum >= Threshold) ? 1 : 0;
            return output;
        }

        private void Dump(int output, bool changes)
        {
            Console.WriteLine("Iteracja: " + _iteration);
            Console.WriteLine("\tInput 1: " + _vectorSheet[_iteration].input_1);
            Console.WriteLine("\tInput 2: " + _vectorSheet[_iteration].input_2);
            Console.WriteLine("\tOczekiwany wynik: " + _vectorSheet[_iteration].output);
            Console.WriteLine("\tWynik perceptronu: " + output);
            Console.WriteLine("\tzmienione wagi: " + (changes ? "Yes" : "No"));
            if (changes)
            {
                Console.WriteLine("\t\twaga 1: " + _weight1);
                Console.WriteLine("\t\twaga 2: " + _weight2);
            }
        }
    }
}
