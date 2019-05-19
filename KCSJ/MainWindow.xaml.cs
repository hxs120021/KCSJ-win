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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KCSJ.NetSocket;
using KCSJ.Data;
using KCSJ.Dod;
using System.Collections.ObjectModel;

namespace KCSJ
{

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Equipment> source = null;
        string searchip = "10.63.2.115";
        public MainWindow()
        {
            InitializeComponent();
            //ListVv.Items.Add();
            ListVv.ItemsSource = new ObservableCollection<Equipment>();
            source = this.ListVv.ItemsSource as ObservableCollection<Equipment>;
            ListenAler();
        }

        private void ListenAler()
        {
            Task task = new Task(() =>
            {
                DoAlrm alrm = new DoAlrm();
                alrm.WaitAlrm();
            });
            task.Start();
        }

        private void ListVv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = ListVv.SelectedIndex;
            Equipment equipment = new Equipment(ListVv.SelectedItems[index]);
            Graph g = new Graph(equipment);
            g.Show();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string hint = this.hint.Text;
            string result = "";
            List<Equipment> equipments;

            //Task t = new Task(() =>
            //{
                SendMsg send = new SendMsg(searchip, 9967);

                result = send.Send(hint);
                equipments = DoEquipment.getEqus(result);
                foreach(var v in equipments)
                {
                    source.Add(v);
                }
            //});
            //t.Start();

            //注意一下，这个地方大概不行，可能无法更新主UI中的listView，但是现在没什么数据尝试，等待调试再说。
        }
    }
}
