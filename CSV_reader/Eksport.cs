using System;
using System.IO;
using System.Text;
using System.Data;

namespace CSV_reader
{
    class Exx
    {

        public static DataTable Exx_23G(string stan, string pasm, DataTable base_dt)
        {

            DataTable eksp_dt = new DataTable();
            DataRow[] eksp_r = new DataRow[0];

            eksp_r = base_dt.Select("standard = '" + stan + "' AND pasmo = '" + pasm + "' AND (LAC <> '' OR btsid <> '')");

            if (eksp_r.Length > 0)
            {
                eksp_dt = eksp_r.CopyToDataTable();
            }
        
            //print *optional
            /*{
                //string data = string.Empty;
                //StringBuilder sb = new StringBuilder();
                int cnt = 0;

                if (null != eksp_dt && null != eksp_dt.Rows)
                {
                    foreach (DataRow dataRow in eksp_dt.Rows)
                    {
                        foreach (var item in dataRow.ItemArray)
                        {
                            sb.Append(item);
                            sb.Append(',');
                        }
                        //sb.AppendLine();
                        cnt++;
                    }
                    //data = sb.ToString();
                    //Console.WriteLine(sb);
                    Console.WriteLine(cnt);
                    Console.WriteLine();
                }
            }*/
            //Console.ReadKey();

            return eksp_dt;
        }


        public static DataTable Exx_4G(string stan, string pasm, DataTable base_dt)
        {

            DataTable eksp_dt = new DataTable();
            DataRow[] eksp_r = new DataRow[0];

            eksp_r = base_dt.Select("standard = '" + stan + "' AND pasmo = '" + pasm + "' AND (ECID <> '' OR eNBI <> '' OR CLID <> '')");

            if (eksp_r.Length > 0)
            {
                eksp_dt = eksp_r.CopyToDataTable();
            }

            //print *optional
            /*{
                //string data = string.Empty;
                //StringBuilder sb = new StringBuilder();
                int cnt = 0;

                if (null != eksp_dt && null != eksp_dt.Rows)
                {
                    foreach (DataRow dataRow in eksp_dt.Rows)
                    {
                        foreach (var item in dataRow.ItemArray)
                        {
                            sb.Append(item);
                            sb.Append(',');
                        }
                        //sb.AppendLine();
                        cnt++;
                    }
                    //data = sb.ToString();
                    //Console.WriteLine(sb);
                    Console.WriteLine(cnt);
                    Console.WriteLine();
                }
            }*/
            //Console.ReadKey();

            return eksp_dt;
        }
    }
}
