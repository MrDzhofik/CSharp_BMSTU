using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;



namespace DZ2
{
   
    class HttpServer
    {
        private readonly TcpListener _listener;
        private readonly bool _useThreadPool;

        public HttpServer(int port, bool useThreadPool)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _useThreadPool = useThreadPool;
        }

        private static void ProcessClient(object obj)
        {
            TcpClient client = obj as TcpClient;

            if (client == null)
            {
                return;
            }

            using (NetworkStream stream = client.GetStream())
            {
                byte[] request = new byte[1024];
                int bytesRead = stream.Read(request, 0, request.Length);
                string message = Encoding.UTF8.GetString(request, 0, bytesRead);
                Console.WriteLine("Received: " + message);

                string response = "HTTP/1.1 200 OK\r\n" +
                    "Content-Type: text/html; charset=UTF-8\r\n" +
                    "Connection: close\r\n\r\n" +

                    "<html><body><h1>Messi, Ronaldo!</h1></body></html>";
                byte[] buffer = Encoding.UTF8.GetBytes(response);
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
            client.Close();
        }

        public void Start()
        {
            _listener.Start();
            Console.WriteLine("Server started on port 49208");

            while (true)
            {
                TcpClient client = _listener.AcceptTcpClient();

                if (_useThreadPool)
                {
                    ThreadPool.QueueUserWorkItem(ProcessClient, client);
                }
                else
                {
                    ProcessClient(client);
                }
            }
        }
    }

       
        internal class Program
    {
        static void Main(string[] args)
        {
            var server = new HttpServer(49208, true);
            server.Start();
        }
    }
}
