using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KCSJ.Dod
{
    class DataTime
    {
        public static string GetTime()
        {
            string timestring = DateTime.Now.ToString();
            return string.Format("[{0}]:", timestring);
        }
    }
}
