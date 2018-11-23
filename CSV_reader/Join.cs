using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using ExcelDataReader;

namespace CSV_reader
{
    class Join
    {
        public static void JoinDTs(DataTable dt1, DataTable dt2)
        {
            Console.WriteLine("Begin join");

            var results = from table1 in dt1.AsEnumerable()
                          join table2 in dt2.AsEnumerable()
                          on (string)table1["BtsID"] equals (string)table2["StationID"]
                          select new
                          {
                              ID = (string)table1["BtsID"],
                              ColX = (int)table1["name"]
                          };

            Console.WriteLine("End join");
        }
    }
}
