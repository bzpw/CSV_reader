using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSV_reader;
using deTracker;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ReaderActionForm
{
    public partial class Form1 : Form
    {
        List<string> filenames = new List<string>();
        string dir = "";
        string diru = "";

        public Form1()
        {
            InitializeComponent();
            ReadLogs_Button.Enabled = false;
            DownloadData_Button.Enabled = false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }


        //pobierz dane BTS lub UKE -- przycisk
        private void DownloadData_Button_Click(object sender, EventArgs e)
        {

            DialogResult fbd = SelectDir_FBD.ShowDialog();
            PB_ProgressBar.Visible = true;
            PB_ProgressBar.MarqueeAnimationSpeed = 25;
            PB_ProgressBar.BringToFront();

            if (fbd == DialogResult.OK)
            {
                Thread.Sleep(100);

                dir = SelectDir_FBD.SelectedPath + '\\';
                //DLinBck_BackgroundWorker.RunWorkerAsync(dir);


                if (DownloadData_CheckBox.GetItemChecked(0))
                {
                    string btspath = WebFeatures.DLb(dir);
                    MessageBox.Show("Downloaded btsearch...");
                }
                if (DownloadData_CheckBox.GetItemChecked(1))
                {
                    diru = dir + @"DL_UKE\";
                    Directory.CreateDirectory(diru);
                    List<string> links = WebFeatures.GetUKE();
                    foreach (string link in links)
                    {
                        WebFeatures.DLu(diru, link);
                        Thread.Sleep(10);
                    }
                    MessageBox.Show("Downloaded UKE...");
                }
            }

           PB_ProgressBar.Visible = false;
        }

      
        //uruchom ReadBTS i ReadUKE i dalej -- przycisk
        private void ReadData_Button_Click(object sender, EventArgs e)
        {
            PB_ProgressBar.Visible = true;
            PB_ProgressBar.MarqueeAnimationSpeed = 25;

            if (dir == "")
            {
                DialogResult fbd = SelectDir_FBD.ShowDialog();
                if (fbd == DialogResult.OK)
                {
                    dir = SelectDir_FBD.SelectedPath + '\\';
                    diru = dir + @"DL_UKE\";
                }
            }

            Directory.CreateDirectory(dir + "Res");
            DataTable bts = Operations.ReadBTS(dir + "btsearch.csv");
            DataTable bts2 = Operations.SelecMerge(bts);
            Operations.SaveToCSV(bts2, dir + "Res\\CSV_reader.csv");
            bts.Clear();
            bts2.Clear();
            bts.Dispose();
            bts2.Dispose();
            MessageBox.Show("BTsearch done.");
            DataTable uke = Operations.ReadUKE(diru);
            Operations.SaveToCSV(uke, dir + "Res\\UKE_reader.csv");
            uke.Clear();
            uke.Dispose();
            MessageBox.Show("UKE done.");

            PB_ProgressBar.Visible = false;
        }


        //checkbox BTS/UKE żeby deaktywować przycisk
        private void DownloadData_CheckBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DownloadData_CheckBox.GetItemChecked(0) || DownloadData_CheckBox.GetItemChecked(1))
            {
                DownloadData_Button.Enabled = true;
            }
            else
            {
                DownloadData_Button.Enabled = false;
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void SelectDir_FBD_HelpRequest(object sender, EventArgs e)
        {
        }

        private void SelectLog_OFD_FileOk(object sender, CancelEventArgs e)
        {
        }

        //https://stackoverflow.com/questions/23188783/how-to-check-if-file-download-is-complete
        //wczytywanie i przygotowanie plików z logami -- przycisk
        private void ReadLogs_Button_Click(object sender, EventArgs e)
        {
            PB_ProgressBar.Visible = true;
            PB_ProgressBar.MarqueeAnimationSpeed = 25;
            int cnt = 0;
            //MessageBox.Show("Wololo");

            foreach (string name in filenames)
            {
                cnt++;
                string fdir = Path.GetDirectoryName(name);
                string fname = Path.GetFileNameWithoutExtension(name);
                string fext = Path.GetExtension(name);
                //MessageBox.Show(fdir + '\\' + fname + '2' + fext + '\\');
                DataTable dt = OperationsLog.Logreader(name);
                dt = OperationsLog.BreakBts(dt);
                Operations.SaveToCSV(dt, fdir + '\\' + fname + '2' + fext);
                //FileList_TextBox.AppendText("wololo\n");
                MessageBox.Show("Zakończono przetwarzanie logu nr: " + cnt);
            }
            PB_ProgressBar.Visible = false;
        }

        private void FileList_TextBox_TextChanged(object sender, EventArgs e)
        {
        }


        //wyczysc listę plików -- przycisk
        private void ClearLogList_Button_Click(object sender, EventArgs e)
        {
            FileList_TextBox.Clear();
            FileList_TextBox.AppendText(@"Lista wybranych plików...");
            ReadLogs_Button.Enabled = false;
        }


        //wybierz pliki z logami -- przycisk
        public void SelectLogs_Button_Click(object sender, EventArgs e)
        {
            //string[] filenames;
            //SafeFileNames, FileNames
            SelectLog_OFD.RestoreDirectory = true;
            SelectLog_OFD.Filter = "Text Files (*.txt;*.log)|*.txt;*.log|All Files (*.*)|*.*";
            DialogResult ofd = SelectLog_OFD.ShowDialog();
            if (ofd == DialogResult.OK)
            {
                FileList_TextBox.Clear();
                foreach (string fn in SelectLog_OFD.SafeFileNames)
                {
                    FileList_TextBox.AppendText(fn + "\n");
                    //MessageBox.Show(filenames.Count.ToString());

                }
                foreach (string fn in SelectLog_OFD.FileNames)
                {
                    filenames.Add(fn.ToString());
                    //MessageBox.Show(filenames.Count.ToString());

                }
            }
            ReadLogs_Button.Enabled = true;
            //MessageBox.Show(filenames.Count.ToString());
        }

       
        private void PB_ProgressBar_Click(object sender, EventArgs e)
        {
        }      

    }
}
