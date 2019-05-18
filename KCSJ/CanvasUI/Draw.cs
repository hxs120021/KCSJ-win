using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Collections;
using System.Windows.Shapes;
using System.Windows.Media;
using KCSJ.Data;
namespace KCSJ.CanvasUI
{
    public class Draw
    {
        Canvas[] canvas;
        TextBlock[] blocks;
        Queue queue;
        //int[] hrs = new int[11];
        //float[] spo2s = new float[11];
        //float[] temps = new float[11];
        Port oldHrPort = new Port(5, 89);
        Port oldSpo2Port = new Port(5, 89);
        Port oldTempPort = new Port(5, 89);
        public Draw(Canvas[] canvas,TextBlock[] blocks ,Queue queue)
        {
            this.canvas = canvas;
            this.queue = queue;
            this.blocks = blocks;
        }

        public int DrawGraph(int i)
        {
            

            //for (int i = 0; ; i++)
            //{

                string data = "";
                //if(queue.Count != 0)
                data= queue.Dequeue() as string;
                //else
                //{
                //    break;
                //    //while (queue.Count == 0)
                //    //    Thread.Sleep(1000);
                //    //data = queue.Dequeue() as string;
                //}
                string[] strsp = data.Split('^');

                int hr = Convert.ToInt32(strsp[0]);
                double spo2 = Convert.ToDouble(strsp[1]);
                double temp = Convert.ToDouble(strsp[2]);

                blocks[0].Text = hr.ToString();
                blocks[1].Text = spo2.ToString();
                blocks[2].Text = temp.ToString();

                Port newHrPort = new Port(i * 10 + 5, GetHrPx(hr));
                Port newSpo2Port = new Port(i * 10 + 5, GetSpo2Px(spo2));
                Port newTempPort = new Port(i * 10 + 5, GetTempPx(temp));

                DrawD(oldHrPort, newHrPort, 0);
                DrawD(oldSpo2Port, newSpo2Port, 1);
                DrawD(oldTempPort, newTempPort, 2);

                oldHrPort = newHrPort;
                oldSpo2Port = newSpo2Port;
                oldTempPort = newTempPort;

                if(i == 50)
                {
                    oldHrPort.Clear();
                    canvas[0].Children.Clear();
                    oldSpo2Port.Clear();
                    canvas[1].Children.Clear();
                    oldTempPort.Clear();
                    canvas[2].Children.Clear();
                    return 0;
                }
            return i + 1;
            //}
        }
        
        private Line GetLine()
        {
            Line line = new Line();
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 3;
            return line;
        }

        private void FullLine(Line line, Port startPort, Port endPort)
        {
            line.X1 = startPort.X;
            line.Y1 = startPort.Y;
            line.X2 = endPort.X;
            line.Y2 = endPort.Y;
        }

        private void DrawD(Port startPort, Port endPort, int index)
        {
            Line line = GetLine();
            FullLine(line, startPort, endPort);
            canvas[index].Children.Add(line);
        }

        private int GetHrPx(int hr)
        {
            float px = 0;
            px = 90 - ((float)3 / 5) * hr;
            return (int)px;
        }

        private int GetSpo2Px(double Spo2)
        {
            double px = 0;
            px = 3.6 * (100 - Spo2);
            return (int)px;
        }

        private int GetTempPx(double temp)
        {
            double px = 0;
            px = 4.5 * (52 - temp);
            return (int)px;
        }
    }
}
