using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Data;

namespace CSV_reader
{
    class Class3
    {
        static void Main(string[] args)
        {

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
                    
                    
                    dt.Columns.Add(new DataColumn("siec_id", typeof(String)));
                    dt.Columns.Add(new DataColumn("miejscowosc", typeof(String)));
                    dt.Columns.Add(new DataColumn("standard", typeof(String)));
                    dt.Columns.Add(new DataColumn("pasmo", typeof(String)));
                    dt.Columns.Add(new DataColumn("ECID", typeof(String)));
                    dt.Columns.Add(new DataColumn("eNBI", typeof(String)));
                    dt.Columns.Add(new DataColumn("CLID", typeof(String)));
                    dt.Columns.Add(new DataColumn("LONGuke", typeof(String)));
                    dt.Columns.Add(new DataColumn("LATIuke", typeof(String)));
                    dt.Columns.Add(new DataColumn("StationId", typeof(String)));

                    while (csv.Read())
                    {
                        var row = dt.NewRow();
                        foreach (DataColumn column in dt.Columns)
                        {
                            row[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);
                        }
                        dt.Rows.Add(row);
                    }

                    
                    {
                        string data = string.Empty;
                        StringBuilder sb = new StringBuilder();

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
                            }

                            data = sb.ToString();
                            Console.WriteLine(sb);
                        }
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
