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

namespace WindowsForms_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 服务器Socket
        /// </summary>
        Socket server_socket;
        /// <summary>
        /// 本地IP
        /// </summary>
        IPAddress ip;
        /// <summary>
        //  端口
        /// </summary>
        int Port = 8900;
        /// <summary>
        /// 用于存储客户端socket列表
        /// </summary>
        Dictionary<string, Socket> soc_list = new Dictionary<string, Socket>();
        private void Form1_Load(object sender, EventArgs e)
        {
            //获取本地IP地址
            ip = Dns.GetHostAddresses(Dns.GetHostName()).First(m => m.AddressFamily == AddressFamily.InterNetwork);

            //声明socket
            server_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //绑定本地IP
            IPEndPoint ip_point = new IPEndPoint(ip, Port);
            server_socket.Bind(ip_point);

            //启动监听，此时socket处于阻塞状态
            server_socket.Listen(10);

            //开启一个线程，用于随时接收新的客户端连接
            Thread thread = new Thread(() => {
                while(true)
                {
                    Socket client = server_socket.Accept();
                    IPEndPoint point = (IPEndPoint)client.RemoteEndPoint;

                    //将新的socket加入字典
                    soc_list.Add(point.Address.ToString(), client);
                    //显示在客户端列表中
                    this.Invoke(new Action(() => {
                        ClientLIst.Items.Add(point.Address.ToString());
                    }));

                    //开启一个新的线程，用于随时接收客户端发来的消息
                    //需要传入当前连接的socket对象
                    Thread c_thread = new Thread(m =>
                    {
                        while (true)
                        {
                            Socket curr_socket = (Socket)m;
                            try
                            {
                                //声明一个字节数组，用于存储客户端发送的消息
                                byte[] result = new byte[1024];

                                //接收消息
                                int dataleng = curr_socket.Receive(result);

                                this.Invoke(new Action(() =>
                                {
                                    //显示在消息框中
                                    string msg_content = Encoding.Default.GetString(result, 0, dataleng);
                                    ReceiveMsg.Items.Add(msg_content);

                                    //输出消息日志
                                    IPEndPoint source = (IPEndPoint)curr_socket.RemoteEndPoint;
                                    Log.Items.Add(string.Format("消息来源：{0}:{4}，消息内容：{1}，消息时间：{2}，消息长度：{3}", source.Address, msg_content, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msg_content.Length,source.Port));
                                }));
                            }
                            catch (Exception ex)
                            {
                                curr_socket.Shutdown(SocketShutdown.Both);
                                curr_socket.Close();
                                curr_socket.Dispose();
                                Log.Items.Add(string.Format("发生异常：{0}", ex.Message));
                                break;
                            }
                        }
                    });
                    c_thread.IsBackground = true;
                    c_thread.Start(client);
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //先找到当前要发送的目标客户端
            if (ClientLIst.SelectedItems.Count <= 0)
            { 
                MessageBox.Show("请选择要发送到的目标客户地址");
                return;
            }
            string target = ClientLIst.SelectedItems[0].Text;

            //获取目标socket
            Socket serv_socket = soc_list.First(m => m.Key == target).Value;
            //执行发送
            serv_socket.Send(Encoding.Default.GetBytes(Msg.Text.Trim()));
            Msg.Text = string.Empty;
        }
    }
}
