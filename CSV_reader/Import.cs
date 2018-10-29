/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Diagnostics;

namespace CSV_reader
{
    class Import
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            StreamReader csvreader = new StreamReader(@"F:\_BZ\BTSy\btsearch.csv");
            string inputLine = "";

            while ((inputLine = csvreader.ReadLine()) != null)
            {
                var station = new BTS();
                string[] csvArray = inputLine.Split(new char[] { ';' });
                station.siec_id = csvArray[1];
                station.miejscowosc = csvArray[3];
                station.standard = csvArray[5];
                station.pasmo = csvArray[6];
                station.LAC = csvArray[7];
                station.btsid = csvArray[8];
                station.ECID = csvArray[19];
                station.eNBI = csvArray[20];
                station.CLID = csvArray[21];
                station.LONGuke = csvArray[23];
                station.LATIuke = csvArray[24];
                station.StationId = csvArray[26];

                BTS.BTStations.Add(station);
            }

            //add data to datatable
            DataTable dt = new DataTable();
            dt.Columns.Add("siec_id", typeof(string));
            dt.Columns.Add("miejscowosc", typeof(string));
            dt.Columns.Add("standard", typeof(string));
            dt.Columns.Add("pasmo", typeof(string));
            dt.Columns.Add("LAC", typeof(string));
            dt.Columns.Add("btsid", typeof(string));
            dt.Columns.Add("ECID", typeof(string));
            dt.Columns.Add("eNBI", typeof(string));
            dt.Columns.Add("CLID", typeof(string));
            dt.Columns.Add("LONGuke", typeof(string));
            dt.Columns.Add("LATIuke", typeof(string));
            dt.Columns.Add("StationId", typeof(string));

            foreach (BTS bts in BTS.BTStations)
            {
                dt.Rows.Add(new object[] { bts.siec_id, bts.miejscowosc, bts.standard, bts.pasmo, bts.LAC, bts.btsid, bts.ECID, bts.eNBI, bts.CLID, bts.LONGuke, bts.LATIuke, bts.StationId });
            }

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

            DataTable cdma42 = Exx.Exx_23G("CDMA", "420", dt); //brak w btsearch
            DataTable cdma45 = Exx.Exx_23G("CDMA", "450", dt); //brak w btsearch 
            DataTable gsm18 = Exx.Exx_23G("GSM", "1800", dt); //potrzebny LAC i CID
            DataTable gsm9 = Exx.Exx_23G("GSM", "900", dt); //potrzebny LAC i CID
            DataTable gsm9e = Exx.Exx_23G("E-GSM", "900", dt); //potrzebny LAC i CID -> CID = btsid --ostatnia cyfra (z jednej z kolumn cid*)
            DataTable lte18 = Exx.Exx_4G("LTE", "1800", dt); //identyfikacja po ENBI / CLID / ECID
            DataTable lte21 = Exx.Exx_4G("LTE", "2100", dt); //identyfikacja po ENBI / CLID / ECID
            DataTable lte26 = Exx.Exx_4G("LTE", "2600", dt); //identyfikacja po ENBI / CLID / ECID
            DataTable lte8 = Exx.Exx_4G("LTE", "800", dt); //identyfikacja po ENBI / CLID / ECID
            DataTable lte9 = Exx.Exx_4G("LTE", "900", dt); //identyfikacja po ENBI / CLID / ECID
            DataTable umts18 = Exx.Exx_23G("UMTS", "1800", dt); //potrzebny LAC i CID
            DataTable umts21 = Exx.Exx_23G("UMTS", "2100", dt); //potrzebny LAC i CID
            DataTable umts9 = Exx.Exx_23G("UMTS", "900", dt); //potrzebny LAC i CID

            stopwatch.Stop();
            Console.WriteLine("Czas: " + stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
    public class BTS
    {
        public static List<BTS> BTStations = new List<BTS>();
        public string siec_id { get; set; }
        public string miejscowosc { get; set; }
        public string standard { get; set; }
        public string pasmo { get; set; }
        public string LAC { get; set; }
        public string btsid { get; set; }
        public string ECID { get; set; }
        public string eNBI { get; set; }
        public string CLID { get; set; }
        public string LONGuke { get; set; }
        public string LATIuke { get; set; }
        public string StationId { get; set; }
    }
}
*/