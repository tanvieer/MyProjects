using System;

namespace MetroArcane
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroTextBoxPort = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroButtonSave = new MetroFramework.Controls.MetroButton();
            this.metroTextBoxSMTP = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxPass = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxSMTPmail = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroTextBoxAdminMail = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroButtonUpdateSystemPW = new MetroFramework.Controls.MetroButton();
            this.metroTextBoxConfirmPW = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxNewPW = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroTextBoxPort);
            this.metroPanel1.Controls.Add(this.metroLabel5);
            this.metroPanel1.Controls.Add(this.metroLabel4);
            this.metroPanel1.Controls.Add(this.metroButtonSave);
            this.metroPanel1.Controls.Add(this.metroTextBoxSMTP);
            this.metroPanel1.Controls.Add(this.metroTextBoxPass);
            this.metroPanel1.Controls.Add(this.metroTextBoxSMTPmail);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(650, 195);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroTextBoxPort
            // 
            // 
            // 
            // 
            this.metroTextBoxPort.CustomButton.Image = null;
            this.metroTextBoxPort.CustomButton.Location = new System.Drawing.Point(428, 1);
            this.metroTextBoxPort.CustomButton.Name = "";
            this.metroTextBoxPort.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxPort.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxPort.CustomButton.TabIndex = 1;
            this.metroTextBoxPort.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxPort.CustomButton.UseSelectable = true;
            this.metroTextBoxPort.CustomButton.Visible = false;
            this.metroTextBoxPort.Lines = new string[0];
            this.metroTextBoxPort.Location = new System.Drawing.Point(131, 127);
            this.metroTextBoxPort.MaxLength = 32767;
            this.metroTextBoxPort.Name = "metroTextBoxPort";
            this.metroTextBoxPort.PasswordChar = '\0';
            this.metroTextBoxPort.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxPort.SelectedText = "";
            this.metroTextBoxPort.SelectionLength = 0;
            this.metroTextBoxPort.SelectionStart = 0;
            this.metroTextBoxPort.Size = new System.Drawing.Size(450, 23);
            this.metroTextBoxPort.TabIndex = 4;
            this.metroTextBoxPort.UseSelectable = true;
            this.metroTextBoxPort.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxPort.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(88, 127);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(37, 19);
            this.metroLabel5.TabIndex = 11;
            this.metroLabel5.Text = "Port:";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroLabel4.Location = new System.Drawing.Point(5, 5);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(104, 19);
            this.metroLabel4.TabIndex = 10;
            this.metroLabel4.Text = "SMTP Settings";
            // 
            // metroButtonSave
            // 
            this.metroButtonSave.BackColor = System.Drawing.SystemColors.Control;
            this.metroButtonSave.BackgroundImage = global::MetroArcane.Properties.Resources.save;
            this.metroButtonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroButtonSave.Location = new System.Drawing.Point(300, 157);
            this.metroButtonSave.Name = "metroButtonSave";
            this.metroButtonSave.Size = new System.Drawing.Size(90, 30);
            this.metroButtonSave.TabIndex = 5;
            this.metroButtonSave.UseSelectable = true;
            this.metroButtonSave.Click += new System.EventHandler(this.metroButtonSave_Click);
            // 
            // metroTextBoxSMTP
            // 
            // 
            // 
            // 
            this.metroTextBoxSMTP.CustomButton.Image = null;
            this.metroTextBoxSMTP.CustomButton.Location = new System.Drawing.Point(428, 1);
            this.metroTextBoxSMTP.CustomButton.Name = "";
            this.metroTextBoxSMTP.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxSMTP.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxSMTP.CustomButton.TabIndex = 1;
            this.metroTextBoxSMTP.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxSMTP.CustomButton.UseSelectable = true;
            this.metroTextBoxSMTP.CustomButton.Visible = false;
            this.metroTextBoxSMTP.Lines = new string[0];
            this.metroTextBoxSMTP.Location = new System.Drawing.Point(131, 98);
            this.metroTextBoxSMTP.MaxLength = 32767;
            this.metroTextBoxSMTP.Name = "metroTextBoxSMTP";
            this.metroTextBoxSMTP.PasswordChar = '\0';
            this.metroTextBoxSMTP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxSMTP.SelectedText = "";
            this.metroTextBoxSMTP.SelectionLength = 0;
            this.metroTextBoxSMTP.SelectionStart = 0;
            this.metroTextBoxSMTP.Size = new System.Drawing.Size(450, 23);
            this.metroTextBoxSMTP.TabIndex = 3;
            this.metroTextBoxSMTP.UseSelectable = true;
            this.metroTextBoxSMTP.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxSMTP.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxPass
            // 
            // 
            // 
            // 
            this.metroTextBoxPass.CustomButton.Image = null;
            this.metroTextBoxPass.CustomButton.Location = new System.Drawing.Point(428, 1);
            this.metroTextBoxPass.CustomButton.Name = "";
            this.metroTextBoxPass.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxPass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxPass.CustomButton.TabIndex = 1;
            this.metroTextBoxPass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxPass.CustomButton.UseSelectable = true;
            this.metroTextBoxPass.CustomButton.Visible = false;
            this.metroTextBoxPass.Lines = new string[0];
            this.metroTextBoxPass.Location = new System.Drawing.Point(131, 67);
            this.metroTextBoxPass.MaxLength = 32767;
            this.metroTextBoxPass.Name = "metroTextBoxPass";
            this.metroTextBoxPass.PasswordChar = '*';
            this.metroTextBoxPass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxPass.SelectedText = "";
            this.metroTextBoxPass.SelectionLength = 0;
            this.metroTextBoxPass.SelectionStart = 0;
            this.metroTextBoxPass.Size = new System.Drawing.Size(450, 23);
            this.metroTextBoxPass.TabIndex = 2;
            this.metroTextBoxPass.UseSelectable = true;
            this.metroTextBoxPass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxPass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxSMTPmail
            // 
            // 
            // 
            // 
            this.metroTextBoxSMTPmail.CustomButton.Image = null;
            this.metroTextBoxSMTPmail.CustomButton.Location = new System.Drawing.Point(428, 1);
            this.metroTextBoxSMTPmail.CustomButton.Name = "";
            this.metroTextBoxSMTPmail.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxSMTPmail.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxSMTPmail.CustomButton.TabIndex = 1;
            this.metroTextBoxSMTPmail.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxSMTPmail.CustomButton.UseSelectable = true;
            this.metroTextBoxSMTPmail.CustomButton.Visible = false;
            this.metroTextBoxSMTPmail.Lines = new string[0];
            this.metroTextBoxSMTPmail.Location = new System.Drawing.Point(131, 37);
            this.metroTextBoxSMTPmail.MaxLength = 32767;
            this.metroTextBoxSMTPmail.Name = "metroTextBoxSMTPmail";
            this.metroTextBoxSMTPmail.PasswordChar = '\0';
            this.metroTextBoxSMTPmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxSMTPmail.SelectedText = "";
            this.metroTextBoxSMTPmail.SelectionLength = 0;
            this.metroTextBoxSMTPmail.SelectionStart = 0;
            this.metroTextBoxSMTPmail.Size = new System.Drawing.Size(450, 23);
            this.metroTextBoxSMTPmail.TabIndex = 1;
            this.metroTextBoxSMTPmail.UseSelectable = true;
            this.metroTextBoxSMTPmail.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxSMTPmail.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(36, 98);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(89, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "SMTP Server:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(59, 67);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(66, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Password:";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(66, 37);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(59, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Email Id:";
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.metroTextBoxAdminMail);
            this.metroPanel2.Controls.Add(this.metroLabel6);
            this.metroPanel2.Controls.Add(this.metroLabel7);
            this.metroPanel2.Controls.Add(this.metroButtonUpdateSystemPW);
            this.metroPanel2.Controls.Add(this.metroTextBoxConfirmPW);
            this.metroPanel2.Controls.Add(this.metroTextBoxNewPW);
            this.metroPanel2.Controls.Add(this.metroLabel8);
            this.metroPanel2.Controls.Add(this.metroLabel9);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(20, 255);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(650, 167);
            this.metroPanel2.TabIndex = 3;
            this.metroPanel2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroTextBoxAdminMail
            // 
            // 
            // 
            // 
            this.metroTextBoxAdminMail.CustomButton.Image = null;
            this.metroTextBoxAdminMail.CustomButton.Location = new System.Drawing.Point(428, 1);
            this.metroTextBoxAdminMail.CustomButton.Name = "";
            this.metroTextBoxAdminMail.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxAdminMail.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxAdminMail.CustomButton.TabIndex = 1;
            this.metroTextBoxAdminMail.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxAdminMail.CustomButton.UseSelectable = true;
            this.metroTextBoxAdminMail.CustomButton.Visible = false;
            this.metroTextBoxAdminMail.Lines = new string[0];
            this.metroTextBoxAdminMail.Location = new System.Drawing.Point(131, 98);
            this.metroTextBoxAdminMail.MaxLength = 32767;
            this.metroTextBoxAdminMail.Name = "metroTextBoxAdminMail";
            this.metroTextBoxAdminMail.PasswordChar = '\0';
            this.metroTextBoxAdminMail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxAdminMail.SelectedText = "";
            this.metroTextBoxAdminMail.SelectionLength = 0;
            this.metroTextBoxAdminMail.SelectionStart = 0;
            this.metroTextBoxAdminMail.Size = new System.Drawing.Size(450, 23);
            this.metroTextBoxAdminMail.TabIndex = 8;
            this.metroTextBoxAdminMail.UseSelectable = true;
            this.metroTextBoxAdminMail.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxAdminMail.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(23, 98);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(102, 19);
            this.metroLabel6.TabIndex = 11;
            this.metroLabel6.Text = "Recovery Email:";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroLabel7.Location = new System.Drawing.Point(5, 3);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(156, 19);
            this.metroLabel7.TabIndex = 10;
            this.metroLabel7.Text = "Password Information";
            // 
            // metroButtonUpdateSystemPW
            // 
            this.metroButtonUpdateSystemPW.BackColor = System.Drawing.SystemColors.Control;
            this.metroButtonUpdateSystemPW.BackgroundImage = global::MetroArcane.Properties.Resources.update;
            this.metroButtonUpdateSystemPW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroButtonUpdateSystemPW.Location = new System.Drawing.Point(300, 128);
            this.metroButtonUpdateSystemPW.Name = "metroButtonUpdateSystemPW";
            this.metroButtonUpdateSystemPW.Size = new System.Drawing.Size(90, 30);
            this.metroButtonUpdateSystemPW.TabIndex = 9;
            this.metroButtonUpdateSystemPW.UseSelectable = true;
            this.metroButtonUpdateSystemPW.Click += new System.EventHandler(this.metroButtonUpdateSystemPW_Click_1);
            // 
            // metroTextBoxConfirmPW
            // 
            // 
            // 
            // 
            this.metroTextBoxConfirmPW.CustomButton.Image = null;
            this.metroTextBoxConfirmPW.CustomButton.Location = new System.Drawing.Point(428, 1);
            this.metroTextBoxConfirmPW.CustomButton.Name = "";
            this.metroTextBoxConfirmPW.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxConfirmPW.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxConfirmPW.CustomButton.TabIndex = 1;
            this.metroTextBoxConfirmPW.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxConfirmPW.CustomButton.UseSelectable = true;
            this.metroTextBoxConfirmPW.CustomButton.Visible = false;
            this.metroTextBoxConfirmPW.Lines = new string[0];
            this.metroTextBoxConfirmPW.Location = new System.Drawing.Point(131, 69);
            this.metroTextBoxConfirmPW.MaxLength = 32767;
            this.metroTextBoxConfirmPW.Name = "metroTextBoxConfirmPW";
            this.metroTextBoxConfirmPW.PasswordChar = '*';
            this.metroTextBoxConfirmPW.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxConfirmPW.SelectedText = "";
            this.metroTextBoxConfirmPW.SelectionLength = 0;
            this.metroTextBoxConfirmPW.SelectionStart = 0;
            this.metroTextBoxConfirmPW.Size = new System.Drawing.Size(450, 23);
            this.metroTextBoxConfirmPW.TabIndex = 7;
            this.metroTextBoxConfirmPW.UseSelectable = true;
            this.metroTextBoxConfirmPW.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxConfirmPW.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxNewPW
            // 
            // 
            // 
            // 
            this.metroTextBoxNewPW.CustomButton.Image = null;
            this.metroTextBoxNewPW.CustomButton.Location = new System.Drawing.Point(428, 1);
            this.metroTextBoxNewPW.CustomButton.Name = "";
            this.metroTextBoxNewPW.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxNewPW.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxNewPW.CustomButton.TabIndex = 1;
            this.metroTextBoxNewPW.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxNewPW.CustomButton.UseSelectable = true;
            this.metroTextBoxNewPW.CustomButton.Visible = false;
            this.metroTextBoxNewPW.Lines = new string[0];
            this.metroTextBoxNewPW.Location = new System.Drawing.Point(131, 38);
            this.metroTextBoxNewPW.MaxLength = 32767;
            this.metroTextBoxNewPW.Name = "metroTextBoxNewPW";
            this.metroTextBoxNewPW.PasswordChar = '*';
            this.metroTextBoxNewPW.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxNewPW.SelectedText = "";
            this.metroTextBoxNewPW.SelectionLength = 0;
            this.metroTextBoxNewPW.SelectionStart = 0;
            this.metroTextBoxNewPW.Size = new System.Drawing.Size(450, 23);
            this.metroTextBoxNewPW.TabIndex = 6;
            this.metroTextBoxNewPW.UseSelectable = true;
            this.metroTextBoxNewPW.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxNewPW.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(7, 69);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(118, 19);
            this.metroLabel8.TabIndex = 4;
            this.metroLabel8.Text = "Confirm Password:";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(29, 38);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(96, 19);
            this.metroLabel9.TabIndex = 3;
            this.metroLabel9.Text = "New Password:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 470);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Opacity = 0.98D;
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox metroTextBoxPort;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton metroButtonSave;
        private MetroFramework.Controls.MetroTextBox metroTextBoxSMTP;
        private MetroFramework.Controls.MetroTextBox metroTextBoxPass;
        private MetroFramework.Controls.MetroTextBox metroTextBoxSMTPmail;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroTextBox metroTextBoxAdminMail;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroButton metroButtonUpdateSystemPW;
        private MetroFramework.Controls.MetroTextBox metroTextBoxConfirmPW;
        private MetroFramework.Controls.MetroTextBox metroTextBoxNewPW;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel9;
    }
}