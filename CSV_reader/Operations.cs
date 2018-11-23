using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using ExcelDataReader;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSV_reader
{
    class Operations
    {
        public static DataTable ReadBTS(string path)
        {
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
                        List<string> headers = csv.Context.HeaderRecord.ToList();
                        foreach (string header in headers)
                        {
                            dt.Columns.Add(new DataColumn(header));
                        }

                        //lista kolumn do zachowania
                        /*dt.Columns.Add(new DataColumn("siec_id", typeof(String)));
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
                        dt.Columns.Add(new DataColumn("StationId", typeof(String)));*/
                                                
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
                        Console.WriteLine("csv.Read");
                        Operations.Coords_fix(dt);
                        Console.WriteLine("Coords_fix");

                        //zapis na konsole
                        //PrintToConsole(dt);

                    }
                }
            }
            return dt;
        }


        public static DataTable ReadUKE(List<string> urls)
        {
            //DataTable uke = new DataTable("UKE");
            DataTable dt = new DataTable("UKE");
            dt.Columns.Add(new DataColumn("Operator", typeof(String)));
            dt.Columns.Add(new DataColumn("NrDecyzji", typeof(String)));
            dt.Columns.Add(new DataColumn("DlGeogr", typeof(String)));
            dt.Columns.Add(new DataColumn("SzGeogr", typeof(String)));
            dt.Columns.Add(new DataColumn("Miejscowosc", typeof(String)));
            dt.Columns.Add(new DataColumn("Lokalizacja", typeof(String)));
            dt.Columns.Add(new DataColumn("IdStacji", typeof(String)));

            var dir = @"C:\Temp\DL_UKE\";
            //var dir = @"F:\_BZ\BTSy\DL_UKE\";
            Directory.CreateDirectory(dir);

            foreach (string url in urls)
            {
                WebFeatures.DLu(dir, url);
            }

            string[] paths = Directory.GetFiles(dir);

            foreach (string path in paths)
            {
                if (File.Exists(path))
                {
                    using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read))
                    {
                        Console.WriteLine("Opened: " + path);
                        IExcelDataReader reader;
                        reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);
                        var conf = new ExcelDataSetConfiguration
                        {
                            UseColumnDataType = true,
                            ConfigureDataTable = _ => new ExcelDataTableConfiguration
                            {
                                UseHeaderRow = false,
                                FilterRow = rowReader => rowReader.Depth > 1
                            }
                        };
                        var dataSet = reader.AsDataSet(conf);
                        DataTable dataTable = dataSet.Tables[0];

                        foreach (DataRow dr in dataTable.Rows)
                        {
                            DataRow ndr = dt.NewRow();
                            ndr["Operator"] = dr[0];
                            ndr["NrDecyzji"] = dr[1];
                            ndr["DlGeogr"] = dr[4];
                            ndr["SzGeogr"] = dr[5];
                            ndr["Miejscowosc"] = dr[6];
                            ndr["Lokalizacja"] = dr[7];
                            ndr["IdStacji"] = dr[8];
                            dt.Rows.Add(ndr);
                        }
                    }
                }

            }
            Coords_fixu(dt);
            /*foreach (string path in paths)
            {
                File.Delete(path);
                Console.WriteLine("File deleted.");
                System.Threading.Thread.Sleep(50);
            }
            Directory.Delete(dir);*/

            return dt;
        }

        public static void PrintToConsole(DataTable dt)
        {
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
                //Console.ReadKey();
                //Console.WriteLine();
            }
        }

        public static DataTable Sel_23G(string stan, string pasm, ref DataTable base_dt)
        {

            DataTable eksp_dt = new DataTable();
            DataRow[] eksp_r = new DataRow[0];

            eksp_r = base_dt.Select("standard = '" + stan + "' AND pasmo = '" + pasm + "' AND (lac <> '' AND btsid <> '' AND lac IS NOT NULL AND btsid IS NOT NULL)");

            if (eksp_r.Length > 0)
            {
                eksp_dt = eksp_r.CopyToDataTable();
            }

            //zapis na konsole
            //PrintToConsole(eksp_dt);
            //base_dt.Clear();
            //base_dt.Dispose();
            //base_dt = null;
            Console.WriteLine("Sel_23G");
            return eksp_dt;
        }


        public static DataTable Sel_4G(string stan, string pasm, ref DataTable base_dt)
        {

            DataTable eksp_dt = new DataTable();
            DataRow[] eksp_r = new DataRow[0];

            eksp_r = base_dt.Select("standard = '" + stan + "' AND pasmo = '" + pasm + "' AND (ECID <> '' AND eNBI <> '' AND CLID <> '')");

            if (eksp_r.Length > 0)
            {
                eksp_dt = eksp_r.CopyToDataTable();
            }

            //zapis na konsole
            //PrintToConsole(eksp_dt);
            //base_dt.Clear();
            //base_dt.Dispose();
            //base_dt = null;
            Console.WriteLine("Sel_4G");
            return eksp_dt;
        }

        public static DataTable Coords_fix(DataTable base_dt)
        {
            string llong, llati;

            DataRow[] dr = base_dt.Select("LONGuke <> '' AND LATIuke <> '' AND LONGuke IS NOT NULL AND LATIuke IS NOT NULL");

            for (int i = 0; i < dr.Length; i++)
            {
                llong = dr[i]["LONGuke"].ToString().Replace('E', '.');
                llati = dr[i]["LATIuke"].ToString().Replace('N', '.');

                dr[i]["LONGuke"] = llong;
                dr[i]["LATIuke"] = llati;
            }

            base_dt = dr.CopyToDataTable();
            return base_dt;
            }

        public static DataTable Coords_fixu(DataTable base_dt)
        {
            string llong, llati;

            DataRow[] dr = base_dt.Select("DlGeogr <> '' AND SzGeogr <> '' AND DlGeogr IS NOT NULL AND SzGeogr IS NOT NULL");

            for (int i = 0; i < dr.Length; i++)
            {
                llong = dr[i]["DlGeogr"].ToString().Replace('E', '.');
                llong = llong.Replace("\'", "");
                llong = llong.TrimEnd('\"');
                llati = dr[i]["SzGeogr"].ToString().Replace('N', '.');
                llati = llati.TrimEnd('\"');
                llati = llati.Replace("\'", "");

                dr[i]["DlGeogr"] = llong;
                dr[i]["SzGeogr"] = llati;
            }

            base_dt = dr.CopyToDataTable();
            return base_dt;
        }


        public static DataTable ConcStations(DataTable base_dt, int wer)
        {
            DataTable dt = base_dt.Copy();

            Dictionary<string, string> uniquenessDict = new Dictionary<string, string>(base_dt.Rows.Count);
            StringBuilder sb = null;
            int rowIndex = 0;
            DataRow row;
            DataRowCollection rows = base_dt.Rows;

            while (rowIndex < rows.Count - 1)
            {
                row = rows[rowIndex];
                sb = new StringBuilder();
                switch (wer)
                {
                    case 1:
                        sb.Append(row["lac"].ToString());
                        sb.Append(row["btsid"].ToString().Substring(0, row["btsid"].ToString().Length-1).ToString());
                        sb.Append(row["StationID"].ToString());
                        break;
                    case 2:
                        sb.Append(row["eNBI"].ToString());
                        sb.Append(row["StationID"].ToString());
                        break;
                }
                if (uniquenessDict.ContainsKey(sb.ToString()))
                {
                    rows.Remove(row);
                }
                else
                {
                    uniquenessDict.Add(sb.ToString(), string.Empty);
                    rowIndex++;
                }
            }

            return dt;
        }


        public static void SaveToCSV(DataTable dt, string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            using (var textWriter = new StreamWriter(path, false, Encoding.UTF8))
            using (var csv = new CsvWriter(textWriter))
            {
                // Write columns
                csv.Configuration.Delimiter = ";";
                foreach (DataColumn column in dt.Columns)
                {
                    csv.WriteField(column.ColumnName);
                }
                csv.NextRecord();

                // Write row values
                foreach (DataRow row in dt.Rows)
                {
                    for (var i = 0; i < dt.Columns.Count; i++)
                    {
                        csv.WriteField(row[i]);
                    }
                    csv.NextRecord();
                }
            }
            //dt.Clear();
            //dt.Dispose();
            //dt = null;

        }

    }
}
