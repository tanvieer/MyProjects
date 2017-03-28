using DbMethod;
using MetroFramework;
using System;
using System.Windows.Forms;

namespace MetroArcane
{
    public partial class AddWebsite : MetroFramework.Forms.MetroForm
    {
        private DbMethods dm=new DbMethods();
        Form1 F1;
        public AddWebsite(Form1 f1)
        {
            F1 = f1;
            InitializeComponent();
        }

        private void AddDeleteWebsite_Load(object sender, EventArgs e)
        {
            ShowInTaskbar = false;
            //metroComboBox_day.SelectedIndex = 0;
            //metroComboBox_hour.SelectedIndex = 0;
            //comboBox1.SelectedIndex = 0;

            Activate();

             /*
                        1) Set the AutoCompleteMode property to AutoCompleteMode.SuggestAppend

                        2) Set the AutoCompleteSource property to AutoCompleteSource.CustomSource

                        3) Set the AutoCompleteCustomSource property to an AutoCompleteStringCollection of your possible matches.
            */
        }

        private void metroButtonDelete_Click(object sender, EventArgs e)
        {
            Close();
            F1.Activate();
        }


        private void metroButtonSave_Click(object sender, EventArgs e)
        {
            bool status = false;
            if (dm.IsValidEmail(metroTextBoxMailTo.Text))
                {
                    status = dm.AddWebsite(metroTextBoxWebsite.Text, metroTextBoxMailTo.Text, comboBox1.Text, comboBox2.Text);
                }
            

            if(status)
            {
                F1.LoadDAta();
                metroTextBoxMailTo.Clear();
                metroTextBoxWebsite.Clear();
                comboBox1.Text = "Select";
                comboBox2.Text = "Select";
                MetroMessageBox.Show(this, "Website Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MetroMessageBox.Show(this, "Invalid Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddWebsite_FormClosed(object sender, FormClosedEventArgs e)
        {
            F1.Activate();
        }
    }
}
