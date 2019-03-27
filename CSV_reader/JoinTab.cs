using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using ExcelDataReader;
using deTracker;

namespace CSV_reader
{
    public class JoinTab
    {

        public static DataTable JoinBTS2Log(DataTable bts, DataTable log)
        {
            DataTable dtt = new DataTable();
            dtt = bts.Clone();
            //dt.Columns.Add("LogLati");
            //dt.Columns.Add("LogLong");
            if (!dtt.Columns.Contains("Date"))
            {
                dtt.Columns.Add("Date");
            }
            if (!dtt.Columns.Contains("Time"))
            {
                dtt.Columns.Add("Time");
            }

            //System.Diagnostics.Debug.WriteLine("DEBUG Log line 209: " + log.Rows[209][0].ToString());
            //System.Diagnostics.Debug.WriteLine("DEBUG dtt line 200: " + dtt.Rows[200][0].ToString());


            for (int i = 0; i < log.Rows.Count-1; i++)
            {

                switch (log.Rows[i]["NetworkType"])
                {
                    case "HSPA":
                        DataRow[] dr = bts.Select("lac = '" + log.Rows[i]["lac"] + "' AND btsid = '" + log.Rows[i]["cid"].ToString().Substring(0, log.Rows[i]["cid"].ToString().Length - 1) + "' AND " +
                            "(cid1 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid2 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid3 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid4 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid5 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid6 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid7 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid8 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid9 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid0 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "')");
                        if (dr.Length == 1)
                        {
                            foreach (DataRow row in dr)
                            {
                                dtt.ImportRow(row);
                                dtt.Rows[i]["Date"] = log.Rows[i]["Date"];
                                DateTime time = DateTime.Parse(log.Rows[i]["Date"].ToString());
                                dtt.Rows[i]["Time"] = time.ToString("HH:mm:ss");
                            }
                        }
                        else
                        {
                            DataRow[] drq = dtt.Select("lac = '" + log.Rows[i]["lac"] + "' AND btsid = '" + log.Rows[i]["cid"].ToString().Substring(0, log.Rows[i]["cid"].ToString().Length - 1) + "'");
                            foreach (DataRow row in drq)
                            {
                                dtt.ImportRow(row);
                                dtt.Rows[i]["Date"] = log.Rows[i]["Date"];
                                DateTime time = DateTime.Parse(log.Rows[i]["Date"].ToString());
                                dtt.Rows[i]["Time"] = time.ToString("HH:mm:ss");
                            }
                        }
                        break;

                    case "HSPAP":
                        DataRow[] drx = bts.Select("lac = '" + log.Rows[i]["lac"] + "' AND btsid = '" + log.Rows[i]["cid"].ToString().Substring(0, log.Rows[i]["cid"].ToString().Length - 1) + "' AND (" +
                            "cid1 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid2 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid3 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid4 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid5 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid6 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid7 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid8 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid9 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "' OR " +
                            "cid0 = '" + log.Rows[i]["cid"].ToString().Substring(log.Rows[i]["cid"].ToString().Length - 1) + "')");
                        if (drx.Length == 1)
                        {
                            foreach (DataRow row in drx)
                            {
                                dtt.ImportRow(row);
                                dtt.Rows[i]["Date"] = log.Rows[i]["Date"];
                                DateTime time = DateTime.Parse(log.Rows[i]["Date"].ToString());
                                dtt.Rows[i]["Time"] = time.ToString("HH:mm:ss");
                            }
                        }
                        else
                        {
                            DataRow[] drxq = dtt.Select("lac = '" + log.Rows[i]["lac"] + "' AND btsid = '" + log.Rows[i]["cid"].ToString().Substring(0, log.Rows[i]["cid"].ToString().Length - 1) + "'");
                            foreach (DataRow row in drxq)
                            {
                                dtt.ImportRow(row);
                                dtt.Rows[i]["Date"] = log.Rows[i]["Date"];
                                DateTime time = DateTime.Parse(log.Rows[i]["Date"].ToString());
                                dtt.Rows[i]["Time"] = time.ToString("HH:mm:ss");
                            }
                        }
                        break;

                    case "LTE":
                        //DataRow[] drxxq = dt.Select("eNBI = '" + log.Rows[i]["lac"] + "'");
                        DataRow[] drxx = bts.Select("eNBI = '" + log.Rows[i]["lac"] + "' AND CLID = '" + log.Rows[i]["cid"] + "'");
                        if (drxx.Length == 1)
                        {
                            foreach (DataRow row in drxx)
                            {            
                                foreach(var item in log.Rows[i].ItemArray)
                                {
                                    System.Diagnostics.Debug.Write(item.ToString() + "\t");
                                }
                                foreach(var item in row.ItemArray)
                                {
                                    System.Diagnostics.Debug.Write(item.ToString() + "\t");
                                }
                                System.Diagnostics.Debug.WriteLine("\n");
                                //dtt.ImportRow(row);
                                DataRow ndr = dtt.NewRow();
                                //dtt.Rows.Add(row.ItemArray);
                                ndr.ItemArray = row.ItemArray;
                                //dtt.Rows[i]["Date"] = log.Rows[i]["Date"];
                                ndr["Date"] = log.Rows[i]["Date"];
                                DateTime time = DateTime.Parse(log.Rows[i]["Date"].ToString());
                                //dtt.Rows[i]["Time"] = time.ToString("HH:mm:ss");
                                ndr["Time"] = time.ToString("HH:mm:ss");
                                dtt.ImportRow(ndr);
                            }
                        }
                        else
                        {
                            DataRow[] drxxq = dtt.Select("eNBI = '" + log.Rows[i]["lac"] + "'"); //!! bts.Select na dtt.Select
                            foreach (DataRow row in drxxq)
                            {
                                dtt.ImportRow(row);
                                dtt.Rows[i]["Date"] = log.Rows[i]["Date"];
                                DateTime time = DateTime.Parse(log.Rows[i]["Date"].ToString());
                                dtt.Rows[i]["Time"] = time.ToString("HH:mm:ss");
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            }
            //bts.Clear();
            //bts.Reset();
            //bts.Dispose();
            return dtt;
        }


        public static DataTable JoinUKE2BTS(DataTable bts, DataTable uke)
        {
            DataTable dt = bts.Clone();
            //dt.Columns.Add("LogLati");
            //dt.Columns.Add("LogLong");
            dt.Columns.Add("UKE_PosLong");
            dt.Columns.Add("UKE_PosLati");
            dt.Columns.Add("UKE_Status");

            for (int i = 0; i < uke.Rows.Count; i++)
            {
                if ((i+1 < uke.Rows.Count) && (uke.Rows[i]["IdStacji"] == uke.Rows[i+1]["IdStacji"]))
                {
                    i++;
                    continue;
                }

                DataRow[] dr = bts.Select("StationId = '" + uke.Rows[i]["IdStacji"] + "'");
                if (!(dr.Length < 1))
                {
                    foreach (DataRow row in dr)
                    {
                        if (!row.Table.Columns.Contains("UKE_PosLong"))
                        {
                            row.Table.Columns.Add("UKE_PosLong");
                        }
                        if (!row.Table.Columns.Contains("UKE_PosLati"))
                        {
                            row.Table.Columns.Add("UKE_PosLati");
                        }
                        if (!row.Table.Columns.Contains("UKE_Status"))
                        {
                            row.Table.Columns.Add("UKE_Status");
                        }
                        row["UKE_PosLong"] = uke.Rows[i]["DlGeogr"];
                        row["UKE_PosLati"] = uke.Rows[i]["SzGeogr"];
                        row["UKE_Status"] = "Copied.";
                        dt.ImportRow(row);
                    }
                }
                else
                {
                    DataRow rr = bts.Copy().Rows[1];
                    if (!rr.Table.Columns.Contains("UKE_PosLong"))
                    {
                        rr.Table.Columns.Add("UKE_PosLong");
                    }
                    if (!rr.Table.Columns.Contains("UKE_PosLati"))
                    {
                        rr.Table.Columns.Add("UKE_PosLati");
                    }
                    if (!rr.Table.Columns.Contains("UKE_Status"))
                    {
                        rr.Table.Columns.Add("UKE_Status");
                    }
                    foreach (DataColumn column in rr.Table.Columns)
                    {
                        rr[column] = null;
                    }
                    rr["StationId"] = uke.Rows[i]["IdStacji"];
                    rr["UKE_PosLong"] = null;
                    rr["UKE_PosLati"] = null;
                    rr["UKE_Status"] = "No match in BTSearch.";                
                    dt.ImportRow(rr);
                    Console.WriteLine("No match for: " + uke.Rows[i]["IdStacji"]);
                }

                //dorobić sprawdzanie niewykorzystanych stacji BTS
                /*DataTable dt2 = dt.Clone();
                foreach (DataRow dra in dt.Rows)
                {
                    DataRow[] drr = bts.Select("StationId NOT IN '" + dra["StationId"] + "'");

                    
                }*/

            }

            return dt;
        }


        public static DataTable MergeAllLogs(List<string> files)
        {
            DataTable log_dt = new DataTable();

            foreach (string file in files){
                DataTable log1 = Operations.ReadBTS(file);
                log_dt.Merge(log1);
                log1.Clear();
                log1.Dispose();
            }
            //System.Diagnostics.Debug.WriteLine("Merge wykonany po raz n.");

            return log_dt;
        }
    }
}
