using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LagrangePolynomial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double LagrangMethod(double[] xArray, double[] yArray, double x)
        {
            //int n = xArray.Length;
            //double result = 0;

            //for (int i = 0; i < n; ++i)
            //{
            //    double term = yArray[i];

            //    for (int j = 0; j < n; ++j)
            //    {
            //        if (i != j)
            //        {
            //            term *= (x - xArray[j]) / (xArray[i] - xArray[j]);
            //        }
            //    }

            //    result += term;
            //}
            //return result;
            int n = xArray.Length; // Количество узлов
            double result = 0.0;   // Инициализируем результат полинома

            // Проходим по всем узлам для вычисления значения полинома
            for (int i = 0; i < n; i++)
            {
                double term = yArray[i]; // Начальная температура для данного узла
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        // Вычисление производной L_j(x)
                        term *= (x - xArray[j]) / (xArray[i] - xArray[j]);
                    }
                }
                result += term; // Суммируем значения для каждого узла
            }

            return result; // Возвращаем вычисленное значение полинома
        }
        private void Play_Click(object sender, EventArgs e)
        {
            double[] xArray = new double[] { -1, -0.8, -0.6, -0.4, -0.2, 0, 0.2, 0.4, 0.6, 0.8, 1 };
            double[] yArray = new double[] { 3.8461, 5.88, 0.1, 0.2, 0.5, 1, 0.49, 0.2, 0.1, 5.88, 3.8461 };
            //try
            //{
            //    double x = Convert.ToDouble(textBox1.Text);
            //}
            //catch
            //{
            //    for (int i = 0; i < 11; i++)
            //    {
            //        //chart1.Series[0].Points.AddXY(x, LagrangMethod(xArray, yArray, x));
            //        chart1.Series[0].Points.AddXY(xArray[i], yArray[i]);
            //    }
            //}
            // Читаем текст из TextBox
            string input = textBox1.Text;


            try
            {
                // Разделяем строку по пробелам, удаляем пробелы и преобразуем в массив double
                double[] numbers = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => double.Parse(s.Trim()))
                    .ToArray();
                for (int i = 0; i < numbers.Length; i++)
                {
                    //chart1.Series[0].Points.AddXY(x, LagrangMethod(xArray, yArray, x));
                    chart1.Series[0].Points.AddXY(numbers[i], LagrangMethod(xArray, yArray, numbers[i]));
                }
                // Здесь вы можете использовать массив numbers по вашему усмотрению
                //MessageBox.Show("Числа: " + string.Join(", ", numbers));
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный формат числа. Пожалуйста, введите числа через пробел.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            for (int i = 0; i < 11; i++)
            {
                //chart1.Series[0].Points.AddXY(x, LagrangMethod(xArray, yArray, x));
                chart1.Series[1].Points.AddXY(xArray[i], yArray[i]);
            }
            //chart1.Series[0].Points.AddXY(x, LagrangMethod(xArray, yArray, x));
            //double x = Convert.ToDouble(textBox1.Text);
            //textBox1.Text = LagrangMethod(xArray, yArray,x ).ToString();

        }
    }
}
