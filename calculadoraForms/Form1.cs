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
            while (opExists(input) != '0') input = replaceOp(input, opExists(input));
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

        private void btn_factorial_Click(object sender, EventArgs e)
        {
            textBox1.Text += "!";
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

        public double factorial(double input)
        {
            double aux = input;

            for (int i = (int)input; i > 0; i--)
            {
                aux += i * (i-1);
            }            
            return aux;
        }



        public string replaceOp(string input, char op)
        {
            string aux = "";
            int indexOpIn = -1;
            int indexOpOut = -1;
            int indexOperando = -1;
            double result = -1;
            string numStr ="";
            double num;
            string numStr1 = "";
            double num1;
            bool isSimple = false;

            switch (op){
                case '!':
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == '!')
                        {
                            indexOpOut = i;
                            break;
                        }
                        
                        
                    }
                    for (int i = indexOpOut; i > -1; i--)
                    {
                        if (!Char.IsDigit(input[i]) && input[i] != '!')
                        {
                            indexOpIn = i;
                            break;
                        }
                        if (i == 0) indexOpIn = i;
                    }
                    break;

                case 's':
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == 's' && input[i+1] == 'i') indexOpIn = i + 4;
                        if (input[i] == ')')
                        {
                            indexOpOut = i;
                            break;
                        }
                    }
                    break;

                case 'c':
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == 'c') indexOpIn = i + 4;
                        if (input[i] == ')')
                        {
                            indexOpOut = i;
                            break;
                        }
                    }
                    break;
                
                case 't':
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == 't') indexOpIn = i + 4;
                        if (input[i] == ')')
                        {
                            indexOpOut = i;
                            break;
                        }
                    }
                    break;

                    //SEGUIR TRABAJANDO EN ESTO
                case '+':
                case '-':
                case '/':
                case '*':
                    isSimple = true;
                    for (int i = 0; i < input.Length; i++)
                    {
                        if((input[i] == '+') || (input[i] == '-') || (input[i] == '/') || (input[i] == '*'))
                        {
                            indexOperando = i;
                            indexOpIn = i - 1;
                            for(int j = i; j < input.Length; j++)
                            {
                                if (!Char.IsDigit(input[j]) && input[j] != ',')
                                {
                                    indexOpOut = j;
                                    break;
                                }
                                indexOpOut = j;
                            }
                        }
                    }
                    break;

            }

            for (int i = indexOpIn; i < indexOpOut; i++) numStr += input[i];
            num = Double.Parse(numStr);
            if (isSimple)
            {

            }

            switch (op){

                case '!':
                    result = factorial(num);
                    aux = $"{num}!";
                    break;
                case 's': 
                    result = Math.Sin(num);
                    aux = $"sin({num})";
                    break;
                case 'c': 
                    result = Math.Cos(num);
                    aux = $"cos({num})";
                    break;
                case 't': 
                    result = Math.Tan(num);
                    aux = $"tan({num})";
                    break;
            }

            aux = input.Replace(aux, result.ToString());
            return aux;
        }

        public char opExists(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '!') return '!';
                if (input[i] == 's' && input[i + 1] == 'i') return 's';
                if (input[i] == 'c') return 'c';
                if (input[i] == 't') return 't';
                if (input[i] == '+') return '+';
                if ((input[i] == '-') && i > 0) return '-';
                if (input[i] == '/') return '/';
                if (input[i] == '*') return '*';

            }
            return '0';
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                input = textBox1.Text;
                input = input.ToLower();
                while (opExists(input) != '0') input = replaceOp(input, opExists(input));
                textBox1.Text = $"{operacion(input)}";
            }
        }


    }
}
