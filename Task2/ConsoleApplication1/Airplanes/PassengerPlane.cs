using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class PassengerPlane : Airplane   // пассажирский самолёт
    {
        public int PassengerPlaces { get; set; }  // количество пассажирских мест

        // конструктор
        public PassengerPlane(int passengerplaces, string name, int loadcapacity, int totalcapacity, int lengthfly) : base(name, loadcapacity, totalcapacity, lengthfly)
        {
            PassengerPlaces = passengerplaces;
        }

        public override void PlaneDataValidation() // переопределение унаследованного метода для валидации
        {
            if (this.TotalCapacity <= this.PassengerPlaces) // бросаем эксепшен, общее количество мест не больше количества пассажирских мест
            { throw new DataException("Ошибка в данных у одного из самолётов - Общее количество мест не больше количества пассажирских мест. Пожалуйста, перепроверьте данные."); }
        }

        // переопределение ToString для вывода дополнительных данных у класса
        public override string ToString()
        {
            return string.Format("{0} --- {1}", "Passenger plane", base.ToString());
        }
    }
}
