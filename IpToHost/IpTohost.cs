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

            // �z�L DNS ��M IP��}�۹������D���W��
            IPHostEntry remoteHostEntry = Dns.GetHostEntry(ipAddr);
            Console.WriteLine("host of ip " + ipAddr + " is " + remoteHostEntry);

            Console.Read();
        }
    }
}
