using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BackgroundProject;
using DbMethod;
using MetroArcane.Properties;
using MetroFramework.Forms;

namespace MetroArcane
{
    public partial class Form1 : MetroForm
    {
        private DbMethods dm = new DbMethods();

        private DataGridViewImageColumn button_tags;
        private DataGridViewImageColumn button_edit;
        private DataGridViewImageColumn button_remove;

        public Form1()
        {
            InitializeComponent();
            metroButtonRun.Enabled = true;
            metroButtonStop.Enabled = false;
        }
        public Form1(bool t)
        {
            InitializeComponent();
            metroButtonRun.Enabled = true;
            metroButtonStop.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            metroGrid1.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 250, 255);

            LoadDAta();

            button_tags = new DataGridViewImageColumn();
            //button_tags.SortMode = DataGridViewColumnSortMode.NotSortable;
            button_tags.Image = Resources.tags2;
            metroGrid1.Columns.Add(button_tags);
            button_tags.HeaderText = "Tags";
            button_tags.Name = "button_tags";
            button_tags.Width = Convert.ToInt32((metroGrid1.Width - metroGrid1.RowHeadersWidth) * .1);
            button_tags.ImageLayout = DataGridViewImageCellLayout.Zoom;
            button_tags.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            button_tags.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control);

            button_edit = new DataGridViewImageColumn();
            metroGrid1.Columns.Add(button_edit);
            button_edit.HeaderText = "Edit";
            button_edit.Name = "button_edit";
            button_edit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            button_edit.Image = Resources.edit;
            button_edit.ImageLayout = DataGridViewImageCellLayout.Zoom;
            button_edit.DefaultCellStyle.BackColor = Color.AliceBlue;

            button_remove = new DataGridViewImageColumn();
            metroGrid1.Columns.Add(button_remove);
            button_remove.HeaderText = "Remove";
            button_remove.Name = "button_remove";
            button_remove.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            button_remove.Image = Resources.trash2;
            button_remove.ImageLayout = DataGridViewImageCellLayout.Zoom;
            button_remove.DefaultCellStyle.BackColor = Color.AliceBlue;


            SetGridWidths();

            metroGrid1.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;

            metroGrid1.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepSkyBlue;
            metroGrid1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 210, 229, 255);

            metroGrid1.RowHeadersDefaultCellStyle.BackColor = Color.DeepSkyBlue;
            metroGrid1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 210, 229, 255);

            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;

            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(metroButtonRun, "Run Web Hack Monitor");
            toolTip1.SetToolTip(metroButtonStop, "Halt Execution of Web Hack Monitor");
            toolTip1.SetToolTip(metroButtonSettings, "Password and SMTP Settings");
            toolTip1.SetToolTip(metroButton_add, "Add New Website");


        }

        public void SetGridWidths()
        {
            
            try
            {
                metroGrid1.Columns[0].Width = Convert.ToInt32((metroGrid1.Width - metroGrid1.RowHeadersWidth) * .2);
                metroGrid1.Columns[1].Width = Convert.ToInt32((metroGrid1.Width - metroGrid1.RowHeadersWidth) * .2);
                metroGrid1.Columns[2].Width = Convert.ToInt32((metroGrid1.Width - metroGrid1.RowHeadersWidth) * .13);
                metroGrid1.Columns[3].Width = Convert.ToInt32((metroGrid1.Width - metroGrid1.RowHeadersWidth) * .135);
                metroGrid1.Columns[4].Width = Convert.ToInt32((metroGrid1.Width - metroGrid1.RowHeadersWidth) * .135);
            }
            catch
            {

            }

            button_tags.AutoSizeMode= DataGridViewAutoSizeColumnMode.None; 
            button_edit.AutoSizeMode= DataGridViewAutoSizeColumnMode.None; 
            button_remove.AutoSizeMode= DataGridViewAutoSizeColumnMode.None;

            button_tags.Width= Convert.ToInt32((metroGrid1.Width - metroGrid1.RowHeadersWidth) * .1);
            button_edit.Width= Convert.ToInt32((metroGrid1.Width - metroGrid1.RowHeadersWidth) * .05);
            button_remove.Width= Convert.ToInt32((metroGrid1.Width - metroGrid1.RowHeadersWidth) * .05);


        }


        public void LoadDAta()
        {
            BindingSource bs = new BindingSource();
            //using (var context = new DemoModelEntitiesDataContext())
            //{
            //    var result = from web in context.Websites
            //                 select new
            //                 {
            //                     web.Name,
            //                     web.MailTo,
            //                     web.Status,
            //                     web.LastCheckedAt,
            //                     web.NextCheckAt
            //                 };
            //    metroGrid1.DataSource = result.ToList();

            //}

            //=======================================================
            metroGrid1.DataSource = dm.LoadGridData().ToList();

            metroGrid1.Columns["Id"].Visible = false;
            metroGrid1.Columns["CheckInterval"].Visible = false;

            metroGrid1.Columns["MailTo"].DisplayIndex = 3;
            metroGrid1.Columns["Status"].DisplayIndex = 2;
            metroGrid1.Columns["LastCheckedAt"].DisplayIndex = 4;
            metroGrid1.Columns["NextCheckAt"].DisplayIndex = 5;

            metroGrid1.Columns["Name"].HeaderText = "Websites";
            metroGrid1.Columns["MailTo"].HeaderText = "Mail To";
            metroGrid1.Columns["LastCheckedAt"].HeaderText = "Last Checked Time";
            metroGrid1.Columns["NextCheckAt"].HeaderText = "Next Check Time";


            // metroGrid1.Columns[0].Name = "Website";
            //  metroGrid1.Columns[0].DataPropertyName = "Name";



            //=======================================================
            StatusColor();
            
            
        }

        private void StatusColor()
        {
            foreach (DataGridViewRow rrow in metroGrid1.Rows)   // Status coloring
            {

                if (metroGrid1.Rows[rrow.Index].Cells["Status"].Value != null && metroGrid1.Rows[rrow.Index].Cells["Status"].Value.ToString() == "Compromised")
                {
                    metroGrid1["Status", rrow.Index].Style.BackColor = Color.MistyRose;
                }
                else if (metroGrid1.Rows[rrow.Index].Cells["Status"].Value != null && metroGrid1.Rows[rrow.Index].Cells["Status"].Value.ToString() == "OK")
                {
                    metroGrid1["Status", rrow.Index].Style.BackColor = Color.Honeydew;
                }

            }
        }

        //=====================================================

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

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void metroButtonSettings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm(this);
            LoginForm f4 = new LoginForm(sf);
            f4.Show();
            f4.Activate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(WindowState==FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            AddWebsite aw = new AddWebsite(this);
            
            aw.Show();
            aw.Activate();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void metroButtonRun_Click(object sender, EventArgs e)
        {
            LoadDAta();
            timer1.Start();
            metroButtonRun.Enabled = false;
            metroButtonStop.Enabled = true;
            notifyIcon2.BalloonTipTitle = "Web Hack Monitor";
            notifyIcon2.BalloonTipText = "Started Checking";
            notifyIcon2.Visible = true;
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;
            notifyIcon2.ShowBalloonTip(1000);

        }

        private void metroButtonStop_Click(object sender, EventArgs e)
        {
            LoadDAta();
            timer1.Stop();
            metroButtonRun.Enabled = true;
            metroButtonStop.Enabled = false;
            notifyIcon2.BalloonTipTitle = "Web Hack Monitor";
            notifyIcon2.BalloonTipText = "Stopped Checking";
            pictureBox1.Enabled = false;
            notifyIcon2.Visible = true;
            notifyIcon2.ShowBalloonTip(1000);
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = -1;
            try {

                if (metroGrid1.Columns[e.ColumnIndex].Name.ToString() == "button_tags")
                {

                    id = dm.GetWebId(metroGrid1.Rows[e.RowIndex].Cells["Name"].Value.ToString());

                    TagForm f2 = new TagForm(id, this);
                    f2.changeUrl(metroGrid1.Rows[e.RowIndex].Cells["Name"].Value.ToString());
                    f2.Show();

                }
                else if (metroGrid1.Columns[e.ColumnIndex].Name.ToString() == "button_edit")
                {

                    using (var context = new DemoModelEntitiesDataContext())
                    {
                        Website web = (context.Websites.SingleOrDefault(x => x.Name == metroGrid1.Rows[e.RowIndex].Cells["Name"].Value.ToString()));
                        EditWebsite ew = new EditWebsite(web.Id, web.Name, web.MailTo, web.CheckInterval, this);
                        ew.Show();
                    }
                }
                else if (metroGrid1.Columns[e.ColumnIndex].Name.ToString() == "button_remove")
                {
                    dm.RemoveWebsite(metroGrid1.Rows[e.RowIndex].Cells["Name"].Value.ToString());
                    LoadDAta();
                }
            }
            catch
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BackGroundWork.Run();
            LoadDAta();
           
        }

        private void notifyIcon2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon2_BalloonTipClicked(object sender, EventArgs e)
        {

        }

        //start button
        private void metroButtonRun_Enter(object sender, EventArgs e)
        {
            metroButtonRun.BackColor = Color.FromArgb(255, 210, 229, 255);
        }

        private void metroButtonRun_Leave(object sender, EventArgs e)
        {
            metroButtonRun.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void metroButtonRun_MouseEnter(object sender, EventArgs e)
        {
            metroButtonRun.BackColor = Color.FromArgb(255, 210, 229, 255); 
        }

        private void metroButtonRun_MouseLeave(object sender, EventArgs e)
        {
            metroButtonRun.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        //stop button
        private void metroButtonStop_MouseEnter(object sender, EventArgs e)
        {
            metroButtonStop.BackColor = Color.FromArgb(255, 210, 229, 255);
        }

        private void metroButtonStop_MouseLeave(object sender, EventArgs e)
        {
            metroButtonStop.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void metroButtonStop_Enter(object sender, EventArgs e)
        {
            metroButtonStop.BackColor = Color.FromArgb(255, 210, 229, 255);
        }

        private void metroButtonStop_Leave(object sender, EventArgs e)
        {
            metroButtonStop.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        //settings button
        private void metroButtonSettings_MouseEnter(object sender, EventArgs e)
        {
            metroButtonSettings.BackColor = Color.FromArgb(255, 210, 229, 255);
        }

        private void metroButtonSettings_MouseLeave(object sender, EventArgs e)
        {
            metroButtonSettings.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void metroButtonSettings_Enter(object sender, EventArgs e)
        {
            metroButtonSettings.BackColor = Color.FromArgb(255, 210, 229, 255);
        }

        private void metroButtonSettings_Leave(object sender, EventArgs e)
        {
            metroButtonSettings.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        //add website button
        private void metroButton_add_Enter(object sender, EventArgs e)
        {
            metroButton_add.BackColor = Color.FromArgb(255, 210, 229, 255);
        }

        private void metroButton_add_Leave(object sender, EventArgs e)
        {
            metroButton_add.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void metroButton_add_MouseEnter(object sender, EventArgs e)
        {
            metroButton_add.BackColor = Color.FromArgb(255, 210, 229, 255);
        }

        private void metroButton_add_MouseLeave(object sender, EventArgs e)
        {
            metroButton_add.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
    }

}
