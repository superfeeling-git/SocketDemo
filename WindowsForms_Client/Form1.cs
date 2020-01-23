using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsForms_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 客户端socket
        /// </summary>
        Socket client_socket;
        /// <summary>
        /// 服务端IP
        /// </summary>
        IPAddress ip;
        /// <summary>
        /// 服务器端口
        /// </summary>
        int Port = 8900;
        private void Form1_Load(object sender, EventArgs e)
        {
            ip = Dns.GetHostAddresses(Dns.GetHostName()).First(m => m.AddressFamily == AddressFamily.InterNetwork);
            //声明ippoint
            IPEndPoint point = new IPEndPoint(ip, Port);

            //声明socket
            client_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //连接服务端
            client_socket.Connect(point);

            //新启一个线程，用于随时接收服务器端的消息
            Thread thread = new Thread(() => {
                while(true)
                {
                    //使用try/catch块预防服务端关闭
                    try
                    {
                        //声明字节数组用来存储服务端消息
                        byte[] result = new byte[1024];
                        int dataleng = client_socket.Receive(result);

                        this.Invoke(new Action(() => {
                            //显示在消息框中
                            string msg_content = Encoding.Default.GetString(result, 0, dataleng);
                            ReceiveMsg.Items.Add(msg_content);

                            //输出消息日志
                            IPEndPoint source = (IPEndPoint)client_socket.RemoteEndPoint;
                            Log.Items.Add(string.Format("消息来源：{0}:{4}，消息内容：{1}，消息时间：{2}，消息长度：{3}", source.Address, msg_content, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msg_content.Length,source.Port));
                        }));
                    }
                    catch (Exception ex)
                    {
                        client_socket.Shutdown(SocketShutdown.Both);
                        client_socket.Close();
                        client_socket.Dispose();
                        Log.Items.Add(string.Format("发生异常：{0}",ex.Message));
                        break;
                    }
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client_socket.Send(Encoding.Default.GetBytes(Msg.Text.Trim()));
            Msg.Text = string.Empty;
        }
    }
}
