using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 
 * 剖析網址URL
 * */
namespace UrlParseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 由於 DOS 的命令列會以 & 符號做命令分隔字元，因此、若以指令模式下，
            // 網址中的 & 之後會被視為是下一個指令
            System.Uri URL = new System.Uri("http://findbook.tw/search?keyword_type=keyword&t=xxx");

            Console.WriteLine("AbsolutePath : " + URL.AbsolutePath);
            Console.WriteLine("AbsoluteUri : " + URL.AbsoluteUri);
            Console.WriteLine("Authority : " + URL.Authority);
            Console.WriteLine("Host : " + URL.Host);
            Console.WriteLine("Port : " + URL.Port);
            Console.WriteLine("LocalPath : " + URL.LocalPath);
            Console.WriteLine("IsDeafultPort : " + URL.IsDefaultPort);
            Console.WriteLine("IsFile : " + URL.IsFile);
            Console.WriteLine("PathAndQuery: " + URL.PathAndQuery);
            Console.WriteLine("Query: " + URL.Query);
            Console.WriteLine("Scheme: " + URL.Scheme);
            Console.WriteLine("UserEscaped: " + URL.UserEscaped);

            Console.Read();
        }
    }
}
