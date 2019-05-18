using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KCSJ.NetSocket;
namespace KCSJ.Dod
{
    public class DoAlrm
    {
        public void WaitAlrm()
        {
            RecvMsg recv = new RecvMsg(9970, ()=> { Console.WriteLine("in alrm"); });
            string alrmMsg = recv.Recv();
            //Sound();
            MessageBox.Show(string.Format("{0} error!", alrmMsg), "ERROR");
        }

        private void Sound()
        {
            SoundPlayer player = new SoundPlayer("wav");
            player.Load();
            player.Play();
        }
    }
}
