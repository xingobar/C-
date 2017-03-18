using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Web;
using System.IO;
namespace WebServer
{
    class WebServer
    {
        static void Main(string[] args)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 8085);
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
        }
    }

    class HttpListener {

        String[] map ={"mpeg=video/mpeg", "mpg=video/mpeg", "wav=audio/x-wav", "jpg=image/jpeg",
"gif=image/gif", "zip=application/zip", "pdf=application/pdf", "xls=application/vnd.ms-excel",
"ppt=application/vnd.ms-powerpoint", "doc=application/msword", "htm=text/html",
"html=text/html", "css=text/plain", "vbs=text/plain", "js=text/plain", "txt=text/plain",
"java=text/plain"};

        Socket socket;
        NetworkStream stream;
        String header;
        String root = ".";

        public HttpListener(Socket s) {
            socket = s;
        }

        public void run() {

            stream = new NetworkStream(socket);
            request();
            response();
            stream.Close();
        }

        public void send(String str) {
            socket.Send(Encoding.UTF8.GetBytes(str));
        }

        public void request() {
            try
            {
                StreamReader reader = new StreamReader(stream);
                header = "";
                while (true) {
                    String line = reader.ReadLine();
                    Console.WriteLine(line);
                    if (line.Trim().Length == 0) {
                        break;
                    }
                    header += line + "\n";

                }
            }
            catch (Exception ex) {
                Console.WriteLine("Request Error !!! ");
                Console.WriteLine("[Error Message ] : " + ex.Message);
            }
        }

        public static String innerText(String pText, String beginMark, String endMark) {
            int beginStart = pText.IndexOf(beginMark);
            if (beginStart < 0) return null;
            int beginEnd = beginStart + beginMark.Length;
            int endStart = pText.IndexOf(endMark, beginEnd);
            if (endStart < 0) return null;
            return pText.Substring(beginStart, endStart - beginEnd); 
        }

        public void response() {

            try
            {
                Console.WriteLine("------- Response ----------");
                String path = innerText(header, "GET", "HTTP/").Trim(); // 取得檔案路徑 (GET)
                // http://stackoverflow.com/questions/2405182/httputility-does-not-exist-in-the-current-context
                HttpUtility.UrlDecode(path);
                String fullPath = root + path;
                FileInfo info = new FileInfo(fullPath);
                if (!info.Exists) {
                    throw new Exception("File not found");
                }
                send("HTTP/1.0 200 OK\n");
                send("Content-Type:" + type(fullPath) + "\n");
                send("Content-Length:" + info.Length + "\n");
                send("\n");
                byte[] buffer = new byte[4096];
                FileStream fileStream = File.OpenRead(fullPath);
                while (true) {
                    int len = fileStream.Read(buffer, 0, buffer.Length);
                    if (len < buffer.Length) {
                        break;
                    }
                }
                fileStream.Close();
            }
            catch {
                try
                {
                    send("HTTP/1.0 404 Error\n");
                    send("\n");
                }
                catch(Exception ex){
                    Console.WriteLine("Send Error Msg Fail !!! ");
                    Console.WriteLine("[Error Message ] " + ex.Message);
                }
            }

        }

        /// 比對資料的型別 
        String type(String path) {

            String type = "*/*";
            path = path.ToLower();
            for (int i = 0; i < map.Length; i++) {
                String[] tokens = map[i].Split('=');
                String ext = tokens[0], mime = tokens[1];
                if (path.EndsWith("." + ext)) type = mime;
            }
            return type;

        }
    }
}
