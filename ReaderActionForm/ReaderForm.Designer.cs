namespace ReaderActionForm
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
            this.SelectLogs_Button = new System.Windows.Forms.Button();
            this.ReadLogs_Button = new System.Windows.Forms.Button();
            this.FileList_TextBox = new System.Windows.Forms.TextBox();
            this.SelectLog_OFD = new System.Windows.Forms.OpenFileDialog();
            this.ClearLogList_Button = new System.Windows.Forms.Button();
            this.ReadData_Button = new System.Windows.Forms.Button();
            this.PB_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.MergeLogs = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DlData_GroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DownloadData_Button
            // 
            this.DownloadData_Button.Location = new System.Drawing.Point(163, 11);
            this.DownloadData_Button.Margin = new System.Windows.Forms.Padding(10);
            this.DownloadData_Button.Name = "DownloadData_Button";
            this.DownloadData_Button.Padding = new System.Windows.Forms.Padding(5);
            this.DownloadData_Button.Size = new System.Drawing.Size(100, 48);
            this.DownloadData_Button.TabIndex = 0;
            this.DownloadData_Button.Text = "Pobierz...";
            this.DownloadData_Button.UseVisualStyleBackColor = true;
            this.DownloadData_Button.Click += new System.EventHandler(this.DownloadData_Button_ClickAsync);
            // 
            // DownloadData_CheckBox
            // 
            this.DownloadData_CheckBox.FormattingEnabled = true;
            this.DownloadData_CheckBox.Items.AddRange(new object[] {
            "Dane BTSearch.pl",
            "Dane UKE"});
            this.DownloadData_CheckBox.Location = new System.Drawing.Point(6, 21);
            this.DownloadData_CheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.DownloadData_CheckBox.Name = "DownloadData_CheckBox";
            this.DownloadData_CheckBox.Size = new System.Drawing.Size(145, 34);
            this.DownloadData_CheckBox.TabIndex = 1;
            this.DownloadData_CheckBox.SelectedIndexChanged += new System.EventHandler(this.DownloadData_CheckBox_Click);
            // 
            // DlData_GroupBox
            // 
            this.DlData_GroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DlData_GroupBox.Controls.Add(this.DownloadData_CheckBox);
            this.DlData_GroupBox.Controls.Add(this.DownloadData_Button);
            this.DlData_GroupBox.Location = new System.Drawing.Point(11, 6);
            this.DlData_GroupBox.Margin = new System.Windows.Forms.Padding(5);
            this.DlData_GroupBox.Name = "DlData_GroupBox";
            this.DlData_GroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.DlData_GroupBox.Size = new System.Drawing.Size(268, 66);
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
            // SelectLogs_Button
            // 
            this.SelectLogs_Button.Location = new System.Drawing.Point(5, 21);
            this.SelectLogs_Button.Margin = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.SelectLogs_Button.Name = "SelectLogs_Button";
            this.SelectLogs_Button.Padding = new System.Windows.Forms.Padding(5);
            this.SelectLogs_Button.Size = new System.Drawing.Size(100, 48);
            this.SelectLogs_Button.TabIndex = 4;
            this.SelectLogs_Button.Text = "Wybierz pliki \r\nz logami";
            this.SelectLogs_Button.UseVisualStyleBackColor = true;
            this.SelectLogs_Button.Click += new System.EventHandler(this.SelectLogs_Button_Click);
            // 
            // ReadLogs_Button
            // 
            this.ReadLogs_Button.Location = new System.Drawing.Point(5, 187);
            this.ReadLogs_Button.Margin = new System.Windows.Forms.Padding(10);
            this.ReadLogs_Button.Name = "ReadLogs_Button";
            this.ReadLogs_Button.Padding = new System.Windows.Forms.Padding(5);
            this.ReadLogs_Button.Size = new System.Drawing.Size(100, 48);
            this.ReadLogs_Button.TabIndex = 5;
            this.ReadLogs_Button.Text = "Odszyfruj logi";
            this.ReadLogs_Button.UseVisualStyleBackColor = true;
            this.ReadLogs_Button.Click += new System.EventHandler(this.ReadLogs_Button_Click);
            // 
            // FileList_TextBox
            // 
            this.FileList_TextBox.Location = new System.Drawing.Point(5, 84);
            this.FileList_TextBox.Margin = new System.Windows.Forms.Padding(10);
            this.FileList_TextBox.Multiline = true;
            this.FileList_TextBox.Name = "FileList_TextBox";
            this.FileList_TextBox.ReadOnly = true;
            this.FileList_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FileList_TextBox.Size = new System.Drawing.Size(258, 95);
            this.FileList_TextBox.TabIndex = 6;
            this.FileList_TextBox.Text = "Lista wybranych plików...";
            this.FileList_TextBox.TextChanged += new System.EventHandler(this.FileList_TextBox_TextChanged);
            // 
            // SelectLog_OFD
            // 
            this.SelectLog_OFD.FileName = "Wybierz pliki";
            this.SelectLog_OFD.Multiselect = true;
            this.SelectLog_OFD.RestoreDirectory = true;
            this.SelectLog_OFD.Title = "Wybierz wszystkie pliki z logami";
            this.SelectLog_OFD.FileOk += new System.ComponentModel.CancelEventHandler(this.SelectLog_OFD_FileOk);
            // 
            // ClearLogList_Button
            // 
            this.ClearLogList_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearLogList_Button.Location = new System.Drawing.Point(163, 21);
            this.ClearLogList_Button.Margin = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.ClearLogList_Button.Name = "ClearLogList_Button";
            this.ClearLogList_Button.Padding = new System.Windows.Forms.Padding(5);
            this.ClearLogList_Button.Size = new System.Drawing.Size(100, 48);
            this.ClearLogList_Button.TabIndex = 7;
            this.ClearLogList_Button.Text = "Wyczyść listę...";
            this.ClearLogList_Button.UseVisualStyleBackColor = true;
            this.ClearLogList_Button.Click += new System.EventHandler(this.ClearLogList_Button_Click);
            // 
            // ReadData_Button
            // 
            this.ReadData_Button.Location = new System.Drawing.Point(174, 85);
            this.ReadData_Button.Margin = new System.Windows.Forms.Padding(10);
            this.ReadData_Button.Name = "ReadData_Button";
            this.ReadData_Button.Padding = new System.Windows.Forms.Padding(5);
            this.ReadData_Button.Size = new System.Drawing.Size(100, 48);
            this.ReadData_Button.TabIndex = 8;
            this.ReadData_Button.Text = "Przygotuj plik \r\nze stacjami";
            this.ReadData_Button.UseVisualStyleBackColor = true;
            this.ReadData_Button.Click += new System.EventHandler(this.ReadData_Button_Click);
            // 
            // PB_ProgressBar
            // 
            this.PB_ProgressBar.Location = new System.Drawing.Point(11, 458);
            this.PB_ProgressBar.Margin = new System.Windows.Forms.Padding(10);
            this.PB_ProgressBar.Name = "PB_ProgressBar";
            this.PB_ProgressBar.Size = new System.Drawing.Size(268, 31);
            this.PB_ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.PB_ProgressBar.TabIndex = 9;
            this.PB_ProgressBar.Visible = false;
            this.PB_ProgressBar.Click += new System.EventHandler(this.PB_ProgressBar_Click);
            // 
            // MergeLogs
            // 
            this.MergeLogs.Location = new System.Drawing.Point(174, 391);
            this.MergeLogs.Margin = new System.Windows.Forms.Padding(10);
            this.MergeLogs.Name = "MergeLogs";
            this.MergeLogs.Padding = new System.Windows.Forms.Padding(5);
            this.MergeLogs.Size = new System.Drawing.Size(100, 48);
            this.MergeLogs.TabIndex = 10;
            this.MergeLogs.Text = "Połącz logi \r\ndo wczytania";
            this.MergeLogs.UseVisualStyleBackColor = true;
            this.MergeLogs.Click += new System.EventHandler(this.MergeLogs_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ClearLogList_Button);
            this.groupBox2.Controls.Add(this.FileList_TextBox);
            this.groupBox2.Controls.Add(this.SelectLogs_Button);
            this.groupBox2.Controls.Add(this.ReadLogs_Button);
            this.groupBox2.Location = new System.Drawing.Point(11, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 241);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opracuj pliki z logami";
            // 
            // ReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 500);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.MergeLogs);
            this.Controls.Add(this.PB_ProgressBar);
            this.Controls.Add(this.ReadData_Button);
            this.Controls.Add(this.DlData_GroupBox);
            this.MaximizeBox = false;
            this.Name = "ReaderForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.Text = "Tracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DlData_GroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DownloadData_Button;
        private System.Windows.Forms.CheckedListBox DownloadData_CheckBox;
        private System.Windows.Forms.GroupBox DlData_GroupBox;
        private System.Windows.Forms.FolderBrowserDialog SelectDir_FBD;
        private System.Windows.Forms.Button SelectLogs_Button;
        private System.Windows.Forms.Button ReadLogs_Button;
        private System.Windows.Forms.TextBox FileList_TextBox;
        private System.Windows.Forms.OpenFileDialog SelectLog_OFD;
        private System.Windows.Forms.Button ClearLogList_Button;
        private System.Windows.Forms.Button ReadData_Button;
        private System.Windows.Forms.ProgressBar PB_ProgressBar;
        private System.Windows.Forms.Button MergeLogs;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

