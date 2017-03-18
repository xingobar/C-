using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
namespace Crawler
{
    class Crawler
    {
        List<String> urlList = new List<String>();
        static void Main(string[] args)
        {
            Crawler crawler = new Crawler();
            crawler.urlList.Add("http://www.msn.com/zh-tw");
        }
        public void craw() {
            int urlIdx = 0;
            while (urlIdx < urlList.Count) {
                try
                {
                    String url = urlList[urlIdx];
                    String fileName = "data/" + toFileName(url);
                    Console.WriteLine(urlIdx + " : " + url + " file = " + fileName);
                    urlToFile(url, fileName);
                    String html = fileToText(fileName);
                    foreach (String childUrl in matches("\\shref\\s*=\\s*\"(.*?)\"", html, 1)) {
                        Console.WriteLine(childUrl);
                        urlList.Add(childUrl);
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine("[Error] : " + urlList[urlIdx] + " Fail !!!");
                    Console.WriteLine("[Error Message] : " + ex.Message);
                }
                urlIdx++;
            }
        }

        public static IEnumerable matches(String pPattern, String pText, int pGroupId) {

            Regex r = new Regex(pPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            for (Match m = r.Match(pText); m.Success; m = m.NextMatch())
                yield return m.Groups[pGroupId].Value;
        }


        public void urlToFile(String url, String file) {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, file);
        }

        public static String fileToText(String filePath) {
            StreamReader file = new StreamReader(filePath);
            String text = file.ReadToEnd();
            file.Close();
            return text;
        }

        public static String toFileName(String url) {
            String fileName = url.Replace('?', '_');
            fileName = fileName.Replace('/', '_');
            fileName = fileName.Replace('&', '_');
            fileName = fileName.Replace(':', '_');
            fileName = fileName.ToLower();
            if (!fileName.EndsWith(".htm") && !fileName.EndsWith(".html")) {
                fileName = fileName + ".html";
            }
            return fileName;
        }
    }
}
