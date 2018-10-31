using System;
using System.IO;
using System.Text;
using CsvHelper;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;

namespace CSV_reader
{
    class Reader
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            //ścieżka do pliku, nazwa DT
            string path = @"F:\_BZ\BTSy\btsearch.csv";
            string[] paths = Directory.GetFiles(@"F:\_BZ\BTSy\2018-03-26");


            DataTable dt = Operations.ReadBTS(path);
            DataTable dtu = Operations.ReadUKE(paths);

            //!operacje na DT
            DataTable cdma42 = Operations.Sel_23G("CDMA", "420", dt); //brak w btsearch
            DataTable cdma45 = Operations.Sel_23G("CDMA", "450", dt); //brak w btsearch 
            DataTable gsm18 = Operations.Sel_23G("GSM", "1800", dt); //potrzebny LAC i CID
            DataTable gsm9 = Operations.Sel_23G("GSM", "900", dt); //potrzebny LAC i CID
            DataTable gsm9e = Operations.Sel_23G("E-GSM", "900", dt); //potrzebny LAC i CID -> CID = btsid --ostatnia cyfra (z jednej z kolumn cid*)
            DataTable lte18 = Operations.Sel_4G("LTE", "1800", dt); //identyfikacja po ENBI / CLID / ECID
            DataTable lte21 = Operations.Sel_4G("LTE", "2100", dt); //identyfikacja po ENBI / CLID / ECID
            DataTable lte26 = Operations.Sel_4G("LTE", "2600", dt); //identyfikacja po ENBI / CLID / ECID
            DataTable lte8 = Operations.Sel_4G("LTE", "800", dt); //identyfikacja po ENBI / CLID / ECID
            DataTable lte9 = Operations.Sel_4G("LTE", "900", dt); //identyfikacja po ENBI / CLID / ECID
            DataTable umts18 = Operations.Sel_23G("UMTS", "1800", dt); //potrzebny LAC i CID
            DataTable umts21 = Operations.Sel_23G("UMTS", "2100", dt); //potrzebny LAC i CID
            DataTable umts9 = Operations.Sel_23G("UMTS", "900", dt); //potrzebny LAC i CID

            DataTable AllBts = new DataTable();
            AllBts.Merge(cdma42);
            AllBts.Merge(cdma45);
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

            dt.Dispose();
            //stopwatch.Stop();
            //Console.WriteLine("Czas: " + stopwatch.ElapsedMilliseconds);
            //Console.ReadKey();

            //zapis na konsole
            //Operations.PrintToConsole(dt);

            string respath = @"F:\_BZ\BTSy\CSV_reader.csv";
            string respathu = @"F:\_BZ\BTSy\UKE_reader.csv";
            Operations.SaveToCSV(AllBts, respath);
            Operations.SaveToCSV(dtu, respathu);

            stopwatch.Stop();
            Console.WriteLine("Czas: " + stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}