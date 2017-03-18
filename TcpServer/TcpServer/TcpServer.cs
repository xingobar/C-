using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
namespace TcpServer
{
    class TcpServer
    {
        static void Main(string[] args)
        {
            // 監聽 port 5555
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 5555);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipep);
            socket.Listen(10);

            while (true) {
                Socket client = socket.Accept();
               // socket.Send(Encoding.UTF8.GetBytes("Welcome !! "));
                IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;
                Console.WriteLine("Client End Point : " + clientep);
                // create a new thread and then receive message 
                TcpListener listener = new TcpListener(client);
                Thread thread = new Thread(new ThreadStart(listener.run));
                thread.Start();
                
            }
            socket.Close();
        }
    }

    public class TcpListener{
        Socket socket;

        public TcpListener(Socket s) { socket = s; }

        public void run() {

            try
            {
                while (true) {
                    byte[] data = new byte[1024];
                    int recv = socket.Receive(data);
                    if (recv == 0) break;
                    Console.WriteLine(Encoding.UTF8.GetString(data, 0, recv));

                }

            }
            catch (Exception ex) {
                Console.WriteLine("Client " + socket.RemoteEndPoint + " Error : close ");
                Console.WriteLine("[Error Message ] : " + ex.Message);
            }
        }
    }
}
