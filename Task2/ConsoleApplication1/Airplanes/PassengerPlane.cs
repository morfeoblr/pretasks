using System;
using System.Xml.Serialization;

namespace Solution.Airplanes
{
    [Serializable]
    public class PassengerPlane : Airplane   // пассажирский самолёт
    {
        [XmlElement("AirplaneName_PassengerPlaces")]
        public int PassengerPlaces { get; set; }  // количество пассажирских мест

        public PassengerPlane()
        {
        }

        // конструктор
        public PassengerPlane(string name, int loadCapacity, int totalCapacity, int lengthFly, int passengerPlaces) : base(name, loadCapacity, totalCapacity, lengthFly)
        {
            PassengerPlaces = passengerPlaces;
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
