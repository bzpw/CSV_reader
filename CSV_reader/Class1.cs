/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Data; 


namespace CSV_reader
{
    class Class1
    {

        static void Main(string[] args)
        {

            /*var textToParse = @"id;siec_id;wojewodztwo_id;miejscowosc;lokalizacja;standard;pasmo;lac;btsid;cid1;cid2;cid3;cid4;cid5;cid6;cid7;cid8;cid9;cid0;ECID;eNBI;CLID;uwagi;LONGuke;LATIuke;aktualizacja;StationId;RNC;carrier
1;Play;Podlaskie;Sejny;ul. Powstańców Sejneńskich - maszt własny;GSM;1800;1199;100;;;;;5;6;7;;;;;;;;23E2137;54N0616;2017-08-27;SEJ4401;;
2;Orange;Lubelskie;Abramów;maszt Plusa;GSM;900;58607;1565;1;2;;;;;;;;0;;;;NetWorkS!;22E1809;51N2749;2016-04-10;5263;;";

            var fileToParse = @"F:\_BZ\BTSy\btsearch.csv";

            string siec_id;
            string miejscowosc;
            string standard;
            string pasmo;
            string ECID;
            string eNBI;
            string CLID;
            string LONGuke;
            string LATIuke;
            string StationId;

            using (var stringReader = new StreamReader(fileToParse))
            {
                using (var reader = new CsvReader(stringReader))
                {
                    DataTable dt = new DataTable("BTSearch");
                    reader.Configuration.Delimiter = ";";
                    reader.Configuration.HasHeaderRecord = true; // If there is no header, set to false.
                    reader.Read();
                    reader.ReadHeader();

                    /*while (reader.Read())
                    {
                        siec_id = reader.GetField("siec_id"); // Or reader.GetField(0)
                        miejscowosc = reader.GetField("miejscowosc");
                        standard = reader.GetField("standard");
                        pasmo = reader.GetField("pasmo");
                        ECID = reader.GetField("ECID");
                        eNBI = reader.GetField("eNBI");
                        CLID = reader.GetField("CLID");
                        LONGuke = reader.GetField("LONGuke");
                        LATIuke = reader.GetField("LATIuke");
                        StationId = reader.GetField("StationId");


                        /*Console.WriteLine($@"siec_id: {siec_id}; miejscowosc: {miejscowosc}; standard: {standard};" +
                            $" pasmo: {pasmo}; ECID: {ECID}; eNBI: {eNBI}; CLID: {CLID}; " +
                            $"LONGuke: {LONGuke}; LATIuke: {LATIuke}; StationId: {StationId};");

                    //}
                //Console.ReadKey();

                    while (reader.Read())
                    {
                        var row = dt.NewRow();
                        foreach (DataColumn column in dt.Columns)
                        {
                            row[column.ColumnName] = reader.GetField(column.DataType, column.ColumnName);
                        }
                        dt.Rows.Add(row);
                    }

            }
            }

            


        }

    }
}*/
