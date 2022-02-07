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
            input = input.ToLower();

            while (sinExists(input)) input = replaceSin(input);
            while (cosExists(input)) input = replaceCos(input);
            while (tanExists(input)) input = replaceTan(input);

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

        private void btn_cos_Click(object sender, EventArgs e)
        {
            textBox1.Text += "Cos(";
        }

        private void btn_tan_Click(object sender, EventArgs e)
        {
            textBox1.Text += "Tan(";
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }


        

        public double operacion(string input)
        {
            double numA = 0;
            double numB = 0;
            int indexOperando = -1;
            string numAstr = "";
            string numBstr = "";
            char operacion = '\0';
            double result = 0;

          

            for(int i = 0; i < input.Length; i++) //Encontrar operacion e indice
            {
                if (!Char.IsDigit(input[i]) && input[i] != ',' && input[i] != ' ' && i != 0)
                {
                    operacion = input[i];
                    indexOperando = i;
                    break;
                }
            }
            try
            {
                for (int i = 0; i < indexOperando; i++) numAstr += input[i]; //genera primer numero (texto)
                for (int i = indexOperando + 1; i < input.Length; i++) numBstr += input[i]; //genera segundo numero (texto)
                numA = Double.Parse(numAstr); //primer numero
                numB = Double.Parse(numBstr); //segundo numero
            }
            catch
            {
                return Double.Parse(input);
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

        //-------------------------------REFACTOR--------------------------------------------

        public double op(string input)
        {
            int indexOpIn = -1;
            int indexOpOut = -1;
            string numStr = "";
            double num = -1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 's') indexOpIn = i + 4;
                if (input[i] == ')') indexOpOut = i;
            }

            for (int i = indexOpIn; i < indexOpOut; i++) numStr += input[i];

            num = Double.Parse(numStr);

            return Math.Sin(num);
        }

        public string replaceOp(string input)
        {
            string aux = "";
            int indexOpIn = -1;
            int indexOpOut = -1;
            double result;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 's') indexOpIn = i;
                if (input[i] == ')')
                {
                    indexOpOut = i + 1;
                    break;
                }
            }
            for (int i = indexOpIn; i < indexOpOut; i++) aux += input[i];

            result = sin(aux);

            aux = input.Replace(aux, result.ToString());

            return aux;
        }



        //-------------------------------/REFACTOR-------------------------------------------


        public double sin(string input)
        {
            int indexSinIn = -1;
            int indexSinOut = -1;
            string numStr = "";
            double num = -1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 's') indexSinIn = i + 4;
                if (input[i] == ')') indexSinOut = i;
            }

            for (int i = indexSinIn; i < indexSinOut; i++) numStr += input[i];

            num = Double.Parse(numStr);

            return Math.Sin(num);
        }

        public string replaceSin(string input)
        {
            string aux = "";
            int indexSinIn = -1;
            int indexSinOut = -1;
            double result;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 's') indexSinIn = i;
                if (input[i] == ')') 
                {
                    indexSinOut = i + 1;
                    break;
                } 
            }
            for (int i = indexSinIn; i < indexSinOut; i++) aux += input[i];

            result = sin(aux);

            aux = input.Replace(aux, result.ToString());

            return aux;
        }

        public bool sinExists(string input)
        {
            bool isSin = false;
            
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 's' && input[i + 1] == 'i')
                {
                    isSin = true;
                    break;
                }
            }
            return isSin;
        }

        //----------------------------------------------------------------------
        public double cos(string input)
        {
            int indexCosIn = -1;
            int indexCosOut = -1;
            string numStr = "";
            double num = -1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'c') indexCosIn = i + 4;
                if (input[i] == ')')
                {
                    indexCosOut = i;
                    break;
                }
            }

            for (int i = indexCosIn; i < indexCosOut; i++) numStr += input[i];

            num = Double.Parse(numStr);

            return Math.Cos(num);
        }

        public string replaceCos(string input)
        {
            string aux = "";
            int indexCosIn = -1;
            int indexCosOut = -1;
            double result;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'c') indexCosIn = i;
                if (input[i] == ')') indexCosOut = i + 1;
            }
            for (int i = indexCosIn; i < indexCosOut; i++) aux += input[i];

            result = cos(aux);

            aux = input.Replace(aux, result.ToString());

            return aux;
        }

        public bool cosExists(string input)
        {
            bool isCos = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'c') isCos = true;
            }
            return isCos;
        }
        //----------------------------------------------------------------------

        //----------------------------------------------------------------------

        public double tan(string input)
        {
            int indexTanIn = -1;
            int indexTanOut = -1;
            string numStr = "";
            double num = -1;
            

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 't') indexTanIn = i + 4;
                if (input[i] == ')')
                {
                    indexTanOut = i;
                    break;
                }
            }

            for (int i = indexTanIn; i < indexTanOut; i++) numStr += input[i];

            num = Double.Parse(numStr);

            return Math.Tan(num);
        }

        public string replaceTan(string input)
        {
            string aux = "";
            int indexTanIn = -1;
            int indexTanOut = -1;
            double result;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 't') indexTanIn = i;
                if (input[i] == ')')
                {
                    indexTanOut = i + 1;
                    break;
                }
            }
            for (int i = indexTanIn; i < indexTanOut; i++) aux += input[i];

            result = tan(aux);

            aux = input.Replace(aux, result.ToString());

            return aux;
        }

        public bool tanExists(string input)
        {
            bool isTan = false;
            
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 't')
                {
                    isTan = true;
                    break;
                }
            }
            return isTan;
        }
        //----------------------------------------------------------------------

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Esto era para verificar, removido temporalmente (para siempre hasta que encuentre una manera mejor).
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
                input = input.ToLower();

                while (sinExists(input)) input = replaceSin(input);
                while (cosExists(input)) input = replaceCos(input);
                while (tanExists(input)) input = replaceTan(input);

                textBox1.Text = $"{operacion(input)}";
            }

        }

    }
}
