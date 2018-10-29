using System;
using System.IO;
using System.Text;
using CsvHelper;
using System.Data;
using System.Diagnostics;

namespace CSV_reader
{
    class Reader
    {
        static void Main(string[] args)
        {
            //Stopwatch stopwatch = Stopwatch.StartNew();
            //ścieżka do pliku, nazwa DT
            var path = @"F:\_BZ\BTSy\btsearch.csv";
            DataTable dt = new DataTable("BTSearch");

            if (File.Exists(path))
            {


                using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
                {
                    using (var csv = new CsvReader(sr))
                    {
                        csv.Configuration.Delimiter = ";";
                        csv.Configuration.HasHeaderRecord = true;
                        csv.Read();
                        csv.ReadHeader();

                        //lista kolumn do zachowania
                        dt.Columns.Add(new DataColumn("siec_id", typeof(String)));
                        dt.Columns.Add(new DataColumn("miejscowosc", typeof(String)));
                        dt.Columns.Add(new DataColumn("standard", typeof(String)));
                        dt.Columns.Add(new DataColumn("pasmo", typeof(String)));
                        dt.Columns.Add(new DataColumn("lac", typeof(String)));
                        dt.Columns.Add(new DataColumn("btsid", typeof(String)));
                        dt.Columns.Add(new DataColumn("ECID", typeof(String)));
                        dt.Columns.Add(new DataColumn("eNBI", typeof(String)));
                        dt.Columns.Add(new DataColumn("CLID", typeof(String)));
                        dt.Columns.Add(new DataColumn("LONGuke", typeof(String)));
                        dt.Columns.Add(new DataColumn("LATIuke", typeof(String)));
                        dt.Columns.Add(new DataColumn("StationId", typeof(String)));

                        //zapisanie danych do DataTable
                        while (csv.Read())
                        {
                            var row = dt.NewRow();
                            foreach (DataColumn column in dt.Columns)
                            {
                                row[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);
                            }
                            dt.Rows.Add(row);
                        }
                        Operations.Coords_fix(dt);

                        //wyświetl w konsoli
                        {
                            //string data = string.Empty;
                            //StringBuilder sb = new StringBuilder();
                            int cnt = 0;

                            if (null != dt && null != dt.Rows)
                            {
                                foreach (DataRow dataRow in dt.Rows)
                                {
                                    //foreach (var item in dataRow.ItemArray)
                                    //{
                                    //    sb.Append(item);
                                    //    sb.Append(',');
                                    //}
                                    //sb.AppendLine();
                                    cnt++;
                                }

                                //data = sb.ToString();
                                //Console.WriteLine(sb);
                                Console.WriteLine(cnt);
                                Console.WriteLine();
                            }
                            //Console.ReadKey();
                            Console.WriteLine();
                        }

                    }
                }
            }

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

            /*{
                string data = string.Empty;
                StringBuilder sb = new StringBuilder();
                int cnt = 0;

                if (null != AllBts && null != AllBts.Rows)
                {
                    foreach (DataRow dataRow in AllBts.Rows)
                    {
                        foreach (var item in dataRow.ItemArray)
                        {
                            sb.Append(item);
                            sb.Append(", ");
                        }
                        sb.AppendLine();
                        cnt++;
                    }

                    data = sb.ToString();
                    Console.WriteLine(sb);
                    Console.WriteLine(cnt);
                    Console.WriteLine();
                }
            //Console.ReadKey();

            }*/
            string respath = @"F:\_BZ\BTSy\CSV_reader.csv";
            Operations.SaveToCSV(AllBts, respath);
        }
    }
}