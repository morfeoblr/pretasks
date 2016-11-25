using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class TransportPlane : Airplane
    {
        // конструктор
        public TransportPlane(string name, int loadcapacity, int totalcapacity, int lengthfly) : base(name, loadcapacity, totalcapacity, lengthfly)
        {
            // пока без уникальных дополнительных полей
        }

        // переопределение ToString для вывода дополнительных данных у класса
        public override string ToString()
        {
            return string.Format("{0} --- {1}", "Transport plane", base.ToString());
        }
    }
}
