using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Console_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("客户端窗口");
            IPAddress ip = Dns.GetHostAddresses(Dns.GetHostName()).First(m => m.AddressFamily == AddressFamily.InterNetwork);
            Socket socket_clie = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip_point = new IPEndPoint(ip, 6900);
            socket_clie.Connect(ip_point);

            Thread thread = new Thread(() => {
                while(true)
                {
                    byte[] result = new byte[1024];
                    int datalength = socket_clie.Receive(result);
                    Console.WriteLine(Encoding.Default.GetString(result, 0, datalength));
                }
            });
            thread.Start();

            ThreadPool.QueueUserWorkItem(m => {
                while(true)
                { 
                    string msg = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(msg))
                        socket_clie.Send(Encoding.Default.GetBytes(msg));
                }
            });
        }
    }
}
