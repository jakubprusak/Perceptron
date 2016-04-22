using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    public class VectorData
    {
        public uint input_1;
        public uint input_2;
        public uint output;

        /// <summary>
        ///First Input of the Perceptron 
        /// </summary>
        public uint Input1
        {
            get
            {
                return this.input_1;
            }
            set
            {
                input_1 = value;
            }
        }

        /// <summary>
        ///Second Input of the Perceptron 
        /// </summary>
        public uint Input2
        {
            get
            {
                return this.input_2;
            }
            set
            {
                input_2 = value;
            }
        }

        /// <summary>
        ///Expected Output of the Perceptron 
        /// </summary>
        public uint Output
        {
            get
            {
                return this.output;
            }
            set
            {
                output = value;
            }
        }

        /// <summary>
        ///Default constructor of the Data class 
        /// </summary>
        public VectorData()
        {
            //empty
        }

        /// <summary>
        ///Constructor of the Data class 
        /// </summary>
        /// <param name="input_1">
        /// First Input of the Perceptron 
        /// <see cref="System.UInt32"/>
        /// </param>
        /// <param name="input_2">
        /// Second Input of the Perceptron 
        /// <see cref="System.UInt32"/>
        /// </param>
        /// <param name="output">
        /// Expected Output of the Perceptron 
        /// <see cref="System.UInt32"/>
        /// </param>
        public VectorData(uint input_1, uint input_2, uint output)
        {
            this.input_1 = input_1;
            this.input_2 = input_2;
            this.output = output;
        }

    }

}
