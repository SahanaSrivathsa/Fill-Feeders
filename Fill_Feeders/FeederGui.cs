using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace Fill_Feeders
{
    public partial class FeederGui : Form
    {
        private static readonly SerialPort serialPort = new SerialPort();
        public BackgroundWorker felix = new BackgroundWorker();
        public FeederGui()
        {
            
            serialPort.BaudRate = 9600;
            serialPort.PortName = "COM3";
            serialPort.ReadTimeout = 10000;
            serialPort.Encoding = Encoding.UTF8;
            serialPort.DiscardNull = true;
            serialPort.WriteBufferSize = 10000;
            serialPort.Open();

            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();
            InitializeComponent();
        }
        public void listen_to_arduino(object sender, DoWorkEventArgs e)
        //The "listener" that is the mediator between the worker (Felix) and the updater
        {
            try
            {
                var changedData = serialPort.ReadTo("\n");
                e.Result = changedData;
            }
            catch (Exception)
            {
            }
        }
        public static void sendMessage(string button) //handles messages to be sent to the UNO for filling/cleaning
        {
            switch (button)
            {
                case "1":
                    try
                    {
                        serialPort.Write(new[] { 'X' }, 0, 1);
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    break;
                case "2":
                    try
                    {
                        serialPort.Write(new[] { 'Y' }, 0, 1);
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    break;
                case "3":
                    try
                    {
                        serialPort.Write(new[] { 'Z' }, 0, 1);
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    break;
                case "4":
                    try
                    {
                        serialPort.Write(new[] { 'W' }, 0, 1);
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    break;
                case "11":
                    try
                    {
                        serialPort.Write(new[] { 'x' }, 0, 1);
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    break;
                case "22":
                    try
                    {
                        serialPort.Write(new[] { 'y' }, 0, 1);
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    break;
                case "33":
                    try
                    {
                        serialPort.Write(new[] { 'z' }, 0, 1);
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    break;
                case "44":
                    try
                    {
                        serialPort.Write(new[] { 'w' }, 0, 1);
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    break;
            }
        }

        private void close3_Click(object sender, EventArgs e)
        {
            FeederGui.sendMessage("33");
            fill3.Show();
        }

        private void close2_Click(object sender, EventArgs e)
        {
            FeederGui.sendMessage("22");
            fill2.Show();
        }

        private void close1_Click(object sender, EventArgs e)
        {
            FeederGui.sendMessage("11");
            fill1.Show();
        }

        private void close4_Click(object sender, EventArgs e)
        {
            FeederGui.sendMessage("44");
            fill4.Show();
        }

        private void fill3_Click(object sender, EventArgs e)
        {
            FeederGui.sendMessage("3");
            fill3.Hide();
        }

        private void fill2_Click(object sender, EventArgs e)
        {
            FeederGui.sendMessage("2");
            fill2.Hide();
        }

        private void fill1_Click(object sender, EventArgs e)
        {
            FeederGui.sendMessage("1");
            fill1.Hide();
        }

        private void fill4_Click(object sender, EventArgs e)
        {
            FeederGui.sendMessage("4");
            fill4.Hide();
        }

        private void done_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}




