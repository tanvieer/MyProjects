using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DbMethod;
using MetroFramework;

namespace MetroArcane
{
    public partial class TagForm : MetroFramework.Forms.MetroForm
    {
        public bool editStatus = false;
        public DbMethod.Tag oldTag;
        private DbTags dt = new DbTags();
        private int WebId;
        private Form1 F1;
        DataGridViewImageColumn button_edit;
        DataGridViewImageColumn button_remove;
        public TagForm(int id, Form1 f1)
        {
            F1 = f1;
            WebId = id;
            InitializeComponent();
        }

        private void TagForm_Load(object sender, EventArgs e)
        {
            ShowInTaskbar = false;

            metroGrid1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            metroGrid1.AllowUserToResizeRows = false;

            LoadTags();

            button_edit = new DataGridViewImageColumn();
            metroGrid1.Columns.Add(button_edit);
            button_edit.HeaderText = "Actions";
            button_edit.Name = "button_edit";
            button_edit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            button_edit.Image = Properties.Resources.edit;
            button_edit.ImageLayout = DataGridViewImageCellLayout.Zoom;
            button_edit.DefaultCellStyle.BackColor = Color.AliceBlue;

            //DataGridViewButtonColumn button_remove = new DataGridViewButtonColumn();
            //metroGrid1.Columns.Add(button_remove);
            //button_remove.HeaderText = "";
            //button_remove.Text = "Remove";
            //button_remove.Name = "button_remove";
            //button_remove.Width = Convert.ToInt32(metroGrid1.Width * .075);
            //button_remove.FlatStyle=FlatStyle.Flat;

            //button_remove.UseColumnTextForButtonValue = true;

            button_remove = new DataGridViewImageColumn();
            metroGrid1.Columns.Add(button_remove);
            button_remove.HeaderText = "";
            button_remove.Name = "button_remove";
            button_remove.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            button_remove.Image = Properties.Resources.trash2;
            button_remove.ImageLayout = DataGridViewImageCellLayout.Zoom;
            button_remove.DefaultCellStyle.BackColor = Color.AliceBlue;

            SetGridWidths();

            metroGrid1.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;

            metroGrid1.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepSkyBlue;
            metroGrid1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 210, 229, 255);

            metroGrid1.RowHeadersDefaultCellStyle.BackColor = Color.DeepSkyBlue;
            metroGrid1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 210, 229, 255);

            //metroGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;

            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(metroButtonSaveTags, "Add Tag");
            toolTip1.SetToolTip(metroButtonBack, "Back");
            //toolTip1.SetToolTip(metroButtonSettings, "Password and SMTP Settings");
            //toolTip1.SetToolTip(metroButton_add, "Add New Website");
        }

        public void SetGridWidths()
        {

            try
            {
                metroGrid1.Columns[0].Width = Convert.ToInt32((metroGrid1.Width - metroGrid1.RowHeadersWidth) * .28);
                metroGrid1.Columns[1].Width = Convert.ToInt32((metroGrid1.Width - metroGrid1.RowHeadersWidth) * .28);
                metroGrid1.Columns[2].Width = Convert.ToInt32((metroGrid1.Width - metroGrid1.RowHeadersWidth) * .28);
            }
            catch 
            {

            }

            button_edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            button_remove.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            button_edit.Width = Convert.ToInt32((metroGrid1.Width - metroGrid1.RowHeadersWidth) * .08);
            button_remove.Width = Convert.ToInt32((metroGrid1.Width - metroGrid1.RowHeadersWidth) * .08);


        }
        private void LoadTags()
        {
            LoadTag();
        }
        private void LoadTag()
        {
            using (var context = new DemoModelEntitiesDataContext())
            {
                var result = from tag in context.Tags
                             where tag.WebsiteID == WebId
                             select new
                             {
                                 tag.TagName,
                                 tag.AttributeName,
                                 tag.AttributeValue
                             };
                metroGrid1.DataSource = result;

            }

            // metroGrid1.DataSource = dt.LoadTag();
            //metroGrid1.Columns["WebsiteID"].Visible = false;
            metroGrid1.Columns["TagName"].HeaderText = "Tag Name";
            metroGrid1.Columns["AttributeName"].HeaderText = "Attribute Name";
            metroGrid1.Columns["AttributeValue"].HeaderText = "Attribute Value";




        }
        public void changeUrl(string s)
        {
            this.metroLabel_url.Text = s;
        }

        private void metroButtonSaveTags_Click(object sender, EventArgs e)
        {
            if(metroTextBoxTagName.Text=="" || metroTextBoxAttributeName.Text=="" || metroTextBoxAttributeValue.Text=="")
            {
                editStatus = false;
                return;
            }
            DbMethod.Tag newTag = new DbMethod.Tag();
            newTag.WebsiteID = WebId;
            newTag.TagName = metroTextBoxTagName.Text;
            newTag.AttributeName = metroTextBoxAttributeName.Text;
            newTag.AttributeValue = metroTextBoxAttributeValue.Text;

            if (editStatus)
            {
                if(dt.UpdateTags(newTag, oldTag))
                {
                    MetroMessageBox.Show(this, "Update Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
                else
                {
                    MetroMessageBox.Show(this, "Invalid Request", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (dt.AddTags(newTag))
                {
                    MetroMessageBox.Show(this, "Insertion Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
                else
                {
                    MetroMessageBox.Show(this, "Invalid Request", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadTag();
            editStatus = false;
        }





        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {

                if (metroGrid1.Columns[e.ColumnIndex].Name.ToString() == "button_edit")
                {
                    editStatus = true;
                    oldTag = new DbMethod.Tag();
                    oldTag.WebsiteID = WebId;
                    oldTag.TagName = metroGrid1.Rows[e.RowIndex].Cells["TagName"].Value.ToString();
                    oldTag.AttributeName = metroGrid1.Rows[e.RowIndex].Cells["AttributeName"].Value.ToString();
                    oldTag.AttributeValue = metroGrid1.Rows[e.RowIndex].Cells["AttributeValue"].Value.ToString();

                    metroTextBoxTagName.Text = oldTag.TagName;
                    metroTextBoxAttributeName.Text = oldTag.AttributeName;
                    metroTextBoxAttributeValue.Text = oldTag.AttributeValue;

                }
                else if (metroGrid1.Columns[e.ColumnIndex].Name.ToString() == "button_remove")
                {
                    oldTag = new DbMethod.Tag();
                    oldTag.TagName = metroGrid1.Rows[e.RowIndex].Cells["TagName"].Value.ToString();
                    oldTag.AttributeName = metroGrid1.Rows[e.RowIndex].Cells["AttributeName"].Value.ToString();
                    oldTag.AttributeValue = metroGrid1.Rows[e.RowIndex].Cells["AttributeValue"].Value.ToString();

                    dt.RemoveTag(WebId, oldTag.TagName, oldTag.AttributeName, oldTag.AttributeValue);
                    LoadTag();
                }
            }
            catch
            {

            }
        }

        private void metroGrid1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = null;
            if (metroGrid1.SelectedRows.Count > 0)
            {
                selectedRow = metroGrid1.SelectedRows[0];
            }
            if (selectedRow == null)
            {
                return;
            }
        }

        private void clear()
        {
            metroTextBoxTagName.Clear();
            metroTextBoxAttributeName.Clear();
            metroTextBoxAttributeValue.Clear();
        }

        private void metroButtonBack_Click(object sender, EventArgs e)
        {
            Close();
            F1.Activate();
        }

       
    }
}
