/*using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace CSV_reader
{
    class Class2
    {
        static void Main(string[] args)
        {

            var textToParse = @"SupplierSku,CatIds,StockStatus,Active
%ADA-BB-124%|4,5,1|%AV%|1
%XAS-E4-S11%|97,41,65|%OS%|0";

            string supplierSku;
            string stockStatus;

            using (var stringReader = new StringReader(textToParse))
            {
                using (var reader = new CsvReader(stringReader))
                {
                    reader.Configuration.Delimiter = ",";
                    reader.Configuration.HasHeaderRecord = true; // If there is no header, set to false.
                    reader.Read();
                    reader.ReadHeader();

                    while (reader.Read())
                    {
                        supplierSku = reader.GetField("SupplierSku"); // Or reader.GetField(0)
                        //supplierSku = reader.GetField(0);
                        stockStatus = reader.GetField("StockStatus"); // Or reader.GetField(2)
                        //stockStatus = reader.GetField(2);

                        Console.WriteLine($"SKU: {supplierSku}; Status: {stockStatus}");

                        Console.ReadKey();
                    }
                }
            }

        }
    }
}
*/