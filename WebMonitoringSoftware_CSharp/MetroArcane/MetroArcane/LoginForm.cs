using DbMethod;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetroArcane
{
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        private DbMethods dm = new DbMethods();
        private MetroFramework.Forms.MetroForm F;
        private bool formStatus=false; //false maane form theke ashenai, reg form theke ashche

        public LoginForm(MetroFramework.Forms.MetroForm f)
        {
            InitializeComponent();
            F = f;
        }

        public LoginForm(MetroFramework.Forms.MetroForm f, bool t)
        {
            formStatus = t;
            InitializeComponent();
            F = f;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ShowInTaskbar = false;
        }

        private void metroTextButton1_Click(object sender, EventArgs e)
        {
            if (BackgroundProject.BackGroundWork.IsConnectedToInternet())
            {
                Thread t = new Thread(() => BackgroundProject.BackGroundWork.Sendmail(dm.ForgotPasswordMail(), "Admin Password", "Your Password is :  " + dm.ForgotPassword()));
                t.Start();

                //BackgroundProject.BackGroundWork.Sendmail(dm.ForgotPasswordMail(), "WHM Pass", "Your Password is :  "+dm.ForgotPassword());
                string mail = "A mail will be sent to " + dm.ForgotPasswordMail() + " with your password shortly!";
                MetroMessageBox.Show(this, mail, "Mail Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MetroMessageBox.Show(this, "Internet Connection Not Available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (metroTextBox1.Text=="")
                {
                    metroLabel_wrong.Text = "Password is Required!";
                    metroLabel_wrong.Location = new Point(120, 140);
                    return;
                }

                if (dm.CheckLogin(metroTextBox1.Text))
                {
                    F.Show();
                    F.Activate();
                    Close();
                }
                else
                {
                    metroLabel_wrong.Text = "Wrong Password!";
                    metroLabel_wrong.Location = new Point(134, 140);
                }
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (formStatus) Application.Exit();
            else F.Activate();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "")
            {
                metroLabel_wrong.Text = "Password is Required!";
                metroLabel_wrong.Location = new Point(120, 140);
                return;
            }

            if (dm.CheckLogin(metroTextBox1.Text))
            {
                F.Show();
                F.Activate();
                if (formStatus)
                    Hide();
                else
                     Close();
            }
            else
            {
                metroLabel_wrong.Text = "Wrong Password!";
                metroLabel_wrong.Location = new Point(134, 140);
            }

        }
    }
}
