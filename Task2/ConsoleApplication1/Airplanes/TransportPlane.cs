using System;

namespace Solution.Airplanes
{
    [Serializable]
    public class TransportPlane : Airplane
    {
        // конструктор
        public TransportPlane(string name, int loadCapacity, int totalcapacity, int lengthfly) : base(name, loadCapacity, totalcapacity, lengthfly)
        {
            // пока без уникальных дополнительных полей
        }

        public TransportPlane()
        { }

        // переопределение ToString для вывода дополнительных данных у класса
        public override string ToString()
        {
            return string.Format("{0} --- {1}", "Transport plane", base.ToString());
        }

        public override string ToStringToSaveInTXTFile()
        {
            var s = "TransportPlane, " + this.Name + ", " + this.LoadCapacity.ToString() + ", " + this.TotalCapacity.ToString() + ", " + this.LengthFly.ToString();
            return s;
        }
    }
}
