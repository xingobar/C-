using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TcpClient
{
    class TcpClient
    {
        static void Main(string[] args)
        {
            /// 連接至 port 5555
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(args[0]), 5555);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Connect(ipep);

            //byte[] data = new byte[1024];
            //int recv = server.Receive(data);
            //Console.WriteLine("[Received Data From Server ] : " + Encoding.UTF8.GetString(data, 0, recv));
            while (true) {
                string input = Console.ReadLine(); // 使用者輸入
                if (input == "exit") {
                    break;
                }
                byte[] data = Encoding.UTF8.GetBytes(input); // 將資料轉為 UTF8 的格式
                server.Send(data);
            }
            Console.WriteLine("Disconnecting from server ...");
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
    }
}
