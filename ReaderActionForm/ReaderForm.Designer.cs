﻿namespace ReaderActionForm
{
    partial class ReaderForm
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
            this.DownloadData_Button = new System.Windows.Forms.Button();
            this.DownloadData_CheckBox = new System.Windows.Forms.CheckedListBox();
            this.DlData_GroupBox = new System.Windows.Forms.GroupBox();
            this.SelectDir_FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.SelectLogs_Button = new System.Windows.Forms.Button();
            this.ReadLogs_Button = new System.Windows.Forms.Button();
            this.FileList_TextBox = new System.Windows.Forms.TextBox();
            this.SelectLog_OFD = new System.Windows.Forms.OpenFileDialog();
            this.ClearLogList_Button = new System.Windows.Forms.Button();
            this.ReadData_Button = new System.Windows.Forms.Button();
            this.PB_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.DlData_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DownloadData_Button
            // 
            this.DownloadData_Button.Location = new System.Drawing.Point(400, 32);
            this.DownloadData_Button.Margin = new System.Windows.Forms.Padding(10);
            this.DownloadData_Button.Name = "DownloadData_Button";
            this.DownloadData_Button.Padding = new System.Windows.Forms.Padding(5);
            this.DownloadData_Button.Size = new System.Drawing.Size(85, 29);
            this.DownloadData_Button.TabIndex = 0;
            this.DownloadData_Button.Text = "Pobierz";
            this.DownloadData_Button.UseVisualStyleBackColor = true;
            this.DownloadData_Button.Click += new System.EventHandler(this.DownloadData_Button_ClickAsync);
            // 
            // DownloadData_CheckBox
            // 
            this.DownloadData_CheckBox.FormattingEnabled = true;
            this.DownloadData_CheckBox.Items.AddRange(new object[] {
            "Dane BTSearch",
            "Dane UKE"});
            this.DownloadData_CheckBox.Location = new System.Drawing.Point(8, 21);
            this.DownloadData_CheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.DownloadData_CheckBox.Name = "DownloadData_CheckBox";
            this.DownloadData_CheckBox.Size = new System.Drawing.Size(143, 34);
            this.DownloadData_CheckBox.TabIndex = 1;
            this.DownloadData_CheckBox.SelectedIndexChanged += new System.EventHandler(this.DownloadData_CheckBox_Click);
            // 
            // DlData_GroupBox
            // 
            this.DlData_GroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DlData_GroupBox.Controls.Add(this.DownloadData_CheckBox);
            this.DlData_GroupBox.Location = new System.Drawing.Point(226, 6);
            this.DlData_GroupBox.Margin = new System.Windows.Forms.Padding(5);
            this.DlData_GroupBox.Name = "DlData_GroupBox";
            this.DlData_GroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.DlData_GroupBox.Size = new System.Drawing.Size(159, 63);
            this.DlData_GroupBox.TabIndex = 2;
            this.DlData_GroupBox.TabStop = false;
            this.DlData_GroupBox.Text = "Pobierz aktualne dane";
            this.DlData_GroupBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // SelectDir_FBD
            // 
            this.SelectDir_FBD.Description = "Wybierz miejsce zapisu plików z danymi BTSearch / UKE";
            this.SelectDir_FBD.HelpRequest += new System.EventHandler(this.SelectDir_FBD_HelpRequest);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 399);
            this.button1.Margin = new System.Windows.Forms.Padding(10);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(5);
            this.button1.Size = new System.Drawing.Size(110, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Uruchom program";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SelectLogs_Button
            // 
            this.SelectLogs_Button.Location = new System.Drawing.Point(11, 16);
            this.SelectLogs_Button.Margin = new System.Windows.Forms.Padding(10);
            this.SelectLogs_Button.Name = "SelectLogs_Button";
            this.SelectLogs_Button.Padding = new System.Windows.Forms.Padding(5);
            this.SelectLogs_Button.Size = new System.Drawing.Size(84, 45);
            this.SelectLogs_Button.TabIndex = 4;
            this.SelectLogs_Button.Text = "Wybierz pliki z logami";
            this.SelectLogs_Button.UseVisualStyleBackColor = true;
            this.SelectLogs_Button.Click += new System.EventHandler(this.SelectLogs_Button_Click);
            // 
            // ReadLogs_Button
            // 
            this.ReadLogs_Button.Location = new System.Drawing.Point(127, 16);
            this.ReadLogs_Button.Margin = new System.Windows.Forms.Padding(10);
            this.ReadLogs_Button.Name = "ReadLogs_Button";
            this.ReadLogs_Button.Padding = new System.Windows.Forms.Padding(5);
            this.ReadLogs_Button.Size = new System.Drawing.Size(84, 45);
            this.ReadLogs_Button.TabIndex = 5;
            this.ReadLogs_Button.Text = "Przygotuj logi";
            this.ReadLogs_Button.UseVisualStyleBackColor = true;
            this.ReadLogs_Button.Click += new System.EventHandler(this.ReadLogs_Button_Click);
            // 
            // FileList_TextBox
            // 
            this.FileList_TextBox.Location = new System.Drawing.Point(11, 81);
            this.FileList_TextBox.Margin = new System.Windows.Forms.Padding(10);
            this.FileList_TextBox.Multiline = true;
            this.FileList_TextBox.Name = "FileList_TextBox";
            this.FileList_TextBox.ReadOnly = true;
            this.FileList_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FileList_TextBox.Size = new System.Drawing.Size(200, 95);
            this.FileList_TextBox.TabIndex = 6;
            this.FileList_TextBox.Text = "Lista wybranych plików...";
            this.FileList_TextBox.TextChanged += new System.EventHandler(this.FileList_TextBox_TextChanged);
            // 
            // SelectLog_OFD
            // 
            this.SelectLog_OFD.FileName = "Wybierz pliki";
            this.SelectLog_OFD.Multiselect = true;
            this.SelectLog_OFD.Title = "Wybierz wszystkie pliki z logami";
            this.SelectLog_OFD.FileOk += new System.ComponentModel.CancelEventHandler(this.SelectLog_OFD_FileOk);
            // 
            // ClearLogList_Button
            // 
            this.ClearLogList_Button.Location = new System.Drawing.Point(11, 186);
            this.ClearLogList_Button.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.ClearLogList_Button.Name = "ClearLogList_Button";
            this.ClearLogList_Button.Size = new System.Drawing.Size(75, 23);
            this.ClearLogList_Button.TabIndex = 7;
            this.ClearLogList_Button.Text = "Wyczyść";
            this.ClearLogList_Button.UseVisualStyleBackColor = true;
            this.ClearLogList_Button.Click += new System.EventHandler(this.ClearLogList_Button_Click);
            // 
            // ReadData_Button
            // 
            this.ReadData_Button.Location = new System.Drawing.Point(384, 76);
            this.ReadData_Button.Margin = new System.Windows.Forms.Padding(10);
            this.ReadData_Button.Name = "ReadData_Button";
            this.ReadData_Button.Padding = new System.Windows.Forms.Padding(5);
            this.ReadData_Button.Size = new System.Drawing.Size(101, 31);
            this.ReadData_Button.TabIndex = 8;
            this.ReadData_Button.Text = "Przygotuj dane";
            this.ReadData_Button.UseVisualStyleBackColor = true;
            this.ReadData_Button.Click += new System.EventHandler(this.ReadData_Button_Click);
            // 
            // PB_ProgressBar
            // 
            this.PB_ProgressBar.Location = new System.Drawing.Point(11, 399);
            this.PB_ProgressBar.Margin = new System.Windows.Forms.Padding(10);
            this.PB_ProgressBar.Name = "PB_ProgressBar";
            this.PB_ProgressBar.Size = new System.Drawing.Size(344, 31);
            this.PB_ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.PB_ProgressBar.TabIndex = 9;
            this.PB_ProgressBar.Visible = false;
            this.PB_ProgressBar.Click += new System.EventHandler(this.PB_ProgressBar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 441);
            this.Controls.Add(this.PB_ProgressBar);
            this.Controls.Add(this.ReadData_Button);
            this.Controls.Add(this.ClearLogList_Button);
            this.Controls.Add(this.FileList_TextBox);
            this.Controls.Add(this.ReadLogs_Button);
            this.Controls.Add(this.SelectLogs_Button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DlData_GroupBox);
            this.Controls.Add(this.DownloadData_Button);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.Text = "Tracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DlData_GroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DownloadData_Button;
        private System.Windows.Forms.CheckedListBox DownloadData_CheckBox;
        private System.Windows.Forms.GroupBox DlData_GroupBox;
        private System.Windows.Forms.FolderBrowserDialog SelectDir_FBD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SelectLogs_Button;
        private System.Windows.Forms.Button ReadLogs_Button;
        private System.Windows.Forms.TextBox FileList_TextBox;
        private System.Windows.Forms.OpenFileDialog SelectLog_OFD;
        private System.Windows.Forms.Button ClearLogList_Button;
        private System.Windows.Forms.Button ReadData_Button;
        private System.Windows.Forms.ProgressBar PB_ProgressBar;
    }
}

