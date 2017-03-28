namespace MetroArcane
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroButton_add = new MetroFramework.Controls.MetroButton();
            this.metroButtonSettings = new MetroFramework.Controls.MetroButton();
            this.metroButtonStop = new MetroFramework.Controls.MetroButton();
            this.metroButtonRun = new MetroFramework.Controls.MetroButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            this.metroPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.pictureBox1);
            this.metroPanel3.Controls.Add(this.metroButton_add);
            this.metroPanel3.Controls.Add(this.metroButtonSettings);
            this.metroPanel3.Controls.Add(this.metroButtonStop);
            this.metroPanel3.Controls.Add(this.metroButtonRun);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(20, 487);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(1160, 73);
            this.metroPanel3.TabIndex = 2;
            this.metroPanel3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::MetroArcane.Properties.Resources.check1;
            this.pictureBox1.Location = new System.Drawing.Point(311, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // metroButton_add
            // 
            this.metroButton_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton_add.BackColor = System.Drawing.SystemColors.Control;
            this.metroButton_add.BackgroundImage = global::MetroArcane.Properties.Resources.Programming_Add_Property_icon_2;
            this.metroButton_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroButton_add.ForeColor = System.Drawing.SystemColors.WindowText;
            this.metroButton_add.Highlight = true;
            this.metroButton_add.Location = new System.Drawing.Point(980, 40);
            this.metroButton_add.Name = "metroButton_add";
            this.metroButton_add.Size = new System.Drawing.Size(180, 30);
            this.metroButton_add.TabIndex = 5;
            this.metroButton_add.UseCustomBackColor = true;
            this.metroButton_add.UseCustomForeColor = true;
            this.metroButton_add.UseSelectable = true;
            this.metroButton_add.UseStyleColors = true;
            this.metroButton_add.Click += new System.EventHandler(this.metroButton1_Click);
            this.metroButton_add.Enter += new System.EventHandler(this.metroButton_add_Enter);
            this.metroButton_add.Leave += new System.EventHandler(this.metroButton_add_Leave);
            this.metroButton_add.MouseEnter += new System.EventHandler(this.metroButton_add_MouseEnter);
            this.metroButton_add.MouseLeave += new System.EventHandler(this.metroButton_add_MouseLeave);
            // 
            // metroButtonSettings
            // 
            this.metroButtonSettings.BackColor = System.Drawing.SystemColors.Control;
            this.metroButtonSettings.BackgroundImage = global::MetroArcane.Properties.Resources.settings2;
            this.metroButtonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroButtonSettings.Location = new System.Drawing.Point(198, 40);
            this.metroButtonSettings.Name = "metroButtonSettings";
            this.metroButtonSettings.Size = new System.Drawing.Size(90, 30);
            this.metroButtonSettings.TabIndex = 4;
            this.metroButtonSettings.UseSelectable = true;
            this.metroButtonSettings.Click += new System.EventHandler(this.metroButtonSettings_Click);
            this.metroButtonSettings.Enter += new System.EventHandler(this.metroButtonSettings_Enter);
            this.metroButtonSettings.Leave += new System.EventHandler(this.metroButtonSettings_Leave);
            this.metroButtonSettings.MouseEnter += new System.EventHandler(this.metroButtonSettings_MouseEnter);
            this.metroButtonSettings.MouseLeave += new System.EventHandler(this.metroButtonSettings_MouseLeave);
            // 
            // metroButtonStop
            // 
            this.metroButtonStop.BackColor = System.Drawing.SystemColors.Control;
            this.metroButtonStop.BackgroundImage = global::MetroArcane.Properties.Resources.stop;
            this.metroButtonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroButtonStop.Location = new System.Drawing.Point(102, 40);
            this.metroButtonStop.Name = "metroButtonStop";
            this.metroButtonStop.Size = new System.Drawing.Size(90, 30);
            this.metroButtonStop.TabIndex = 3;
            this.metroButtonStop.UseSelectable = true;
            this.metroButtonStop.Click += new System.EventHandler(this.metroButtonStop_Click);
            this.metroButtonStop.Enter += new System.EventHandler(this.metroButtonStop_Enter);
            this.metroButtonStop.Leave += new System.EventHandler(this.metroButtonStop_Leave);
            this.metroButtonStop.MouseEnter += new System.EventHandler(this.metroButtonStop_MouseEnter);
            this.metroButtonStop.MouseLeave += new System.EventHandler(this.metroButtonStop_MouseLeave);
            // 
            // metroButtonRun
            // 
            this.metroButtonRun.BackColor = System.Drawing.SystemColors.Control;
            this.metroButtonRun.BackgroundImage = global::MetroArcane.Properties.Resources.play2;
            this.metroButtonRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroButtonRun.Location = new System.Drawing.Point(6, 40);
            this.metroButtonRun.Name = "metroButtonRun";
            this.metroButtonRun.Size = new System.Drawing.Size(90, 30);
            this.metroButtonRun.TabIndex = 2;
            this.metroButtonRun.UseSelectable = true;
            this.metroButtonRun.Click += new System.EventHandler(this.metroButtonRun_Click);
            this.metroButtonRun.Enter += new System.EventHandler(this.metroButtonRun_Enter);
            this.metroButtonRun.Leave += new System.EventHandler(this.metroButtonRun_Leave);
            this.metroButtonRun.MouseEnter += new System.EventHandler(this.metroButtonRun_MouseEnter);
            this.metroButtonRun.MouseLeave += new System.EventHandler(this.metroButtonRun_MouseLeave);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Click to expand";
            this.notifyIcon1.BalloonTipTitle = "Web Hack Monitor";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Web Hack Monitor";
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.metroGrid1.ColumnHeadersHeight = 32;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle8;
            this.metroGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(0, 0);
            this.metroGrid1.MultiSelect = false;
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.RowTemplate.Height = 30;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(1160, 412);
            this.metroGrid1.StandardTab = true;
            this.metroGrid1.TabIndex = 2;
            this.metroGrid1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroGrid1.UseCustomBackColor = true;
            this.metroGrid1.UseCustomForeColor = true;
            this.metroGrid1.UseStyleColors = true;
            this.metroGrid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_CellClick);
            this.metroGrid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_CellContentClick);
            this.metroGrid1.SelectionChanged += new System.EventHandler(this.metroGrid1_SelectionChanged);
            // 
            // metroPanel2
            // 
            this.metroPanel2.AutoSize = true;
            this.metroPanel2.BackColor = System.Drawing.Color.White;
            this.metroPanel2.Controls.Add(this.metroGrid1);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(20, 75);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(1160, 412);
            this.metroPanel2.TabIndex = 1;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1160, 15);
            this.metroPanel1.TabIndex = 3;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // timer1
            // 
            this.timer1.Interval = 90000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon2
            // 
            this.notifyIcon2.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon2.BalloonTipText = "Started Monitoring";
            this.notifyIcon2.BalloonTipTitle = "Web Hack Monitor";
            this.notifyIcon2.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon2.Icon")));
            this.notifyIcon2.Text = "Started";
            this.notifyIcon2.BalloonTipClicked += new System.EventHandler(this.notifyIcon2_BalloonTipClicked);
            this.notifyIcon2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon2_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 580);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.metroPanel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0.98D;
            this.Text = "Web Hack Monitor";
            this.TransparencyKey = System.Drawing.Color.DarkRed;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.metroPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.metroPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroButton metroButtonSettings;
        private MetroFramework.Controls.MetroButton metroButtonStop;
        private MetroFramework.Controls.MetroButton metroButtonRun;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private MetroFramework.Controls.MetroButton metroButton_add;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

