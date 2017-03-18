using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace HttpServer
{
    class HttpServer
    {
        static void Main(string[] args)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 80);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipep);
            socket.Listen(10);

            while (true) {
                Socket client = socket.Accept();
                IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;

                // create a new thread and then receive message
                HttpListener listener = new HttpListener(client);
                Thread thread = new Thread(new ThreadStart(listener.run));
                thread.Start();
           }
            socket.Close();
        }
    }
    public class HttpListener {

        Socket socket;

        public HttpListener(Socket s) {
            socket = s;
        }

        public void run() {
            String msg = "Hello";
            String helloMsg = @"HTTP/1.0 200 OK\nContent-Type: text/plain\nContent-Length: " + msg.Length + "\n\n" + msg;
            NetworkStream stream = new NetworkStream(socket);
            StreamReader reader = new StreamReader(stream);
            String header = "";
            while (true) {
                String line = reader.ReadLine();
                Console.WriteLine();
                if (line.Trim().Length == 0) {
                    break;
                }
                header += line + "\n";
            }
            socket.Send(Encoding.UTF8.GetBytes(helloMsg));
            socket.Close();
        }

    }
}
