using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace ChatBox
{
    class ChatBox
    {
        int port = 5555;
        static void Main(string[] args)
        {
            ChatBox chatBox = new ChatBox();
            if (args.Length == 0)
            {
                chatBox.ServerMain();
            }
            else {
                chatBox.ClientMain(args[0]);
            }
        }

        public void ServerMain() {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipep);
            socket.Listen(10);
            Socket client = socket.Accept();
            new TcpListener(client); // create a new thread and then receive message
            socket.Close();

        }

        public void ClientMain(String ip) {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), port);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Connect(ipep);
            new TcpListener(server);
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

    }
    public class TcpListener {

        Socket socket;
        Thread inThread, outThread;
        NetworkStream stream;
        StreamReader reader;
        StreamWriter writer;

        public TcpListener(Socket s) {

            socket = s;
            stream = new NetworkStream(s);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            inThread = new Thread(new ThreadStart(inLoop)); /// 讀取輸入
            inThread.Start();
            outThread = new Thread(new ThreadStart(outLoop)); /// 傳送資料
            outThread.Start();
            inThread.Join();
        }

        public void inLoop() {

            while (true) {
                
                String line = reader.ReadLine();
                Console.WriteLine("[Received] : " + line);

            }
        }

        public void outLoop() {

            while (true) {

                String line = Console.ReadLine();
                writer.WriteLine(line);
                writer.Flush();
            }
        }

    }
}
