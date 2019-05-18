using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCSJ.Data
{
    class Check
    {
        public int Hr { get; set; }
        public double Spo2 { get; set; }
        public double Temp { get; set; }

        public Check(string data)
        {
            string[] s = data.Split('^');
            Hr = Convert.ToInt32(s[0]);
            Spo2 = Convert.ToDouble(s[1]);
            Temp = Convert.ToDouble(s[3]);
        }

        public override string ToString()
        {
            string result = string.Format("{0}^{1}^{2}", Hr, Spo2, Temp);
            return result;
        }
    }
}
