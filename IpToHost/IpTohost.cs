using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace IpToHost
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ipAddr = IPAddress.Parse(args[0]);

            // 透過 DNS 找尋 IP位址相對應之主機名稱
            IPHostEntry remoteHostEntry = Dns.GetHostEntry(ipAddr);
            Console.WriteLine("host of ip " + ipAddr + " is " + remoteHostEntry);

            Console.Read();
        }
    }
}
