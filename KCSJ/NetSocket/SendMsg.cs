using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
namespace KCSJ.NetSocket
{
    class SendMsg
    {
        string ip = "127.0.0.1";
        int port = 9966;
        public SendMsg(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }

        public string Send(string msg)
        {
            string getmsg = "";
            IPAddress ipadd = IPAddress.Parse(ip);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEndPoint = new IPEndPoint(ipadd, port);
            clientSocket.Connect(iPEndPoint);

            byte[] message = Encoding.UTF8.GetBytes(msg);
            byte[] getmessage = new byte[1024];
            try
            {
                clientSocket.Send(message);
                int len = clientSocket.Receive(getmessage);
                getmsg = Encoding.UTF8.GetString(getmessage);
            } catch(Exception e)
            {
                clientSocket.Close();
                Console.WriteLine(e.ToString());
            }
            clientSocket.Close();
            return getmsg;
        }
    }
}
