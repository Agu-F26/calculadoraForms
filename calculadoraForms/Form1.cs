using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculadoraForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string input = "";
        private void btn_div_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void btn_suma_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void btn_resta_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void btn_prod_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void btn_ce_Click(object sender, EventArgs e)
        {
            input = textBox1.Text;
            textBox1.Text = $"{operacion(input)}";
        }

        private void btn_c_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void btn_sin_Click(object sender, EventArgs e)
        {
            textBox1.Text += "Sin(";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }


        public double sin(string input)
        {
            int indexSinIn = -1;
            int indexSinOut = -1;
            string numStr = "";
            double num = -1;
            double result = -1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'S') indexSinIn = i + 3;
                if (input[i] == ')') indexSinOut = i;
            }

            for (int i = indexSinIn; i < indexSinOut; i++) numStr += input[i];

            num = Double.Parse(numStr);

            result = Math.Sin(num);

            return num;            
        }

        public int operacion(string input)
        {
            int numA = 0;
            int numB = 0;
            int indexOperando = -1;
            string numAstr = "";
            string numBstr = "";
            char operacion = '\0';
            int result = 0;

            for(int i = 0; i < input.Length; i++) //Encontrar operacion e indice
            {
                if (!Char.IsDigit(input[i]))
                {
                    operacion = input[i];
                    indexOperando = i;
                }
            }
            try
            {
                for (int i = 0; i < indexOperando; i++) numAstr += input[i]; //genera primer numero (texto)
                for (int i = indexOperando + 1; i < input.Length; i++) numBstr += input[i]; //genera segundo numero (texto)
                numA = Int32.Parse(numAstr); //primer numero
                numB = Int32.Parse(numBstr); //segundo numero
            }
            catch
            {
                return Int32.Parse(input);
            }


            switch (operacion)
            {
                case '+':
                    result = numA + numB;
                    break;
                
                case '-':
                    result = numA - numB;
                    break;
                
                case '*':
                    result = numA * numB;
                    break;
                
                case '/':
                    result = numA / numB;
                    break;
            }

            return result;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Esto era para verificar, removido temporalmente.
             * 
             * if (Char.IsDigit(e.KeyChar) || e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/' || e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(Keys.Delete))
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    input = textBox1.Text;
                    textBox1.Text = $"{operacion(input)}";
                }
            }
            else
            {
                e.Handled = true;
            }
            */

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                input = textBox1.Text;
                textBox1.Text = $"{operacion(input)}";
            }

        }

        
    }
}
