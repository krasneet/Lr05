using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            listBox1.Items.Add("+");
            listBox1.Items.Add("-");
            listBox1.Items.Add("*");
            listBox1.Items.Add("/");
            listBox1.SelectedIndex = 0;

            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            textBox2.TextChanged += new EventHandler(textBox2_TextChanged);
            listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CalculateAndDisplayResult();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CalculateAndDisplayResult();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateAndDisplayResult();
        }

        private void CalculateAndDisplayResult()
        {
            double inputValue1, inputValue2;

           
            if (double.TryParse(textBox1.Text, out inputValue1) && double.TryParse(textBox2.Text, out inputValue2))
            {
                string selectedMethod = listBox1.SelectedItem?.ToString();
                double result = 0;

                
                switch (selectedMethod)
                {
                    case "+":
                        result = inputValue1 + inputValue2; 
                        break;
                    case "-":
                        result = inputValue1 - inputValue2; 
                        break;
                    case "*":
                        result = inputValue1 * inputValue2; 
                        break;
                    case "/":
                        
                        if (inputValue2 != 0)
                        {
                            result = inputValue1 / inputValue2; 
                        }
                        else
                        {
                            MessageBox.Show("Ошибка: деление на ноль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox3.Text = string.Empty; 
                            return;
                        }
                        break;
                    default:
                        break;
                }

                
                textBox3.Text = result.ToString();
            }
            else
            {
                
                textBox3.Text = string.Empty;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
