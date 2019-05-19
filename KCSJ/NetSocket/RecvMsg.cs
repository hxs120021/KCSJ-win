using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Windows;
using KCSJ.Dod;
namespace KCSJ.NetSocket
{

    delegate void FFunc();
    class RecvMsg
    {
        //string ip = "127.0.0.1";
        int port = 9988;
        FFunc func;
        public RecvMsg(int port, FFunc func)
        {
            //this.ip = ip;
            this.port = port;
            this.func = func;
        }

        public string Recv()
        {
            IPAddress ipaddr = IPAddress.Any;
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEndPoint = new IPEndPoint(ipaddr, port);
            server.Bind(iPEndPoint);
            server.Listen(10);
            Socket s = server.Accept();
            byte[] recvmsg = new byte[1024];
            s.Receive(recvmsg);
            string res = Encoding.UTF8.GetString(recvmsg);
            s.Close();
            server.Close();
            return res;
        }

        public void Recv(Queue queue)
        {
            IPAddress ipaddr = IPAddress.Any;
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEndPoint = new IPEndPoint(ipaddr, port);
            server.Bind(iPEndPoint);
            server.Listen(10);
            //while (true)
            //{
            Socket s = server.Accept();
                //Task task = new Task(() =>
                //{
                //    Socket sc = s;
            while (true)
            {
                byte[] recvmsg = new byte[1024];
                Console.WriteLine("in recv func");
                try
                {
                    s.Receive(recvmsg);
                    string data = Encoding.UTF8.GetString(recvmsg);
                    Console.WriteLine(data);
                    queue.Enqueue(data);
                    //执行委托通知UI该绘制了
                    //CanvasUI();
                    func();
                    WriteLog.WriteL(DataTime.GetTime() + data);
                    s.Send(Encoding.UTF8.GetBytes("ok"));
                }catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                    break;
                }
            }
                    
                //});
                //task.Start();
            //}
        }

        private void CanvasUI()
        {
            //Graph w = Application.Current.Windows[1] as Graph ;
            //w.Drawx();
            foreach(Window w in Application.Current.Windows)
            {
                Console.WriteLine(w.Title);
            }
        }
    }
}
