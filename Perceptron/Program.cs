using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Perceptron Training");
            Perceptron robot = new Perceptron();
            robot.VectorSheet = PrepareData();
            while (true)
            {
                robot.Train();
                if (robot.Ready)
                    break;
            }
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Would you like to ask?[y/n]:");
                string code = Console.ReadLine();
                flag = (code[0] == 'y') ? true : false;
                if (!flag)
                    break;
                uint input_1 = 0, input_2 = 0;
                Console.WriteLine("Ask logical \"And\"");
                Console.Write("Input 1: ");
                input_1 = Convert.ToUInt32(Console.ReadLine());
                Console.Write("Input 2: ");
                input_2 = Convert.ToUInt32(Console.ReadLine());
                Console.WriteLine("Answer is " + robot.Ask(input_1, input_2));
            }
            Console.WriteLine("Training Finished");
        }

        private static List<Data> PrepareData()
        {
            List<Data> vectorSheet = new List<Data>();
            Data _1 = new Data(0, 0, 0);
            Data _2 = new Data(1, 0, 0);
            Data _3 = new Data(0, 1, 0);
            Data _4 = new Data(1, 1, 1);
            vectorSheet.Add(_1);
            vectorSheet.Add(_2);
            vectorSheet.Add(_3);
            vectorSheet.Add(_4);
            return vectorSheet;
        }
    }
}
