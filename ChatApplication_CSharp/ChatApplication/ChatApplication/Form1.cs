using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel;
using NetworksApi.TCP.CLIENT;

namespace ChatApplication
{
    public delegate void UpdateText(string txt);
    public partial class Form1 : Form
    {
        Client client;

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ChangeTextBox(string txt)
        {
            if (textBox1.InvokeRequired)    // bujhi nai
            {
                Invoke(new UpdateText(ChangeTextBox), new object[] { txt });
            }
            else
            {
                textBox1.Text += txt + "\r\n";    // new line in chat log
            }
        }    // confusion ase

        private void textBox2_KeyDown(object sender, KeyEventArgs e)    // chat text key down event
        {
            if (client != null && client.IsConnected && e.KeyCode == Keys.Enter)
            {
                client.Send(textBox2.Text);
                textBox2.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)    // connect
        {
            if(textBox4.Text.IndexOf("Admin")>=0 )
            {
                MessageBox.Show("You Can't use Admin as your username.");
            }
            else if (textBox4.Text != "" && textBox3.Text != "" && textBox5.Text != "")
            {
                client = new Client();
                client.ServerIp = textBox3.Text;
                client.ClientName = textBox4.Text;
                client.ServerPort = textBox5.Text;

                client.OnClientConnected += new OnClientConnectedDelegate(client_OnClientConnected);
                client.OnClientConnecting += new OnClientConnectingDelegate(client_OnClientConnecting);
                client.OnClientDisconnected += new OnClientDisconnectedDelegate(client_OnClientDisconneted);
                client.OnClientError += new OnClientErrorDelegate(client_OnClientError);
                client.OnClientFileSending += new OnClientFileSendingDelegate(client_OnClientFileSending);
                client.OnDataReceived += new OnClientReceivedDelegate(client_OnDataReceived);

                client.Connect();
            }
            else
            {
                MessageBox.Show("You Must Fill All TextBoxes Before Click Connect Button");
            }
        }

        private void client_OnDataReceived(object Sender, ClientReceivedArguments R)
        {
            ChangeTextBox(R.ReceivedData);
        }

        private void client_OnClientFileSending(object Sender, ClientFileSendingArguments R)
        {
            MessageBox.Show("Sending Failed");
        }

        private void client_OnClientError(object Sender, ClientErrorArguments R)
        {
            ChangeTextBox(R.ErrorMessage);
        }

        private void client_OnClientDisconneted(object Sender, ClientDisconnectedArguments R)
        {
            ChangeTextBox(R.EventMessage);
        }

        private void client_OnClientConnecting(object Sender, ClientConnectingArguments R)
        {
            ChangeTextBox(R.EventMessage);
        }

        private void client_OnClientConnected(object Sender, ClientConnectedArguments R)
        {
            ChangeTextBox(R.EventMessage);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)  // client name
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)  // server name
        {

        }

        private void button1_Click(object sender, EventArgs e)   // send
        {
            if(client != null && client.IsConnected)
            {
                client.Send(textBox2.Text);
                textBox2.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)    // clear
        {
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // chat log
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)  // chat text
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //System.Environment.Exit(System.Environment.ExitCode);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }
    }
}
