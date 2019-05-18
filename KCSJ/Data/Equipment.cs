using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCSJ.Data
{
    public class Equipment
    {
        public string Bid { get; set; }
        public string Sid { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }

        public Equipment(string data)
        {
            string[] rs = data.Split('^');
            Bid = rs[0];
            Sid = rs[1];
            Name = rs[2];
            Sex = rs[3];
            Age = rs[4];
        }
        public Equipment(Object ts)
        {
            Equipment e = (Equipment)ts;
            Bid = e.Bid;
            Sid = e.Sid;
            Name = e.Name;
            Sex = e.Sex;
            Age = e.Age;
        }
        public override string ToString()
        {
            string result = string.Format("{0}^{1}^{2}^{3}^{4}", Bid, Sid, Name, Sex, Age);
            return result;
        }
    }
}
