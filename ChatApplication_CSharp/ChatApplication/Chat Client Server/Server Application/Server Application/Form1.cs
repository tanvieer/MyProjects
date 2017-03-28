using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetworksApi.TCP.SERVER;

namespace Server_Application
{
    public delegate void UpdateTextBox(string txt);
    public partial class Form1 : Form
    {
        Server Serv;
        public Form1()
        {
            InitializeComponent();
        }

        public void ChangeTextBox(string txt)
        {
            if (textBox1.InvokeRequired)
            {
                Invoke(new UpdateTextBox(ChangeTextBox), new object[] { txt });
            }
            else
            {
                textBox1.Text += txt + "\r\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        void Serv_OnServerError(object Sender, ErrorArguments R)
        {
            ChangeTextBox(R.ErrorMessage + "\r\n" + R.Exception);
        }

        void Serv_OnDataReceived(object Sender, ReceivedArguments R)
        {
            ChangeTextBox(R.Name + " Says " + ":" + R.ReceivedData);
            Serv.BroadCast(R.Name + " Says " + ":" + R.ReceivedData);
        }

        void Serv_OnClientDisconnected(object Sender, DisconnectedArguments R)
        {
            ChangeTextBox(R.Name + " Has Disconnected");
        }

        void Serv_OnClientConnected(object Sender, ConnectedArguments R)
        {
            ChangeTextBox(R.Name + " Has Connected");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Serv = new Server(textBox2.Text, "90");
            Serv.EncryptionEnabled = false;
            Serv.OnClientConnected += new OnConnectedDelegate(Serv_OnClientConnected);
            Serv.OnClientDisconnected += new OnDisconnectedDelegate(Serv_OnClientDisconnected);
            Serv.OnDataReceived += new OnReceivedDelegate(Serv_OnDataReceived);
            Serv.OnServerError += new OnErrorDelegate(Serv_OnServerError);
            Serv.Start();
        }
    }
}
