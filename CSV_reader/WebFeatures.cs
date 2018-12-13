using System;
using System.Net.Http;
using System.Xml;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

namespace CSV_reader
{
    public class WebFeatures
    {

        public static List<string> GetUKE()
        {
            List<string> linkx = new List<string>();
            string website = @"https://bip.uke.gov.pl/pozwolenia-radiowe/wykaz-pozwolen-radiowych-tresci/stacje-gsm-umts-lte-oraz-cdma,12.html";
            WebClient wc = new WebClient();
            string str = wc.DownloadString(website);
            foreach (string li in LinkFinder.Find(str))
            {
                //Console.WriteLine(li);
                linkx.Add(li);
            }
            //Console.WriteLine(string.Join("\n", linkx));
            
            return linkx;
        }


        public static void DLu(string dir, string url)
        {
            int cnt = 0;
            int nmb = 0;
            while(cnt < 11)
            {
                int iof = url.IndexOf('/', nmb);
                nmb = iof+1;
                cnt++;
                //Console.WriteLine(nmb);
            }

            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new Uri(url),
                   // Param2 = Path to save
                   dir + url.Substring(nmb));
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                //Console.WriteLine("DLed " + url.Substring(nmb));
            }
        }

        public static string DLb(string dir)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new Uri("http://www.btsearch.pl/export.php"),
                                 // Param2 = Path to save
                   dir + "btsearch.csv");
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                Console.WriteLine("DLed BTS");
            }
            return dir + "btsearch.csv";
        }

        private static void Wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        static class LinkFinder
        {
            public static List<string> Find(string file)
            {
                List<string> list = new List<string>();

                // 1.
                // Find all matches in file.
                MatchCollection m1 = Regex.Matches(file, @"(<a.*?>.*?</a>)",
                    RegexOptions.Singleline);

                // 2.
                // Loop over each match.
                foreach (Match m in m1)
                {
                    string value = m.Groups[1].Value;
                    string i = "";
                    string j = "";

                    // 3.
                    // Get href attribute.
                    Match m2 = Regex.Match(value, @"href=\""(.*?)\""", RegexOptions.Singleline);
                    if (m2.Success)
                    {
                        i = m2.Groups[1].Value;
                        Match m3 = Regex.Match(i, @".+download.+", RegexOptions.Singleline);
                        if (m3.Success)
                        {
                            j = m3.Groups[0].Value;
                        }
                    }

                    if (j.Length > 0)
                    {
                        j = "https://bip.uke.gov.pl" + j;
                        list.Add(j);
                    }
                }
                return list;
            }
        }
    }
}
