using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    // асбтрактный класс самолёт
    public abstract class Airplane : IComparable<Airplane>
    {
        public string Name { get; set; }
        public int LoadCapacity { get; set; }    // грузоподъёмность самолёта
        public int TotalCapacity { get; set; }   // общая вместимость самолёта
        public int LengthFly { get; set; }       // длина полёта самолёта

        // конструктор
        public Airplane(string name, int loadcapacity, int totalcapacity, int lengthfly)
        {
            Name = name;
            LoadCapacity = loadcapacity;
            TotalCapacity = totalcapacity;
            LengthFly = lengthfly;
        }

        // переопределение ToString для вывода полей самолёта на экран
        public override string ToString()
        {
            return string.Format("Name: {0}, Load Capacity (kg): {1}, Total Capacity (persons): {2}, Length Fly (km): {3}", Name, LoadCapacity, TotalCapacity, LengthFly);
        }

        // определение функции для интерфейса IComparable, необходимый для последующей сортировки
        public int CompareTo(Airplane another)
        {
            if (this.LengthFly > another.LengthFly)
                return 1;
            if (this.LengthFly < another.LengthFly)
                return -1;
            else
                return 0;
        }

        public virtual void PlaneDataValidation()    // вирутальный метод для валидации, в дальнейшем будет определён пока только для пассажирского самолёта
        { }
    }
}
