using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace KCSJ.Dod
{
    class WriteLog
    {
        /// <summary>
        /// 将数据写入文件，作为历史记录
        /// </summary>
        /// <param name="msg">单次要写入的信息</param>
        public static void WriteL(string msg)
        {
            FileStream fs = null;
            string filePath = "log.txt";
            //将待写的入数据从字符串转换为字节数组
            Encoding encoder = Encoding.UTF8;
            byte[] bytes = encoder.GetBytes(msg+"\n");
            try
            {
                fs = File.OpenWrite(filePath);
                //设定书写的开始位置为文件的末尾
                fs.Position = fs.Length;
                //将待写入内容追加到文件末尾
                fs.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("文件打开失败{0}", ex.ToString());
            }
            finally
            {
                fs.Close();
            }
            //Console.ReadLine();
        }
    }
}
