using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
            

            double[] xArray = new double[] { -1, -0.9, -0.8, -0.6, -0.4, -0.2, 0, 0.2, 0.4, 0.6, 0.8, 0.9, 1 };
            double[] yArray = new double[] { 0.38461, 0.157872, 0.588, 0.1, 0.2, 0.5, 1, 0.49, 0.2, 0.1, 0.588, 0.157872, 0.38461 };
            
            
            string input = textBox1.Text;// Читаем текст из TextBox
            
            try
            {
                // Разделяем строку по пробелам, удаляем пробелы и преобразуем в массив double
                double[] numbers = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => double.Parse(s.Trim()))
                    .ToArray();
                for (int i = 0; i < numbers.Length; i++)
                {
                    chart1.Series[0].Points.AddXY(numbers[i], LagrangMethod(xArray, yArray, numbers[i]));
                }
                // Здесь вы можете использовать массив numbers по вашему усмотрению
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
                chart1.Series[1].Points.AddXY(xArray[i], yArray[i]);
            }

        }
    }
}
