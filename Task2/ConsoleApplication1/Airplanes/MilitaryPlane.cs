using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class MilitaryPlane : Airplane // военный самолёт
    {
        private MilitaryPlaneType Militaryplanetype { get; set; } // тип военного самолёта

        //конструктор
        public MilitaryPlane(MilitaryPlaneType militaryplanetype, string name, int loadcapacity, int totalcapacity, int lengthfly) : base(name, loadcapacity, totalcapacity, lengthfly)
        {
            Militaryplanetype = militaryplanetype;
        }

        // переопределение ToString для вывода дополнительных данных у класса
        public override string ToString()
        {
            return string.Format("{0}: {1} --- {2}", "Military plane", Militaryplanetype, base.ToString());
        }

    }
}
