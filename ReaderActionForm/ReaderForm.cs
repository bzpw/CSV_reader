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
using BTS_reader;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ReaderActionForm
{
    public partial class ReaderForm : Form
    {
        List<string> filenames = new List<string>();
        string dir = "";
        string diru = "";
        protected DataTable dt_bts = new DataTable("BTS");

        public ReaderForm()
        {
            InitializeComponent();
            ReadLogs_Button.Enabled = false;
            DownloadData_Button.Enabled = false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }


        //pobierz dane BTS lub UKE -- przycisk
        private async void DownloadData_Button_ClickAsync(object sender, EventArgs e)
        {

            DialogResult fbd = SelectDir_FBD.ShowDialog();
            PB_ProgressBar.Visible = true;
            PB_ProgressBar.MarqueeAnimationSpeed = 25;
            PB_ProgressBar.BringToFront();
            this.Enabled = false;

            if (fbd == DialogResult.OK)
            {
                Thread.Sleep(100);

                dir = SelectDir_FBD.SelectedPath + '\\';
                await Task.Run(() => DlData_Fn(dir));                
            }

            PB_ProgressBar.Visible = false;
            this.Enabled = true;
        }


        //fja uruchamiająca async pobieranie danych bts/uke
        protected void DlData_Fn(string dir)
        {
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
                    Thread.Sleep(25);
                }
                MessageBox.Show("Downloaded UKE...");
            }
        }


        //uruchom ReadBTS i ReadUKE i dalej -- przycisk
        private async void ReadData_Button_Click(object sender, EventArgs e)
        {
            

            if (dir == "")
            {
                DialogResult fbd = SelectDir_FBD.ShowDialog();
                PB_ProgressBar.Visible = true;
                PB_ProgressBar.MarqueeAnimationSpeed = 25;
                this.Enabled = false;
                if (fbd == DialogResult.OK)
                {
                    dir = SelectDir_FBD.SelectedPath + '\\';
                    diru = dir + @"DL_UKE\";
                    await Task.Run(() => ReadData_Fn(dir));
                }
            }
            else
            {
                PB_ProgressBar.Visible = true;
                PB_ProgressBar.MarqueeAnimationSpeed = 25;
                this.Enabled = false;
                await Task.Run(() => ReadData_Fn(dir));
            }

            PB_ProgressBar.Visible = false;
            this.Enabled = true;
        }


        //fja uruchamiająca async operacje na bts / uke
        protected void ReadData_Fn(string dir)
        {
            Directory.CreateDirectory(dir + "Res");
            DataTable bts = Operations.ReadBTS(dir + "btsearch.csv");
            dt_bts = Operations.SelecMerge(bts);
            Operations.SaveToCSV(dt_bts, dir + "Res\\CSV_reader.csv");
            bts.Clear();
            //dt_bts.Clear();
            bts.Dispose();
            //dt_bts.Dispose();
            MessageBox.Show("BTsearch done.");
            DataTable uke = Operations.ReadUKE(diru);
            Operations.SaveToCSV(uke, dir + "Res\\UKE_reader.csv");
            uke.Clear();
            uke.Dispose();
            MessageBox.Show("UKE done.");
        }


        //checkbox BTS/UKE żeby deaktywować przycisk
        private void DownloadData_CheckBox_Click(object sender, EventArgs e)
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


        //checkbox BTS/UKE żeby deaktywować przycisk
        /*private void DownloadData_CheckBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DownloadData_CheckBox.GetItemChecked(0) || DownloadData_CheckBox.GetItemChecked(1))
            {
                DownloadData_Button.Enabled = true;
            }
            else
            {
                DownloadData_Button.Enabled = false;
            }
        }*/


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
        private async void ReadLogs_Button_Click(object sender, EventArgs e)
        {
            if (filenames.Count < 1)
            {
                MessageBox.Show(@"Błąd. Brak logów.");
                return;
            }
            if (dir == "" || dt_bts.Rows.Count < 1)
            {
                DialogResult fbd = SelectDir_FBD.ShowDialog();
                PB_ProgressBar.Visible = true;
                PB_ProgressBar.MarqueeAnimationSpeed = 25;
                this.Enabled = false;
                if (fbd == DialogResult.OK)
                {
                    dir = SelectDir_FBD.SelectedPath + "\\Res\\";
                    //diru = dir + @"DL_UKE\";
                    //await Task.Run(() => ReadData_Fn(dir));
                    dt_bts =  await Task.Run(() => Operations.ReadBTS(dir + "CSV_reader.csv"));
                }
                else
                {
                    PB_ProgressBar.Visible = true;
                    PB_ProgressBar.MarqueeAnimationSpeed = 25;
                }
            }

            int cnt = 0;

            foreach (string name in filenames)
            {
                cnt++;

                await Task.Run(() => ReadLogs_Fn(name));
                //MessageBox.Show("Zakończono przetwarzanie logu nr: " + cnt + " o nazwie " + name);
            }
            PB_ProgressBar.MarqueeAnimationSpeed = 0;
            MessageBox.Show("Zakończono przetwarzanie wszystkich " +  cnt + " logów", "Sukces!");
            PB_ProgressBar.Visible = false;
            this.Enabled = true;
        }


        //fja uruchamiająca async operacje na logach
        protected void ReadLogs_Fn(string name)
        {
            string fdir = Path.GetDirectoryName(name);
            string fname = Path.GetFileNameWithoutExtension(name);
            string fext = Path.GetExtension(name);
            DataTable logg = OperationsLog.Logreader(name);
            System.Diagnostics.Debug.WriteLine(dt_bts.Columns.Contains("Date"));
            logg = OperationsLog.BreakBts(logg);
            System.Diagnostics.Debug.WriteLine(dt_bts.Columns.Contains("Date"));
            //MessageBox.Show("lac: " + dt.Rows[0]["lac"] + ", cid: " + dt.Rows[0]["cid"] + ", cgi: " + dt.Rows[0]["Cgi"].ToString().Substring(7,6));
            logg = JoinTab.JoinBTS2Log(dt_bts, logg);
            System.Diagnostics.Debug.WriteLine(dt_bts.Columns.Contains("Date"));
            Operations.SaveToCSV(logg, fdir + '\\' + fname + "_log" + fext);
            logg.Clear();
            logg.Reset();
            logg.Dispose();
            dt_bts.Dispose();
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
            ///SafeFileNames, FileNames
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

        private void MergeLogs_Click(object sender, EventArgs e)
        {
            List<string> allfiles = new List<string>();
            PB_ProgressBar.Show();
            PB_ProgressBar.MarqueeAnimationSpeed = 25;
            
            DialogResult ofd = SelectLog_OFD.ShowDialog();
            if (ofd == DialogResult.OK)
            {
                allfiles = SelectLog_OFD.FileNames.ToList();
            }
            //System.Diagnostics.Debug.WriteLine("Lista plików.");

            //FDB wybór plików z przygotowanymi logami
            //merge-owanie tych logów
            DataTable alllogs = JoinTab.MergeAllLogs(allfiles);
            //System.Diagnostics.Debug.WriteLine("allfiles[0]: " + allfiles[0] + " , Getdirectory: " + Path.GetDirectoryName(allfiles[0]));
            //System.Diagnostics.Debug.WriteLine("Merge zakończony.");

            //zapis logów do nowego pliku
            Operations.SaveToCSV(alllogs, Path.GetDirectoryName(allfiles[0]) + "\\AllLogsMerged.log");
            //System.Diagnostics.Debug.WriteLine("Plik zapisany.");
            PB_ProgressBar.Hide();
            MessageBox.Show("Połączono wszystkie pliki.", "Sukces!");
        }
    }
}
