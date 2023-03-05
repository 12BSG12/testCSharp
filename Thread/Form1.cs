using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Threading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            progressBar1.Maximum = textBox1.Text.Length;
        }

        int timerValue = 0;
        Thread thread;
        bool isPaused = false;
        int charIdx = 0;

        private void stopTimer(object sender, EventArgs e)
        {
            if (timer1.Enabled) timer1.Stop(); 
        }

        private void startTimer(object sender, EventArgs e)
        {
            if (timer1.Enabled) return;

            timer1.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            timer1.Interval = 500;

            if (textBox1.Text.Length == textBox2.Text.Length)
            {
                timer1.Stop();
                return; 
            };

            textBox2.Text += textBox1.Text[timerValue].ToString();

            timerValue++;
            progressBar1.Value++;
        }

        private async void OnClickMain(object sender, EventArgs e)
        {
            for (int i = 0; i < textBox1.Text.Length; i++)
            {

                textBox2.Text += textBox1.Text[i];
                
                progressBar1.Value++;
                
                await Task.Delay(500);
            }
        }

        private void secThreadOnClick(object sender, EventArgs e)
        {
            thread = new Thread(() =>
            {
                Action action = () => secThread();

                if (InvokeRequired)
                    Invoke(action);
                else
                    action();
            });

            thread.Start();
        }
       
        public async void secThread()
        {
            isPaused = false;

            for (; charIdx < textBox1.Text.Length; charIdx++)
            {
                
                textBox2.Text += textBox1.Text[charIdx];

                progressBar1.Value++;

                int delay = 500;

                if (isPaused)
                {
                    charIdx++;
                    delay = Timeout.Infinite;
                }

                await Task.Delay(delay);
            }
        }

        private void secThreadStop(object sender, EventArgs e)
        {
            isPaused = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(timerValue != 0) timerValue = 0;
            progressBar1.Value = 0;
            textBox2.Text = "";
        }
    }
}
