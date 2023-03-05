using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClassAndList
{
    public partial class Form1 : Form
    {
        List<Gasdetector> deviceList;

        public Form1()
        {
            InitializeComponent();
        }

        public void EditList()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = deviceList;
        }

        public void ControlSettings()
        {
            colorComboBox.Items.AddRange(new string[] { "Blue", "Red", "Yellow" });
            gasNameComboBox.Items.AddRange(new string[] { "Метан", "Пропан", "Бутан" });
            sortComboBox.Items.AddRange(new string[] { SortValues.None, SortValues.ASC, SortValues.DESC });

            ComboBox[] ComboBoxArr = new ComboBox[] { colorComboBox, gasNameComboBox, sortComboBox };

            foreach (ComboBox comboBox in ComboBoxArr)
            {
                comboBox.SelectedIndex = 0;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        

        private void SortList(object sender, EventArgs e)
        {
            string sortValue = sortComboBox.Text;

            switch (sortValue)
            {
                case SortValues.ASC:
                    deviceList = deviceList.OrderBy(item => item.Type).ToList();
                    break;
                case SortValues.DESC:
                    deviceList = deviceList.OrderByDescending(item => item.Type).ToList();
                    break;
                default:
                    return;
            }
            EditList();
        }

        private void HandleOnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(factoryNumberBox.Text)) return;

            const string pattern = @"^ER\d{9}";

            Regex regex = new Regex(pattern);
            
            if (regex.IsMatch(factoryNumberBox.Text))
            {
                deviceList.Add(new Gasdetector(factoryNumberBox.Text, colorComboBox.Text, gasNameComboBox.Text));
            }
            else
            {
                MessageBox.Show("Введен некорректно зав. номер.\r\nПример ввода: «ER210229999»");
            }

            EditList();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            ControlSettings();

            deviceList = new List<Gasdetector>()
            {
                new Gasdetector("ER210220001", "Yellow", "Метан"),
                new Gasdetector("ER210220002", "Yellow", "Метан"),
                new Gasdetector("ER230220001", "Red", "Пропан")
            };

            EditList();
        }
    }

    class Gasdetector
    {
        public string FactoryNumber { get; private set; }
        public string Color { get; private set; }
        public string GasName { get; private set; }
        public int Type { get; private set; }
        public string CreateAt { get; private set; }

        public Gasdetector(string factoryNumber, string color, string gasName)
        {
            FactoryNumber = factoryNumber;
            Type = Convert.ToInt32(factoryNumber.Substring(2, 3));
            Color = color;
            GasName = gasName;
            CreateAt = DateTime.Now.ToString();
        }
    }

    public class SortValues
    {
        public const string None = "None";
        public const string ASC = "По возрастанию";
        public const string DESC = "По убыванию";
    }
}
