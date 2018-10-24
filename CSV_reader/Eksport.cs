using System;
using System.IO;
using System.Text;
using System.Data;

namespace CSV_reader
{
    class Eksport
    {

        public DataTable Eksport_pasmo(string stan, string pasm, DataTable base_dt)
        {
            string eksp;
            eksp = stan + pasm;

            DataTable eksp_dt = base_dt.Select("standard = 'LTE' AND pasmo = '1800' AND (ECID <> '' OR eNBI <> '' OR CLID <> '')").CopyToDataTable();

            //print *optional
            /*{
                string data = string.Empty;
                StringBuilder sb = new StringBuilder();
                int cnt = 0;

                if (null != dt_lte18 && null != dt_lte18.Rows)
                {
                    foreach (DataRow dataRow in dt_lte18.Rows)
                    {
                        foreach (var item in dataRow.ItemArray)
                        {
                            sb.Append(item);
                            sb.Append(',');
                        }
                        sb.AppendLine();
                        cnt++;
                    }

                    data = sb.ToString();
                }
            }*/

            return eksp_dt;
        }
    }
}
