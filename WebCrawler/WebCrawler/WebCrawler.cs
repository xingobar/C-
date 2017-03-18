using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
namespace WebCrawler
{
    class WebCrawler
    {
        static void Main(string[] args)
        {
            String text = fileToText(args[0]);
            String[] urls = text.Split('\n');
            Console.WriteLine("Downloading .....");
            for (int i = 0; i < urls.Length; i++) {

                Console.WriteLine(i + " : " + urls[i]);
                UrlToFile(urls[i], i + ".html");
            }
        }

        public static String fileToText(string filePath) {

            StreamReader file = new StreamReader(filePath);
            String text = file.ReadToEnd();
            file.Close();
            return text;

        }

        public static void UrlToFile(String url, String file) {
            WebClient webClient = new WebClient();
            webClient.DownloadFile("http://" + url, file);
  
        }
    }
}
