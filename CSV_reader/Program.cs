/*using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_reader
{
    class Program
    {
        static void Main(string[] args)
        {

            string filePath = @"F:\_BZ\BTSy\btsearch.csv";

            // Check if file exists.
            if (File.Exists(filePath))
            {
                // Read column headers from file
                CsvReader csv = new CsvReader(File.OpenText(filePath));
                csv.Read();
                csv.ReadHeader();

                List<string> headers = csv.Context.HeaderRecord.ToList();

                // Read csv into datatable
                System.Data.DataTable dataTable = new System.Data.DataTable();

                foreach (string header in headers)
                {
                    dataTable.Columns.Add(new System.Data.DataColumn(header));
                }

                // Check all required columns are present
                if (!headers.Exists(x => x == "siec_id"))
                {
                    throw new ArgumentException("siec_id field not present in input file.");
                }
                else if (!headers.Exists(x => x == "wojewodztwo_id"))
                {
                    throw new ArgumentException("wojewodztwo_id field not present in input file.");
                }
                else if (!headers.Exists(x => x == "miejscowosc"))
                {
                    throw new ArgumentException("miejscowosc field not present in input file.");
                }
                else if (!headers.Exists(x => x == "lokalizacja"))
                {
                    throw new ArgumentException("lokalizacja field not present in input file.");
                }
                else if (!headers.Exists(x => x == "standard"))
                {
                    throw new ArgumentException("standard field not present in input file.");
                }
                else if (!headers.Exists(x => x == "pasmo"))
                {
                    throw new ArgumentException("pasmo field not present in input file.");
                }
                else if (!headers.Exists(x => x == "lac"))
                {
                    throw new ArgumentException("lac field not present in input file.");
                }
                else if (!headers.Exists(x => x == "btsid"))
                {
                    throw new ArgumentException("btsid field not present in input file.");
                }
                else if (!headers.Exists(x => x == "ECID"))
                {
                    throw new ArgumentException("ECID field not present in input file.");
                }
                else if (!headers.Exists(x => x == "eNBI"))
                {
                    throw new ArgumentException("eNBI field not present in input file.");
                }
                else if (!headers.Exists(x => x == "CLID"))
                {
                    throw new ArgumentException("CLID field not present in input file.");
                }
                else if (!headers.Exists(x => x == "LONGuke"))
                {
                    throw new ArgumentException("LONGuke field not present in input file.");
                }
                else if (!headers.Exists(x => x == "LATIuke"))
                {
                    throw new ArgumentException("LATIuke field not present in input file.");
                }
                else if (!headers.Exists(x => x == "StationId"))
                {
                    throw new ArgumentException("StationId field not present in input file.");
                }

                // Import csv
                while (csv.Read())
                {
                    System.Data.DataRow row = dataTable.NewRow();

                    foreach (System.Data.DataColumn column in dataTable.Columns)
                    {
                        row[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);
                    }

                    dataTable.Rows.Add(row);
                }
               
                /* Make sure all required columns are populated
                if (dataTable.Select("ua_channel = '' OR ua_channel = null").Count() > 0)
                {
                    throw new ArgumentException("Output contains null ua_channel values.");
                }

                if (dataTable.Select("ua_device_type = '' OR ua_device_type = null").Count() > 0)
                {
                    throw new ArgumentException("Output contains null ua_device_type values.");
                }

                if (dataTable.Select("message_type = '' OR message_type = null OR message_type not in ('push', 'message centre')").Count() > 0)
                {
                    throw new ArgumentException("Output contains null or invalid message_type values.");
                }
            }

        }
    }
}
    */