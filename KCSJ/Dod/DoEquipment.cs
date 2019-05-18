using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCSJ.Data;
namespace KCSJ.Dod
{
    class DoEquipment
    {
        public static List<Equipment> getEqus(string data)
        {
            List<Equipment> equipments = new List<Equipment>();
            string[] rs = data.Split(' ');
            foreach (var v in rs)
            {
                if (v.IndexOf("\0\0") != -1)
                    break;
                Equipment equipment = new Equipment(v);
                equipments.Add(equipment);
            }
            return equipments;
        }

        
    }
}
