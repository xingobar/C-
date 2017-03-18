using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UdpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // 開啟伺服器端的 5555 port , 用來接收任何傳送到本機的訊息
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 5555);
            // 建立接收的 Socket , 並使用 Udp 的 Datagram 方式接收
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            // 綁定 Socket (socket) 與 IPEndPoint (ipep) , 讓 Socket 接收 5555 port 的訊息
            socket.Bind(ipep);
            Console.WriteLine("Waiting for a client .... ");
            // 建立 Remote 物件以便取得封包的接收來源的 EndPoint 物件
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)(sender);
            // 不斷接收訊息並顯示到螢幕上
            while (true) {
                byte[] data = new byte[1024]; // 設定接收緩衝區的陣列變數
                int recv = socket.ReceiveFrom(data, ref Remote); // 接收對方傳來的封包
                // 將封包以 UTF8 的格式解碼為字串,並顯示到螢幕上
                Console.WriteLine(Encoding.UTF8.GetString(data,0,recv));
            }
        }
    }
}
