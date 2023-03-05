using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loops
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string GetLoopTime(int start, int end, string name)
        {
            return $"сегодня {DateTime.Now:MM.dd.yyyy}, сейчас {DateTime.Now:HH:mm:ss}\n" +
                $"Цикл выполнен за {end - start} миллисекунд\n" +
                $"Тип цикла {name}";
        }

        private void handleOnForClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(startTextBox.Text) || string.IsNullOrEmpty(endTextBox.Text)) return;

            int start = int.Parse(startTextBox.Text);
            int end = int.Parse(endTextBox.Text);

            listBox1.Items.Add("Цикл For:");

            int startTime, endTime;


            startTime = DateTime.Now.Millisecond;
            for (int i = start; i <= end; i++)
            {
                string str = "";
                for (int j = 1; j <= 10; j++) str += $"{j} ";

                listBox1.Items.Add($"{i} - {str}\t");
            }
            endTime = DateTime.Now.Millisecond;

            MessageBox.Show(GetLoopTime(startTime, endTime, "For"));

        }

        private void handleOnDoWhileClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(startTextBox.Text) || string.IsNullOrEmpty(endTextBox.Text)) return;

            int start = int.Parse(startTextBox.Text);
            int end = int.Parse(endTextBox.Text);

            listBox1.Items.Add("Цикл Do While:");

            int startTime, endTime;

            startTime = DateTime.Now.Millisecond;

            int i = start;

            do
            {
                int j = 1;
                string str = "";
                do
                {
                    str += $"{j} ";
                    j++;
                } while (j <= 10);

                listBox1.Items.Add($"{i} - {str}\t");
                i++;
            } while (i <= end);

            endTime = DateTime.Now.Millisecond;

            MessageBox.Show(GetLoopTime(startTime, endTime, "Do While"));
        }

        private void handleOnWhileClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(startTextBox.Text) || string.IsNullOrEmpty(endTextBox.Text)) return;

            int start = int.Parse(startTextBox.Text);
            int end = int.Parse(endTextBox.Text);

            listBox1.Items.Add("Цикл While:");

            int startTime, endTime;

            startTime = DateTime.Now.Millisecond;

            int i = start;

            while (i <= end)
            {
                int j = 1;
                string str = "";
                while (j <= 10)
                {
                    str += $"{j} ";
                    j++;
                }
                listBox1.Items.Add($"{i} - {str}\t");
                i++;
            }

            endTime = DateTime.Now.Millisecond;

            MessageBox.Show(GetLoopTime(startTime, endTime, "While"));
        }
    }
}
