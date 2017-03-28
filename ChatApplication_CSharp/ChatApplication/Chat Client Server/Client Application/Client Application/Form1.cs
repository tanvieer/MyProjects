using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetworksApi.TCP.CLIENT;

namespace Client_Application
{
    public delegate void UpdateTextBox(string txt);
    public partial class Form1 : Form
    {
        Client Clien = new Client();
        public Form1()
        {
            InitializeComponent();
        }

        void ChangeTextBox(string txt)
        {
            if (textBox2.InvokeRequired)
            {
                Invoke(new UpdateTextBox(ChangeTextBox), new object[] { txt });
            }
            else
            {
                textBox2.Text += txt + "\r\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Clien.EncryptionEnabled = false;
            Clien.OnClientConnected += new OnClientConnectedDelegate(Clien_OnClientConnected);
            Clien.OnClientConnecting += new OnClientConnectingDelegate(Clien_OnClientConnecting);
            Clien.OnClientDisconnected += new OnClientDisconnectedDelegate(Clien_OnClientDisconnected);
            Clien.OnClientError += new OnClientErrorDelegate(Clien_OnClientError);
            Clien.OnClientFileSending += new OnClientFileSendingDelegate(Clien_OnClientFileSending);
            Clien.OnDataReceived += new OnClientReceivedDelegate(Clien_OnDataReceived);
        }

        void Clien_OnDataReceived(object Sender, ClientReceivedArguments R)
        {
            ChangeTextBox(R.ReceivedData);
        }

        void Clien_OnClientFileSending(object Sender, ClientFileSendingArguments R)
        {
            // use this if you want to send a file
        }

        void Clien_OnClientError(object Sender, ClientErrorArguments R)
        {
            ChangeTextBox(R.ErrorMessage);
        }

        void Clien_OnClientDisconnected(object Sender, ClientDisconnectedArguments R)
        {
            ChangeTextBox(R.EventMessage);
        }

        void Clien_OnClientConnecting(object Sender, ClientConnectingArguments R)
        {
            ChangeTextBox(R.EventMessage);
        }

        void Clien_OnClientConnected(object Sender, ClientConnectedArguments R)
        {
            ChangeTextBox(R.EventMessage);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Clear();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clien.ClientName = textBox4.Text;
            Clien.ServerIp = textBox1.Text;
            Clien.ServerPort = "90";
            Clien.Connect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Clien.IsConnected)
            {
                Clien.Send(textBox3.Text);
            }
        }

        
    }
}
