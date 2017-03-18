using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace DnsTest
{   // 使用DNS查詢IP
    class Program
    {
        static void Main(string[] args)
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(args[0]);
            // 主機可能有一個以上的 Alias
            string[] aliasList = hostEntry.Aliases;
            for (int i = 0; i < aliasList.Length; i++) {
                Console.WriteLine("Alias " + i + " : " + aliasList[i]);
            }

            // 主機可能有一個以上的 IP Address
            IPAddress[] addrList = hostEntry.AddressList;
            for (int i = 0; i < addrList.Length; i++) {
                Console.WriteLine("Address " + i + " : " + addrList[i]);
            }
            Console.Read();
        }
    }
}
