using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ControlSettings();
        }

        public void ControlSettings()
        {
            string[] weightComBoxArr = new string[] { "грамм", "килограмм", "тонна", "миллиграмм", "фунт" };
            string[] distanceComBoxArr = new string[] { "метр", "километр", "сантиметр", "миля", "верста", "аршин" };
            string[] tempComBoxArr = new string[] { "градус Цельсия", "градус Фаренгейта", "Кельвин" };

            weightComboBoxFrom.Items.AddRange(weightComBoxArr);
            weightComboBoTo.Items.AddRange(weightComBoxArr);

            distanceComboBoxFrom.Items.AddRange(distanceComBoxArr);
            distanceComboBoxTo.Items.AddRange(distanceComBoxArr);

            tempComboBoxFrom.Items.AddRange(tempComBoxArr);
            tempComboBoxTo.Items.AddRange(tempComBoxArr);


            ComboBox[] ComboBoxArr = new ComboBox[]
            {
                weightComboBoxFrom, distanceComboBoxFrom,
                tempComboBoxFrom, tempComboBoxTo,
                distanceComboBoxTo, weightComboBoTo
            };

            foreach (ComboBox comboBox in ComboBoxArr)
            {
                comboBox.SelectedIndex = 0;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        public void ChangeImg(double value, PictureBox pictureBox)
        {
            if(value < 0) pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("ice");

            if (value > 0 && value < 100) pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("wing");

            if (value >= 100) pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("steam");

        }

        private void handleOnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;

            textBox2.Text = "";

            switch (weightComboBoxFrom.Text)
            {
                case "грамм":
                    switch (weightComboBoTo.Text)
                    {
                        case "килограмм":
                            textBox2.Text = (int.Parse(textBox1.Text) / 1000.0).ToString();
                            break;
                        case "тонна":
                            textBox2.Text = (int.Parse(textBox1.Text) / 1000000.0).ToString();
                            break;
                        case "миллиграмм":
                            textBox2.Text = (int.Parse(textBox1.Text) * 1000.0).ToString();
                            break;
                        case "фунт":
                            textBox2.Text = (int.Parse(textBox1.Text) * 0.002204623).ToString();
                            break;
                        default:
                            MessageBox.Show("Это одна и та же величина. Перевод невозможен!", "Внимание!");
                            break;
                    }
                    break;
                case "килограмм":
                    switch (weightComboBoTo.Text)
                    {
                        case "грамм":
                            textBox2.Text = (int.Parse(textBox1.Text) * 1000.0).ToString();
                            break;
                        case "тонна":
                            textBox2.Text = (int.Parse(textBox1.Text) / 1000.0).ToString();
                            break;
                        case "миллиграмм":
                            textBox2.Text = (int.Parse(textBox1.Text) / 1000000.0).ToString();
                            break;
                        case "фунт":
                            textBox2.Text = (int.Parse(textBox1.Text) * 2.20462).ToString();
                            break;
                        default:
                            MessageBox.Show("Это одна и та же величина. Перевод невозможен!", "Внимание!");
                            break;
                    }
                    break;
                case "тонна":
                    switch (weightComboBoTo.Text)
                    {
                        case "грамм":
                            textBox2.Text = (int.Parse(textBox1.Text) / 1000000.0).ToString();
                            break;
                        case "килограмм":
                            textBox2.Text = (int.Parse(textBox1.Text) * 1000.0).ToString();
                            break;
                        case "миллиграмм":
                            textBox2.Text = (int.Parse(textBox1.Text) / 1000000000.0).ToString();
                            break;
                        case "фунт":
                            textBox2.Text = (int.Parse(textBox1.Text) * 2204.62).ToString();
                            break;
                        default:
                            MessageBox.Show("Это одна и та же величина. Перевод невозможен!", "Внимание!");
                            break;
                    }
                    break;
                case "миллиграмм":
                    switch (weightComboBoTo.Text)
                    {
                        case "грамм":
                            textBox2.Text = (int.Parse(textBox1.Text) / 1000.0).ToString();
                            break;
                        case "килограмм":
                            textBox2.Text = (int.Parse(textBox1.Text) / 1000000.0).ToString();
                            break;
                        case "тонна":
                            textBox2.Text = (int.Parse(textBox1.Text) / 1000000000.0).ToString();
                            break;
                        case "фунт":
                            textBox2.Text = (int.Parse(textBox1.Text) * (2.2046226 * Math.Pow(10, -6))).ToString();
                            break;
                        default:
                            MessageBox.Show("Это одна и та же величина. Перевод невозможен!", "Внимание!");
                            break;
                    }
                    break;
                case "фунт":
                    switch (weightComboBoTo.Text)
                    {
                        case "грамм":
                            textBox2.Text = (int.Parse(textBox1.Text) * 453.592).ToString();
                            break;
                        case "килограмм":
                            textBox2.Text = (int.Parse(textBox1.Text) * 0.45359237).ToString();
                            break;
                        case "тонна":
                            textBox2.Text = (int.Parse(textBox1.Text) * 0.000453592).ToString();
                            break;
                        case "миллиграмм":
                            textBox2.Text = (int.Parse(textBox1.Text) * 453592).ToString();
                            break;
                        default:
                            MessageBox.Show("Это одна и та же величина. Перевод невозможен!", "Внимание!");
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void handleOnDistanceClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text)) return;

            textBox5.Text = "";

            int valueOfTextBox = int.Parse(textBox6.Text);


            switch (distanceComboBoxFrom.Text)
            {
                case "метр":
                    switch (distanceComboBoxTo.Text)
                    {
                        case "километр":
                            textBox5.Text = (valueOfTextBox / 1000.0).ToString();
                            break;
                        case "сантиметр":
                            textBox5.Text = (valueOfTextBox * 100).ToString();
                            break;
                        case "миля":
                            textBox5.Text = Math.Round(valueOfTextBox / 1609.0, 4).ToString();
                            break;
                        case "верста":
                            textBox5.Text = Math.Round(valueOfTextBox / 1067.0, 4).ToString();
                            break;
                        case "аршин":
                            textBox5.Text = (valueOfTextBox * 1.406).ToString();
                            break;
                        default:
                            MessageBox.Show("Это одна и та же величина. Перевод невозможен!", "Внимание!");
                            break;
                    }
                    break;
                case "километр":
                    switch (distanceComboBoxTo.Text)
                    {
                        case "метр":
                            textBox5.Text = (valueOfTextBox * 1000).ToString();
                            break;
                        case "сантиметр":
                            textBox5.Text = (valueOfTextBox * 100000).ToString();
                            break;
                        case "миля":
                            textBox5.Text = Math.Round(valueOfTextBox / 1609.0, 4).ToString();
                            break;
                        case "верста":
                            textBox5.Text = Math.Round(valueOfTextBox / 1067.0, 4).ToString();
                            break;
                        case "аршин":
                            textBox5.Text = (valueOfTextBox * 1.406).ToString();
                            break;
                        default:
                            MessageBox.Show("Это одна и та же величина. Перевод невозможен!", "Внимание!");
                            break;
                    }
                    break;
                case "сантиметр":
                    switch (distanceComboBoxTo.Text)
                    {
                        case "метр":
                            textBox5.Text = (valueOfTextBox / 100.0).ToString();
                            break;
                        case "километр":
                            textBox5.Text = (valueOfTextBox / 100000.0).ToString();
                            break;
                        case "миля":
                            textBox5.Text = Math.Round(valueOfTextBox / 160900.0, 4).ToString();
                            break;
                        case "верста":
                            textBox5.Text = Math.Round(valueOfTextBox / 106680.0, 4).ToString();
                            break;
                        case "аршин":
                            textBox5.Text = (valueOfTextBox * 0.014061).ToString();
                            break;
                        default:
                            MessageBox.Show("Это одна и та же величина. Перевод невозможен!", "Внимание!");
                            break;
                    }
                    break;
                case "миля":
                    switch (distanceComboBoxTo.Text)
                    {
                        case "метр":
                            textBox5.Text = (valueOfTextBox * 1609).ToString();
                            break;
                        case "километр":
                            textBox5.Text = (valueOfTextBox * 1.609).ToString();
                            break;
                        case "сантиметр":
                            textBox5.Text = (valueOfTextBox * 160900).ToString();
                            break;
                        case "верста":
                            textBox5.Text = (valueOfTextBox * 1.509).ToString();
                            break;
                        case "аршин":
                            textBox5.Text = (valueOfTextBox * 2262.8571).ToString();
                            break;
                        default:
                            MessageBox.Show("Это одна и та же величина. Перевод невозможен!", "Внимание!");
                            break;
                    }
                    break;
                case "верста":
                    switch (distanceComboBoxTo.Text)
                    {
                        case "метр":
                            textBox5.Text = (valueOfTextBox * 1067).ToString();
                            break;
                        case "километр":
                            textBox5.Text = (valueOfTextBox * 1.067).ToString();
                            break;
                        case "сантиметр":
                            textBox5.Text = (valueOfTextBox * 106700).ToString();
                            break;
                        case "миля":
                            textBox5.Text = (valueOfTextBox / 1.509).ToString();
                            break;
                        case "аршин":
                            textBox5.Text = (valueOfTextBox * 1500).ToString();
                            break;
                        default:
                            MessageBox.Show("Это одна и та же величина. Перевод невозможен!", "Внимание!");
                            break;
                    }
                    break;
                case "аршин":
                    switch (distanceComboBoxTo.Text)
                    {
                        case "метр":
                            textBox5.Text = (valueOfTextBox * 0.7112).ToString();
                            break;
                        case "километр":
                            textBox5.Text = (valueOfTextBox * 0.0007112).ToString();
                            break;
                        case "сантиметр":
                            textBox5.Text = (valueOfTextBox * 71.12).ToString();
                            break;
                        case "миля":
                            textBox5.Text = (valueOfTextBox * 28000).ToString();
                            break;
                        case "верста":
                            textBox5.Text = (valueOfTextBox * 0.000667).ToString();
                            break;
                        default:
                            MessageBox.Show("Это одна и та же величина. Перевод невозможен!", "Внимание!");
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void handleOnTempClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text)) return;

            textBox3.Text = "";

            int valueOfTextBox = int.Parse(textBox4.Text);

            switch (tempComboBoxFrom.Text)
            {
                case "градус Цельсия":
                    switch (tempComboBoxTo.Text)
                    {
                        case "градус Фаренгейта":
                            textBox3.Text = (valueOfTextBox * 9/5 + 32).ToString();
                            break;
                        case "Кельвин":
                            textBox3.Text = (valueOfTextBox + 273.15).ToString();
                            break;
                        default:
                            MessageBox.Show("Это одна и та же величина. Перевод невозможен!", "Внимание!");
                            break;
                    }
                    break;
                case "градус Фаренгейта":
                    switch (tempComboBoxTo.Text)
                    {
                        case "градус Цельсия":
                            textBox3.Text = ((valueOfTextBox - 32) * 5/9).ToString();
                            break;
                        case "Кельвин":
                            textBox3.Text = ((valueOfTextBox - 32) * 5/9 + 273.15).ToString();
                            break;
                        default:
                            MessageBox.Show("Это одна и та же величина. Перевод невозможен!", "Внимание!");
                            break;
                    }
                    break;
                case "Кельвин":
                    switch (tempComboBoxTo.Text)
                    {
                        case "градус Цельсия":
                            textBox3.Text = (valueOfTextBox - 273.15).ToString();
                            break;
                        case "градус Фаренгейта":
                            textBox3.Text = ((valueOfTextBox - 273.15) * 9/5 + 32).ToString();
                            break;
                        default:
                            MessageBox.Show("Это одна и та же величина. Перевод невозможен!", "Внимание!");
                            break;
                         
                    }
                    break;
                default:
                    break;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) || textBox4.Text == "-")
            {
                pictureBoxFrom.Image = null;
                return;
            };

            int valueOfTextBox = int.Parse(textBox4.Text);

            double C;

            switch (tempComboBoxFrom.Text)
            {
                case "градус Фаренгейта":
                    C = (valueOfTextBox - 32) * 5/9;
                    break;
                case "Кельвин":
                    C = valueOfTextBox - 273.15;
                    break;
                default:
                    C = valueOfTextBox;
                    break;
            }

            ChangeImg(C, pictureBoxFrom);
        }
    }
}
