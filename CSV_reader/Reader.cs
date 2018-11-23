using System;
using System.IO;
using System.Text;
using CsvHelper;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Xml;

namespace CSV_reader
{
    class Reader
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            //ścieżka do pliku, nazwa DT
            string path = @"C:\Temp\";
            string path2 = WebFeatures.DLb(path);
            //List<string> pathx = WebFeatures.GetUKE();

            DataTable dt = Operations.ReadBTS(path2);
            //DataTable dtu = Operations.ReadUKE(pathx);

            //!operacje na DT
            //DataTable cdma42 = Operations.Sel_23G("CDMA", "420", dt); //brak w btsearch
            //DataTable cdma42s = Operations.ConcStations(ref cdma42, 1);
            //DataTable cdma45 = Operations.Sel_23G("CDMA", "450", dt); //brak w btsearch 
            //DataTable cdma45s = Operations.ConcStations(ref cdma45, 1);
            DataTable gsm18 = Operations.Sel_23G("GSM", "1800", ref dt); //potrzebny LAC i CID
            DataTable gsm18s = Operations.ConcStations(gsm18, 1);
            DataTable gsm9 = Operations.Sel_23G("GSM", "900", ref dt); //potrzebny LAC i CID
            DataTable gsm9s = Operations.ConcStations(gsm9, 1);
            DataTable gsm9e = Operations.Sel_23G("E-GSM", "900", ref dt); //potrzebny LAC i CID -> CID = btsid --ostatnia cyfra (z jednej z kolumn cid*)
            DataTable gsm9es = Operations.ConcStations(gsm9e, 1);
            DataTable lte18 = Operations.Sel_4G("LTE", "1800", ref dt); //identyfikacja po ENBI / CLID / ECID
            DataTable lte18s = Operations.ConcStations(lte18, 2);
            DataTable lte21 = Operations.Sel_4G("LTE", "2100", ref dt); //identyfikacja po ENBI / CLID / ECID
            DataTable lte21s = Operations.ConcStations(lte21, 2);
            DataTable lte26 = Operations.Sel_4G("LTE", "2600", ref dt); //identyfikacja po ENBI / CLID / ECID
            DataTable lte26s = Operations.ConcStations(lte26, 2);
            DataTable lte8 = Operations.Sel_4G("LTE", "800", ref dt); //identyfikacja po ENBI / CLID / ECID
            DataTable lte8s = Operations.ConcStations(lte8, 2);
            DataTable lte9 = Operations.Sel_4G("LTE", "900", ref dt); //identyfikacja po ENBI / CLID / ECID
            DataTable lte9s = Operations.ConcStations(lte9, 2);
            DataTable umts18 = Operations.Sel_23G("UMTS", "1800", ref dt); //potrzebny LAC i CID
            DataTable umts18s = Operations.ConcStations(umts18, 1);
            DataTable umts21 = Operations.Sel_23G("UMTS", "2100", ref dt); //potrzebny LAC i CID
            DataTable umts21s = Operations.ConcStations(umts21, 1);
            DataTable umts9 = Operations.Sel_23G("UMTS", "900", ref dt); //potrzebny LAC i CID
            DataTable umts9s = Operations.ConcStations(umts9, 1);

            DataTable AllBts = new DataTable();
            //AllBts.Merge(cdma42);
            //AllBts.Merge(cdma45);
            AllBts.Merge(gsm18);
            AllBts.Merge(gsm9);
            AllBts.Merge(gsm9e);
            AllBts.Merge(lte18);
            AllBts.Merge(lte21);
            AllBts.Merge(lte26);
            AllBts.Merge(lte8);
            AllBts.Merge(lte9);
            AllBts.Merge(umts18);
            AllBts.Merge(umts21);
            AllBts.Merge(umts9);

            /*DataTable newbt = new DataTable();
            //newbt.Merge(cdma42s);
            //newbt.Merge(cdma45s);
            newbt.Merge(gsm18s);
            newbt.Merge(gsm9s);
            newbt.Merge(gsm9es);
            newbt.Merge(lte18s);
            newbt.Merge(lte21s);
            newbt.Merge(lte26s);
            newbt.Merge(lte8s);
            newbt.Merge(lte9s);
            newbt.Merge(umts18s);
            newbt.Merge(umts21s);
            newbt.Merge(umts9s);*/

            //dt.Dispose();
            //stopwatch.Stop();
            //Console.WriteLine("Czas: " + stopwatch.ElapsedMilliseconds);
            //Console.ReadKey();

            //zapis na konsole
            //Operations.PrintToConsole(dt);
            Console.WriteLine("przed conc");
            Console.WriteLine("po conc");
            //Operations.PrintToConsole(newbt);

            Directory.CreateDirectory(@"C:\Temp\Res\");
            string respath = @"C:\Temp\Res\CSV_reader.csv";
            string respathu = @"C:\Temp\Res\UKE_reader.csv";
            Operations.SaveToCSV(AllBts, respath);
            //Operations.SaveToCSV(dtu, respathu);
            //Operations.SaveToCSV(newbt, @"C:\Temp\Res\Shorte.csv");

            stopwatch.Stop();
            Console.WriteLine("Czas: " + stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}