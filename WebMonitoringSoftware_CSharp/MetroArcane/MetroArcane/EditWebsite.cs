using System;
using System.Linq;
using System.Windows.Forms;
using DbMethod;
using MetroFramework;
using MetroFramework.Forms;

namespace MetroArcane
{
    public partial class EditWebsite : MetroForm
    {
        private DbMethods dm = new DbMethods();
        private int webId;
        Form1 F1;
        public EditWebsite(int id, string name, string mailTo, int interval, Form1 f)
        {
            InitializeComponent();
            metroTextBoxWebsite.Text = name;
            metroTextBoxMailTo.Text = mailTo;
            comboBox1.Text = (interval / 24).ToString();
            comboBox2.Text = (interval % 24).ToString();
            webId = id;
            F1 = f;
            
        }

        private void EditWebsite_Load(object sender, EventArgs e)
        {
            ShowInTaskbar = false;
            Activate();
            metroTextBoxWebsite.Focus();
        }

        private void metroButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
            F1.Activate();
        }

        private void metroButtonUpdate_Click(object sender, EventArgs e)
        {
            using (DemoModelEntitiesDataContext db = new DemoModelEntitiesDataContext())
            {
                if (updateValidation())
                {
                    if (dm.IsValidEmail(metroTextBoxMailTo.Text))
                    {
                        Website web = (db.Websites.SingleOrDefault(x => x.Id == webId));
                        web.Name = metroTextBoxWebsite.Text;
                        web.MailTo = metroTextBoxMailTo.Text;
                        web.CheckInterval = DbMethods.convertCheckInterval(comboBox1.Text.ToString(), comboBox2.Text.ToString());
                        if(web.CheckInterval==-1)
                        {
                            MetroMessageBox.Show(this, "Invalid Interval Input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        db.SubmitChanges();
                        F1.LoadDAta();
                        MetroMessageBox.Show(this, "Website Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else MetroMessageBox.Show(this, "Invalid Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MetroMessageBox.Show(this, "Invalid Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private bool updateValidation()
        {
            if (metroTextBoxWebsite.Text == "" || metroTextBoxMailTo.Text == "")
            {
                return false;
            }
            using (DemoModelEntitiesDataContext db = new DemoModelEntitiesDataContext())
            {
                var results = (db.Websites.SingleOrDefault(x => x.Name == metroTextBoxWebsite.Text && x.Id != webId));
                if (results == null)
                {
                    return true;
                }
            }
            return false;
        }

        private void EditWebsite_FormClosed(object sender, FormClosedEventArgs e)
        {
            F1.Activate();
        }
    }
}
