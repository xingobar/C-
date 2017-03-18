using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IPAddressTest
{
    class Program
    { 
        static void Main(string[] args)
        {
            // 建立一個 IP 位址 (IP Address)
            IPAddress ipAddr = IPAddress.Parse("210.59.154.30");
            Console.WriteLine("IPAddress = " + ipAddr);

            // 建立一個 IP 終端 (IPEndPoint = IPAddress + Port)
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 80);
            Console.WriteLine("IPEndPoint = " + ipEndPoint);

            // 將IPEndPoint序列化為SocketAddress
            SocketAddress socketAddr = ipEndPoint.Serialize();
            Console.WriteLine("socketAddr = " + socketAddr);

            Console.Read();

        }
    }
}
