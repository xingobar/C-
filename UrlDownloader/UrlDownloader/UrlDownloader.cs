using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UrlDownloader
{
    class UrlDownloader
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args[0]);
            UrlToFile(args[0], args[1]);
        }
        public static void UrlToFile(String url, String file) {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, file);
        }
    }
}
