using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KCSJ.Data;
using KCSJ.NetSocket;
using KCSJ.CanvasUI;
using KCSJ.Dod;
using System.Collections;
namespace KCSJ
{
    /// <summary>
    /// Graph.xaml 的交互逻辑
    /// </summary>
    public partial class Graph : Window
    {
        Queue queue;
        Equipment equipment;
        int index = 0;
        Draw draw;
        public Graph(Equipment equipment)
        {
            InitializeComponent();
            this.equipment = equipment;
            FullEqu(equipment);
            queue = Queue.Synchronized(new Queue());
            TestData();
            draw = new Draw(
                    new Canvas[] { this.rhCan, this.spo2Can, this.tempCan },
                    new TextBlock[] { this.rhBlock, this.spo2Block, this.tempBlock },
                    queue
                    );
            //index = 0;
        }

        public void FullEqu(Equipment equipment)
        {
            //Task task = new Task(() =>
            //{
                this.Dispatcher.Invoke(new Action(() =>
                {
                    bidBlock.Text = equipment.Bid;
                    sidBlock.Text = equipment.Sid;
                    nameBlock.Text = equipment.Name;
                    sexBlock.Text = equipment.Sex;
                    ageBlock.Text = equipment.Sex;
                }));
            //});
            //task.Start();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Start();
        }

        private void Start()
        {
            Task ListenCheckData = new Task(() =>
            {
                RecvMsg recv = new RecvMsg(9966, Drawx);
                recv.Recv(queue);
            });

            //Task DrawUI = new Task(() =>
            //{
            //    Dispatcher.Invoke(new Action(() =>
            //    {
            //        Draw draw = new Draw(
            //            new Canvas[] { this.rhCan, this.spo2Can, this.tempCan },
            //            new TextBlock[] { this.rhBlock, this.spo2Block, this.tempBlock },
            //            queue
            //                );
            //        draw.DrawGraph();
            //    }));
            //});

            Task ListenAlrm = new Task(() =>
            {
                DoAlrm doAlrm = new DoAlrm();
                doAlrm.WaitAlrm();
            });

            ListenCheckData.Start();
            //DrawUI.Start();
            ListenAlrm.Start();
        }

        public void Drawx()
        {
            this.Dispatcher.Invoke(() =>
            {
                
                index = draw.DrawGraph(index);
            });
        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            this.Close();
        }

        public static void DDD()
        {
            foreach(Window w in Application.Current.Windows)
            {
                Console.WriteLine(w.Title);
            }
        }

        private void TestData()
        {
            queue.Enqueue("80^90^36");
            queue.Enqueue("89^99^37");
            queue.Enqueue("90^98^37.8");
            queue.Enqueue("85^97^37.6");
            queue.Enqueue("88^99^37.2");
            queue.Enqueue("80^90^36");
            queue.Enqueue("89^99^37");
            queue.Enqueue("90^98^37.8");
            queue.Enqueue("85^97^37.6");
            queue.Enqueue("88^99^37.2");
            queue.Enqueue("80^90^36");
            queue.Enqueue("100^99^37");
            queue.Enqueue("96^98^37.8");
            queue.Enqueue("85^97^37.6");
            queue.Enqueue("88^94^37.2");
            queue.Enqueue("85^93^36");
            queue.Enqueue("79^92^37");
            queue.Enqueue("98^98^37.8");
            queue.Enqueue("75^97^37.6");
            queue.Enqueue("81^96^37.2");
            queue.Enqueue("89^99^37");
            queue.Enqueue("90^98^37.8");
            queue.Enqueue("85^97^37.6");
            queue.Enqueue("88^99^37.2");
            queue.Enqueue("80^90^36");
            queue.Enqueue("100^99^37");
            queue.Enqueue("96^98^37.8");
            queue.Enqueue("85^97^37.6");
        }
    }
}
