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
            DataTable dt = bts.Clone();
            //dt.Columns.Add("LogLati");
            //dt.Columns.Add("LogLong");
            dt.Columns.Add("Date");

            for (int i = 0; i < log.Rows.Count; i++)
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
                        if (!(dr.Length < 1))
                        {
                            foreach (DataRow row in dr)
                            {
                                if (!row.Table.Columns.Contains("Date"))
                                {
                                    row.Table.Columns.Add("Date");
                                }
                                row["Date"] = log.Rows[i]["Date"];
                                dt.ImportRow(row);
                            }
                        }
                        else
                        {
                            DataRow[] drq = dt.Select("lac = '" + log.Rows[i]["lac"] + "' AND btsid = '" + log.Rows[i]["cid"].ToString().Substring(0, log.Rows[i]["cid"].ToString().Length - 1) + "'");
                            foreach (DataRow row in drq)
                            {
                                if (!row.Table.Columns.Contains("Date"))
                                {
                                    row.Table.Columns.Add("Date");
                                }
                                row["Date"] = log.Rows[i]["Date"];
                                dt.ImportRow(row);
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
                        if (!(drx.Length < 1))
                        {
                            foreach (DataRow row in drx)
                            {
                                if (!row.Table.Columns.Contains("Date"))
                                {
                                    row.Table.Columns.Add("Date");
                                }
                                row["Date"] = log.Rows[i]["Date"];
                                dt.ImportRow(row);
                            }
                        }
                        else
                        {
                            DataRow[] drxq = dt.Select("lac = '" + log.Rows[i]["lac"] + "' AND btsid = '" + log.Rows[i]["cid"].ToString().Substring(0, log.Rows[i]["cid"].ToString().Length - 1) + "'");
                            foreach (DataRow row in drxq)
                            {
                                if (!row.Table.Columns.Contains("Date"))
                                {
                                    row.Table.Columns.Add("Date");
                                }
                                row["Date"] = log.Rows[i]["Date"];
                                dt.ImportRow(row);
                            }
                        }
                        break;

                    case "LTE":
                        //DataRow[] drxxq = dt.Select("eNBI = '" + log.Rows[i]["lac"] + "'");
                        DataRow[] drxx = bts.Select("eNBI = '" + log.Rows[i]["lac"] + "' AND CLID = '" + log.Rows[i]["cid"] + "'");
                        if (!(drxx.Length < 1))
                        {
                            foreach (DataRow row in drxx)
                            {
                                if (!row.Table.Columns.Contains("Date"))
                                {
                                    row.Table.Columns.Add("Date");
                                }
                                row["Date"] = log.Rows[i]["Date"];
                                dt.ImportRow(row);
                            }
                        }
                        else
                        {
                            DataRow[] drxxq = bts.Select("eNBI = '" + log.Rows[i]["lac"] + "'");
                            foreach (DataRow row in drxxq)
                            {
                                if (!row.Table.Columns.Contains("Date"))
                                {
                                    row.Table.Columns.Add("Date");
                                }
                                row["Date"] = log.Rows[i]["Date"];
                                dt.ImportRow(row);
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            }

            return dt;
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

    }
}
