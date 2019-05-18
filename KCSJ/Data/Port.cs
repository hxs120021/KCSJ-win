using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCSJ.Data
{
    class Port
    {
        public int X { set; get; }
        public int Y { get; set; }

        public Port(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Clear()
        {
            X = 2;
            Y = 89;
        }
    }
}
