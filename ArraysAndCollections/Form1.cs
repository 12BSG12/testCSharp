using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArraysAndCollections
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void handleOnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;

            if (textBox1.Text.Length > 10) MessageBox.Show("длина слова не более 10 символов");


            List<byte> list = new List<byte>(Encoding.ASCII.GetBytes(textBox1.Text));

            string HEX = "";

            
            listBox1.Items.Add($"Массив байт (10-ая) = {string.Join(" ", list)}");

            foreach (byte b in list)
            {
                HEX += string.Format($"{b:x2} ").ToUpper();
            }

            listBox1.Items.Add($"Массив байт (HEX) = {HEX}");

            byte[] crcBytesArr = BitConverter.GetBytes(list.Sum(item => item));

            Array.Resize(ref crcBytesArr, 2);

            foreach (byte b in crcBytesArr.Reverse())
            {
                list.Add(b);
            }


            listBox1.Items.Add($"Массив байт + CRC (10-ая) = {string.Join(" ", list)}");

            HEX = "";

            foreach (byte b in list)
            {
                HEX += string.Format($"{b:x2} ").ToUpper();
            }

            listBox1.Items.Add($"Массив байт + CRC (HEX) = {HEX}");

        }
    }
}
