using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;

namespace CSV_reader
{
    class Operations
    {

        public static DataTable Sel_23G(string stan, string pasm, DataTable base_dt)
        {

            DataTable eksp_dt = new DataTable();
            DataRow[] eksp_r = new DataRow[0];

            eksp_r = base_dt.Select("standard = '" + stan + "' AND pasmo = '" + pasm + "' AND (LAC <> '' OR btsid <> '')");

            if (eksp_r.Length > 0)
            {
                eksp_dt = eksp_r.CopyToDataTable();
            }
        
            //print *optional
            {
                //string data = string.Empty;
                //StringBuilder sb = new StringBuilder();
                int cnt = 0;

                if (null != eksp_dt && null != eksp_dt.Rows)
                {
                    foreach (DataRow dataRow in eksp_dt.Rows)
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
            }
            //Console.ReadKey();

            return eksp_dt;
        }


        public static DataTable Sel_4G(string stan, string pasm, DataTable base_dt)
        {

            DataTable eksp_dt = new DataTable();
            DataRow[] eksp_r = new DataRow[0];

            eksp_r = base_dt.Select("standard = '" + stan + "' AND pasmo = '" + pasm + "' AND (ECID <> '' OR eNBI <> '' OR CLID <> '')");

            if (eksp_r.Length > 0)
            {
                eksp_dt = eksp_r.CopyToDataTable();
            }

            //print *optional
            {
                //string data = string.Empty;
                //StringBuilder sb = new StringBuilder();
                int cnt = 0;

                if (null != eksp_dt && null != eksp_dt.Rows)
                {
                    foreach (DataRow dataRow in eksp_dt.Rows)
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
            }
            //Console.ReadKey();

            return eksp_dt;
        }

        public static DataTable Coords_fix(DataTable base_dt)
        {
            string llong, llati;

            DataRow[] dr = base_dt.Select("LONGuke <> '' AND LATIuke <> ''");

            for(int i=0; i<dr.Length; i++)
            {
                llong = dr[i]["LONGuke"].ToString().Replace('E', ',');
                llati = dr[i]["LATIuke"].ToString().Replace('N', ',');

                dr[i]["LONGuke"] = llong;
                dr[i]["LATIuke"] = llati;
            }

            base_dt = dr.CopyToDataTable();

            return base_dt;
        }

        public static void SaveToCSV(DataTable dt, string path)
        {
            //var origin = @"F:\_BZ\BTSy\CSV_reader.csv";
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

            using (var textWriter = File.CreateText(path))
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

        }
    }
}
