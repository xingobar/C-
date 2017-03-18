using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UdpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // 連接到 args[0] 參數所指定的 IP 且使用 port 5555
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(args[0]), 5555);
            // 建立 Socket , 連接到 Internet (InterNetwork) , 使用 UDP 協定的 Datagram (Dgram)
            // Args1 : InterNetwork
            // Args2 : Datagram
            // Args3 : UDP
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            // 不斷讀取鍵盤所輸入的資料
            while (true) {
                string input = Console.ReadLine(); // 讀取鍵盤輸入
                if (input == "exit") {
                    break;
                }
                // 將訊息已 UTF8 的方式編碼送出
                server.SendTo(Encoding.UTF8.GetBytes(input), ipep); 
            }
            Console.WriteLine("Stopping client");
            Console.WriteLine("Closing Connection");
            server.Close(); // 關閉連線
        }
    }
}
