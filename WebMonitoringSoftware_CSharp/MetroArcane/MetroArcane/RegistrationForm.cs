using MetroFramework;
using System;
using System.Windows.Forms;

namespace MetroArcane
{
    public partial class RegistrationForm : MetroFramework.Forms.MetroForm
    {
        DbMethod.DbMethods dm=new DbMethod.DbMethods();

        public RegistrationForm()
        {
            InitializeComponent();

        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            Activate();
        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void metroButtonRegister_Click_1(object sender, EventArgs e)
        {
            string email, pw, cpw;
            email = metroTextBoxEmail.Text;
            pw = metroTextBoxPassword.Text;
            cpw = metroTextBoxConfirmPW.Text;

            if(email=="" || pw=="" || cpw=="")
            {
                MetroMessageBox.Show(this, "Fields cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(!pw.Equals(cpw))
            {
                MetroMessageBox.Show(this, "Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(!dm.IsValidEmail(email))
            {
                MetroMessageBox.Show(this, "Invalid Email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                dm.Registration(email, pw);
                Form1 F1 = new Form1(true);  
                F1.Show();
                F1.Activate();
                this.Hide();
                
            }
        }
    }
}
