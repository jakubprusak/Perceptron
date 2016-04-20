using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    public class Perceptron
    {
        List<Data> vectorSheet;
        private int iteration;
        private int correctAnswers;
        private float weight_1;
        private float weight_2;
        private bool ready;
        private const float threshold = 0.5F;
        private const float correction = 0.2F;


        public List<Data> VectorSheet
        {
            get
            {
                return this.vectorSheet;
            }
            set
            {
                vectorSheet = value;
            }
        }


        public float Weight1
        {
            get
            {
                return this.weight_1;
            }
        }


        public float Weight2
        {
            get
            {
                return this.weight_2;
            }
        }

        public bool Ready
        {
            get
            {
                return this.ready;
            }
            set
            {
                ready = value;
            }
        }



        public Perceptron()
        {
            vectorSheet = new List<Data>();
            iteration = 0;
            weight_1 = 0.1F;
            weight_2 = 0.1F;
            ready = false;
            correctAnswers = 0;
        }

        public void Train()
        {
            if (iteration == vectorSheet.Count)
            {
                iteration = 0;
                correctAnswers = 0;
            }
            float sum = (vectorSheet[iteration].input_1 * weight_1) + (vectorSheet[iteration].input_2 * weight_2);
            int output = (sum >= threshold) ? 1 : 0;
            bool changes = false;
            if (output != vectorSheet[iteration].output)
            {
                if (vectorSheet[iteration].input_1 == 1)
                    weight_1 += correction;
                if (vectorSheet[iteration].input_2 == 1)
                    weight_2 += correction;
                changes = true;
                correctAnswers -= 1;
            }
            else
            {
                correctAnswers++;
                if (correctAnswers == vectorSheet.Count)
                    ready = true;
            }
            Dump(output, changes);
            iteration++;
        }

        public int Ask(uint input_1, uint input_2)
        {
            float sum = (input_1 * weight_1) + (input_2 * weight_2);
            int output = (sum >= threshold) ? 1 : 0;
            return output;
        }

        private void Dump(int output, bool changes)
        {
            Console.WriteLine("Iteration: " + iteration);
            Console.WriteLine("\tInput 1: " + vectorSheet[iteration].input_1);
            Console.WriteLine("\tInput 2: " + vectorSheet[iteration].input_2);
            Console.WriteLine("\tExpected Output: " + vectorSheet[iteration].output);
            Console.WriteLine("\tPerceptron Output: " + output);
            Console.WriteLine("\tChanged Weight: " + (changes ? "Yes" : "No"));
            if (changes)
            {
                Console.WriteLine("\t\tWeight 1: " + weight_1);
                Console.WriteLine("\t\tWeight 2: " + weight_2);
            }
        }
    }
}
