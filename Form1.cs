//hesap makinesinin tum fonksiyonlari calisiyor.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float firstNumber;
        string _operator;
        float result;

        //Ввод и отображение нажатой цифры
        private void number_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (textBox_result.Text == "0")
            {
                textBox_result.Clear();
            }
            textBox_result.Text = textBox_result.Text + button.Text;
        }

        //Ввод и отображение нажатого оператора
        private void operator_Click(object sender, EventArgs e)
        {
            if (textBox_result.Text != string.Empty)
            {
                Button button = (Button)sender;
                _operator = button.Text;
                firstNumber = float.Parse(textBox_result.Text);
                label_result.Text = firstNumber.ToString() + _operator;
                textBox_result.Clear();
            }
        }

        //Высчитывание и отображение результата
        private void equal_Click(object sender, EventArgs e)
        {
            if (textBox_result.Text != string.Empty)
            {
                Calculate();
                label_result.ResetText();
                textBox_result.Text = result.ToString();
            }
        }

        //Обнуление введённых данных
        private void clear_Click(object sender, EventArgs e)
        {
            label_result.ResetText();
            textBox_result.Text = "0";
        }

        //Выссчитывание ответа
        private void Calculate()
        {
            if (_operator == "+")
                result = firstNumber + float.Parse(textBox_result.Text);
            else if (_operator == "-")
                result = firstNumber - float.Parse(textBox_result.Text);
            else if (_operator == "x")
                result = firstNumber * float.Parse(textBox_result.Text);
            else if (_operator == "÷")
                result = firstNumber / float.Parse(textBox_result.Text);
            else
                result = 0;
        }

        //Вводит и отображает - перед следующим введённым числом
        private void negative_Click(object sender, EventArgs e)
        {
            if (textBox_result.Text != string.Empty && textBox_result.Text != ",")
            {
                float negNum;
                negNum = float.Parse(textBox_result.Text) * -1;
                textBox_result.Text = negNum.ToString();
            }
        }

        //Удаление введённого числа
        private void delete_Click(object sender, EventArgs e)
        {
            if (textBox_result.Text.Length > 1)
            {
                string result = textBox_result.Text.Substring(0, textBox_result.Text.Length - 1);
                textBox_result.Text = result;
            }
            else
            {
                textBox_result.Text = "0";
            }
        }

        //Ввод и отображение запятой
        private void comma_Click(object sender, EventArgs e)
        {
            int i = 0;
            int length = textBox_result.Text.Length;
            bool commaExist = false;
            char[] chars = textBox_result.Text.ToCharArray();
            Button button = (Button)sender;
            while (i < length)
            {
                if (chars[i] == ',')
                {
                    commaExist = true;
                }
                i++;
            }
            if (commaExist == false)
                textBox_result.Text = textBox_result.Text + button.Text;
        }

        //Валидация входящих параметров
        private void textBox_result_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //Если введённое значение НЕ число, то с помощью свойства Handled его ввод блокируется
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }
    }
}
