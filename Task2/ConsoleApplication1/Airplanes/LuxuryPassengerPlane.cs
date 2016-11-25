using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class Luxury : PassengerPlane
    {
        // конструктор
        public Luxury(int passengerplaces, string name, int loadcapacity, int totalcapacity, int lengthfly) : base(passengerplaces, name, loadcapacity, totalcapacity, lengthfly)
        {
        }


    }
}
