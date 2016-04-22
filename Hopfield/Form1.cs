using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hopfield
{
    public partial class Form1 : Form
    {
        private static char rowsSeparator = ';';
        private static char columnSeparator = ',';
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "1,1,1";
            textBox2.Text = "0,1,-1;1,0,1;-1,1,0";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Vector x0 = ParseToVector(this.textBox1.Text);
            Vector w = ParseToVector(this.textBox2.Text);

            var result = HopfieldAlgorytm.RunSynchronic(x0, w);

            dataGridView1.DataSource = result;
        }

        private Vector ParseToVector(string s)
        {
            string[] rows = s.Split(rowsSeparator);
            int numberOfColumns = rows[0].Split(columnSeparator).Count();

            Vector m = new Vector(rows.Count(), numberOfColumns);

            for (int i = 0; i < rows.Count(); i++)
            {
                string[] values = rows[i].Split(columnSeparator);

                for (int j = 0; j < m.NumberOfColumns; j++)
                {
                    m[i, j] = double.Parse(values[j]);
                }
            }

            return m;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vector x0 = ParseToVector(this.textBox1.Text);
            Vector w = ParseToVector(this.textBox2.Text);

            var result = HopfieldAlgorytm.RunASynchronic(x0, w);

            dataGridView1.DataSource = result;
        } 
    }
}
