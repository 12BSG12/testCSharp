using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComAndModbus
{

    public partial class Form1 : Form
    {
        MyPort myPort = new MyPort();

        public Form1()
        {
            InitializeComponent();
            SetControlSettings();
        }

        public void SetControlSettings()
        {
            comboBoxOfPorts.Items.AddRange(myPort.GetAllPortsName());

            parityComboBox.Items.AddRange(new string[] { "None" });
            stopBitsComboBox.Items.AddRange(new string[] { "One" });
            dataBitsComboBox.Items.AddRange(new string[] { "8" });
            baudRateComboBox.Items.AddRange(new string[] { "9600" });


            ComboBox[] boxes = new ComboBox[] { comboBoxOfPorts, parityComboBox, stopBitsComboBox, dataBitsComboBox, baudRateComboBox };

            foreach (var b in boxes)
            {
                b.SelectedIndex = 0;
                b.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            sendBtn.Enabled = false;
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            myPort.WriteMessage(textBox.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myPort.Parity = parityComboBox.Text;
            myPort.StopBits = stopBitsComboBox.Text;
            myPort.DataBits = dataBitsComboBox.Text;
            myPort.BaudRate = baudRateComboBox.Text;
            myPort.PortName = comboBoxOfPorts.Text;
            myPort.DisplayWindow = textBox2;
            myPort.Open();

            if (!myPort.IsError) sendBtn.Enabled = true;
        }

    }

    class MyPort 
    {
        public string PortName { get; set; }
        public string BaudRate { get; set; }
        public string DataBits { get; set; }
        public string Parity { get; set; }
        public string StopBits { get; set; }
        public TextBox DisplayWindow { get; set; }
        public bool IsError { get; private set; }

        private SerialPort comPort = new SerialPort();
        
        public MyPort()
        {
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
        }

        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string msg = comPort.ReadExisting();
            DisplayData($"Данные с порта {comPort.PortName}: {msg}\r\n");
        }

        public void Open()
        {
            try
            {
                IsError = false;

                if (comPort.IsOpen) comPort.Close();

                comPort.BaudRate = int.Parse(BaudRate);
                comPort.DataBits = int.Parse(DataBits);
                comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), StopBits);    
                comPort.Parity = (Parity)Enum.Parse(typeof(Parity), Parity);
                comPort.PortName = PortName;
                
                comPort.Open();

                DisplayData($"Порт открылся в {DateTime.Now}\r\n");
            }
            catch (Exception ex)
            {
                DisplayData(ex.Message);
                IsError = true;
            }
        }

        private void DisplayData(string msg)
        {
            DisplayWindow.AppendText(msg);
            DisplayWindow.ScrollToCaret();
        }

        public void WriteMessage(string msg)
        {
            if (!IsError)
            {
                comPort.Write(msg);
                
                DisplayData($"Данные с порта {comPort.PortName}: {msg}\r\n");
            }
        }

        public string[] GetAllPortsName() => SerialPort.GetPortNames();
    }
}
