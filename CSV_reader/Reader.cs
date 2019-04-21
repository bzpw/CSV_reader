using System;
using System.IO;
using System.Text;
using CsvHelper;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Xml;
using BTS_reader;

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
            List<string> pathx = WebFeatures.GetUKE();


            DataTable dt = Operations.ReadBTS(path2);
            //DataTable dtu = Operations.ReadUKE(pathx);

            DataTable AllBts = Operations.SelecMerge(dt);

            //dt.Dispose();
            //stopwatch.Stop();
            //Console.WriteLine("Czas: " + stopwatch.ElapsedMilliseconds);
            //Console.ReadKey();

            DataTable logdt = OperationsLog.Logreader(@"F:\_BZ\BTSy\log.log");
            logdt = OperationsLog.BreakBts(logdt);

            DataTable join_log = JoinTab.JoinBTS2Log(AllBts, logdt);
            //Operations.PrintToConsole(whatever);
            Operations.SaveToCSV(join_log, @"C:\Temp\Res\Joindt.csv");

            //DataTable u2b = JoinTab.JoinUKE2BTS(join_log, dtu);


            Directory.CreateDirectory(@"C:\Temp\Res\");
            string respath = @"C:\Temp\Res\CSV_reader.csv";
            string respathu = @"C:\Temp\Res\UKE_reader.csv";
            //string respathj = @"C:\Temp\Res\Joinu2b.csv";
            Operations.SaveToCSV(AllBts, respath);
            //Operations.SaveToCSV(dtu, respathu);
            //Operations.SaveToCSV(u2b, respathj);

            stopwatch.Stop();
            Console.WriteLine("Czas: " + stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}