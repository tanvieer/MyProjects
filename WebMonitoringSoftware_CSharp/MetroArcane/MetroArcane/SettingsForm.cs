using MetroFramework;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MetroArcane
{
    public partial class SettingsForm : MetroFramework.Forms.MetroForm
    {
        Form1 F1;
        //string oldpw = "";
        public SettingsForm(Form1 f)
        {
            InitializeComponent();
            F1 = f;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ShowInTaskbar = false;
            using (var context = new DemoModelEntitiesDataContext())
            {
                try
                {
                    foreach (var li in context.SmtpSettings)
                    {
                        metroTextBoxSMTPmail.Text = li.Email.ToString();
                        if (li.Password.ToString() != "") metroTextBoxPass.Text = EncryptionDecryption.EncryptDecrypt.Decrypt(li.Password.ToString());
                        metroTextBoxSMTP.Text = li.SmtpServer.ToString();
                        metroTextBoxPort.Text = li.Port.ToString();
                        break;
                    }
                }
                catch
                {

                }
                

            }


            using (var context = new DemoModelEntitiesDataContext())
            {
                foreach (var li in context.LoginInfos)
                {
                    metroTextBoxAdminMail.Text = li.Email.ToString();
                    //oldpw = EncryptionDecryption.EncryptDecrypt.Decrypt(li.Password.ToString());
                    break;
                }

            }
        }

        private void metroButtonSave_Click(object sender, EventArgs e)
        {
            using (DemoModelEntitiesDataContext db = new DemoModelEntitiesDataContext())
            {

                SmtpSetting smt = (db.SmtpSettings.SingleOrDefault(x => x.Id == 1));
                smt.Email = metroTextBoxSMTPmail.Text;
                smt.Password = 
                   EncryptionDecryption.EncryptDecrypt.Encrypt( metroTextBoxPass.Text);
                smt.SmtpServer = metroTextBoxSMTP.Text;
                smt.Port = Convert.ToInt32(metroTextBoxPort.Text);
                smt.Id = 1;
                db.SubmitChanges();

                MetroMessageBox.Show(this, "SMTP Settings Saved", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void metroButtonUpdateSystemPW_Click_1(object sender, EventArgs e)
        {
            if (metroTextBoxConfirmPW.Text == "" && metroTextBoxNewPW.Text == "")
            {
                using (DemoModelEntitiesDataContext db = new DemoModelEntitiesDataContext())
                {

                    var li = (db.LoginInfos.SingleOrDefault(x => x.Id == 1));
                    if (metroTextBoxAdminMail.Text != "")
                    {
                        li.Email = metroTextBoxAdminMail.Text;
                        db.SubmitChanges();

                        MetroMessageBox.Show(this, "Email Update Succesful!", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "All fields are empty! Nothing Changed...", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            else if (metroTextBoxNewPW.Text != metroTextBoxConfirmPW.Text)
            {
                MetroMessageBox.Show(this, "Passwords do not match!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (metroTextBoxConfirmPW.Text != "" && metroTextBoxNewPW.Text == metroTextBoxConfirmPW.Text)
            {
                using (DemoModelEntitiesDataContext db = new DemoModelEntitiesDataContext())
                {

                    var li = (db.LoginInfos.SingleOrDefault(x => x.Id == 1));
                    li.Password = EncryptionDecryption.EncryptDecrypt.Encrypt(metroTextBoxConfirmPW.Text);
                    if (metroTextBoxAdminMail.Text != "")
                    {
                        li.Email = metroTextBoxAdminMail.Text;
                        db.SubmitChanges();

                        MetroMessageBox.Show(this, "All Updates Succesful!", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        db.SubmitChanges();

                        MetroMessageBox.Show(this, "Password Update Succesful!", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            
            else MetroMessageBox.Show(this, "Please fill up required fields to update system password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            F1.Activate();
        }
    }
}
