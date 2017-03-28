using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworksApi.TCP.SERVER;

namespace AdvancedServer
{
    public delegate void UpdateChatLog(string txt);
    public delegate void UpdateListBox(ListBox box, string value, bool remove);
    public partial class Form1 : Form
    {
        Server server;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void ChangeChatLog(string txt)
        {
            if (textBox1.InvokeRequired)    // bujhi nai
            {
                Invoke(new UpdateChatLog(ChangeChatLog), new object[] { txt });
            }
            else
            {
                textBox1.Text += txt + "\r\n";    // new line in chat log
            }
        }

        private void ChangeListBox(ListBox box, string value , bool remove)
        {
            if (box.InvokeRequired)    // bujhi nai
            {
                Invoke(new UpdateListBox(ChangeListBox), new object[] { box,value, remove });
            }
            else
            {
                if (remove)
                {
                    box.Items.Remove(value);
                }
                else
                    box.Items.Add(value);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.SendTo((string)listBox1.SelectedItem, "Admin : "+textBox2.Text);
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            server.BroadCast("Admin: "+textBox2.Text);
            textBox1.Text += "\r\n"+ "Admin: " + textBox2.Text;

            using (System.IO.StreamWriter file =
                 new System.IO.StreamWriter(@"ChatHistory.txt", true))
            {
                file.WriteLine("Admin: " + textBox2.Text);
            }
            // textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            server.DisconnectClient((string)listBox1.SelectedItem);
            using (System.IO.StreamWriter file =
                 new System.IO.StreamWriter(@"ChatHistory.txt", true))
            {
                file.WriteLine((string)listBox1.SelectedItem + " : " + listBox2.SelectedItem +" Kicked!!");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new Server("192.168.0.103", "8888");
            server.OnClientConnected += new OnConnectedDelegate(client_OnClientConnected);
            server.OnClientDisconnected += new OnDisconnectedDelegate(client_OnClientDisconnected);
            server.OnDataReceived += new OnReceivedDelegate(client_OnDataReceived);
            server.OnServerError += new OnErrorDelegate(client_OnServerError);
            server.Start();

            using (System.IO.StreamWriter file =
                 new System.IO.StreamWriter(@"ChatHistory.txt", true))
            {
                file.WriteLine("===========================================================\r\n Server Started !! At  TIME: " + string.Format("{0:HH:mm:ss}", DateTime.Now)+ "    DATE: "+ DateTime.Today.ToString("dd-MMM-yyyy") + "\r\n===========================================================");
            }
        }

        private void client_OnServerError(object Sender, ErrorArguments R)
        {
            MessageBox.Show(R.ErrorMessage);
            using (System.IO.StreamWriter file =
                 new System.IO.StreamWriter(@"ChatHistory.txt", true))
            {
                file.WriteLine(R.ErrorMessage);
            }
        }

        private void client_OnDataReceived(object Sender, ReceivedArguments R)
        {
            ChangeChatLog(R.ReceivedData);
            server.BroadCast(R.Name + " : " + R.ReceivedData);
            using (System.IO.StreamWriter file =
                 new System.IO.StreamWriter(@"ChatHistory.txt", true))
            {
                file.WriteLine(R.Name + " : " + R.ReceivedData);
            }

        }

        private void client_OnClientDisconnected(object Sender, DisconnectedArguments R)
        {
            server.BroadCast(R.Name + " Has Disconneted!!");
            using (System.IO.StreamWriter file =
                 new System.IO.StreamWriter(@"ChatHistory.txt", true))
            {
                file.WriteLine(R.Name +" : "+ R.Ip+ "  Has Disconneted!!");
            }
            ChangeListBox(listBox1, R.Name, true);
            ChangeListBox(listBox2, R.Ip, true);
        }

        private void client_OnClientConnected(object Sender, ConnectedArguments R)
        {
            server.BroadCast(R.Name + " Has Conneted!!");
            ChangeListBox(listBox1, R.Name, false);
            ChangeListBox(listBox2, R.Ip, false);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox1.SelectedIndex;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = listBox2.SelectedIndex;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                server.BroadCast("Admin: " + textBox2.Text);
                textBox1.Text += "\r\n" + "Admin: " + textBox2.Text;
                using (System.IO.StreamWriter file =
                 new System.IO.StreamWriter(@"ChatHistory.txt", true))
                {
                    file.WriteLine("Admin: " + textBox2.Text);
                }


                textBox2.Clear();
            }
                
        }
    }
}
