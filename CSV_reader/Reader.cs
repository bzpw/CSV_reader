﻿using System;
using System.IO;
using System.Text;
using CsvHelper;
using System.Data;

namespace CSV_reader
{
    class Reader
    {
        static void Main(string[] args)
        {
            //ścieżka do pliku, nazwa DT
            var path = @"F:\_BZ\BTSy\btsearch.csv";
            DataTable dt = new DataTable("BTSearch");


            using (StreamReader sr = new StreamReader(path))
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

                    /*DataTable BTSearchFix = dt.Clone();
                    BTSearchFix.Columns[3].DataType = typeof(Int32);
                    BTSearchFix.Columns[4].DataType = typeof(Int32);
                    BTSearchFix.Columns[5].DataType = typeof(Int32);
                    BTSearchFix.Columns[6].DataType = typeof(Int32);
                    foreach (DataRow row in dt.Rows)
                    {
                        BTSearchFix.ImportRow(row);
                    }*/

                    //wyświetl w konsoli
                    {
                        string data = string.Empty;
                        StringBuilder sb = new StringBuilder();
                        int cnt = 0;

                        if (null != dt && null != dt.Rows)
                        {
                            foreach (DataRow dataRow in dt.Rows)
                            {
                                foreach (var item in dataRow.ItemArray)
                                {
                                    sb.Append(item);
                                    sb.Append(',');
                                }
                                sb.AppendLine();
                                cnt++;
                            }

                            data = sb.ToString();
                            Console.WriteLine(sb);
                            Console.WriteLine(cnt);
                            Console.WriteLine();
                        }
                        Console.ReadKey();
                    }
                }
            }

            //!operacje na DT
            //wybór niepustych stacji LTE1800
            /*DataTable dt_lte18 = dt.Select("standard = 'LTE' AND pasmo = '1800' AND (ECID <> '' OR eNBI <> '' OR CLID <> '')").CopyToDataTable();
            {
                string data = string.Empty;
                StringBuilder sb = new StringBuilder();
                int cnt = 0;

                if (null != dt_lte18 && null != dt_lte18.Rows)
                {
                    foreach (DataRow dataRow in dt_lte18.Rows)
                    {
                        foreach (var item in dataRow.ItemArray)
                        {
                            sb.Append(item);
                            sb.Append(',');
                        }
                        sb.AppendLine();
                        cnt++;
                    }

                    data = sb.ToString();
                    Console.WriteLine(sb);
                    Console.WriteLine(cnt);
                }
                Console.ReadKey();
            }*/

            DataTable cdma42 = Exx.Exx_23G("CDMA", "420", dt); //brak w btsearch
            DataTable cdma45 = Exx.Exx_23G("CDMA", "450", dt); //brak w btsearch 
            DataTable gsm18 = Exx.Exx_23G("GSM", "1800", dt); //potrzebny LAC i CID (jak rozszyfrować cid?)
            DataTable gsm9 = Exx.Exx_23G("GSM", "900", dt); //potrzebny LAC i CID (jak rozszyfrować cid?)
            DataTable gsm9e = Exx.Exx_23G("E-GSM", "900", dt); //potrzebny LAC i CID (jak rozszyfrować cid?) -> CID = btsid --ostatnia cyfra (z jednej z kolumn cid*)
            DataTable lte18 = Exx.Exx_4G("LTE", "1800", dt); //identyfikacja po ENBI / CLID / ECID
            DataTable lte21 = Exx.Exx_4G("LTE", "2100", dt); //identyfikacja po ENBI / CLID / ECID
            DataTable lte26 = Exx.Exx_4G("LTE", "2600", dt); //identyfikacja po ENBI / CLID / ECID
            DataTable lte8 = Exx.Exx_4G("LTE", "800", dt); //identyfikacja po ENBI / CLID / ECID
            DataTable lte9 = Exx.Exx_4G("LTE", "900", dt); //identyfikacja po ENBI / CLID / ECID
            DataTable umts18 = Exx.Exx_23G("UMTS", "1800", dt); //potrzebny LAC i CID (jak rozszyfrować cid?)
            DataTable umts21 = Exx.Exx_23G("UMTS", "2100", dt); //potrzebny LAC i CID (jak rozszyfrować cid?)
            DataTable umts9 = Exx.Exx_23G("UMTS", "900", dt); //potrzebny LAC i CID (jak rozszyfrować cid?)

            dt.Dispose();
            Console.ReadKey();

        }
    }
}
