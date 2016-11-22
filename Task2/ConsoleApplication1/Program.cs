using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        public Airplane (string name, int loadcapacity, int totalcapacity, int lengthfly)
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
        {        }
    }

    public class PassengerPlane : Airplane   // пассажирский самолёт
    {
        public int PassengerPlaces { get; set; }  // количество пассажирских мест

        // конструктор
        public PassengerPlane(int passengerplaces, string name, int loadcapacity, int totalcapacity, int lengthfly): base(name, loadcapacity, totalcapacity, lengthfly)
        {
            PassengerPlaces = passengerplaces;
        }

        public override void PlaneDataValidation() // переопределение унаследованного метода для валидации
        {
            if (this.TotalCapacity <= this.PassengerPlaces) // бросаем эксепшен, общее количество мест не больше количества пассажирских мест
            {  throw new DataException("Ошибка в данных у одного из самолётов - Общее количество мест не больше количества пассажирских мест. Пожалуйста, перепроверьте данные."); }
        }

        // переопределение ToString для вывода дополнительных данных у класса
        public override string ToString()
        {
            return string.Format("{0} --- {1}","Passenger plane",base.ToString());
        }
    }

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

    // перечисление типов военных самолётов
    public enum MilitaryPlaneType
    {
        Fighter,
        Attack,
        Bomber
    }

    class DataException : Exception     // пользовательский класс эксепшенов, используется только для текстового месседжа
    {
        public DataException(string message)
            : base(message)
        { }
    }

    class Exceptions // класс эксепшенов, в котором используются системные эксепшены
    {
        public static int GetNumber() // эксепшен на обработку введённых данных пользователем, когда ожидается ввод Integer переменной
        {
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException) // неверный формат
            {
                Console.WriteLine("You've entered incorrect number format! The program will be closed.");
                Console.ReadKey();
                Environment.Exit(0);
                return 0;
            }
            catch (System.OverflowException) // корректный формат, но введённое значение не входит в диапазон значения для типа Integer
            {
                Console.WriteLine("You've entered too big numer, please enter less in next time. The program will be closed.");
                Console.ReadKey();
                Environment.Exit(0);
                return 0;
            }
        }

        public static void Output(Airplane plane) // исключение, которое может случиться при работе с объектом plane
        {
            try
            {
                Console.WriteLine(plane.ToString());
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Planes objects were not created - please check their creation. The program will be closed.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }

    class AirCompanyCreationThroughCode
    {
        public static Airplane[] FirstWayOfCreation(Airplane[] AirplaneCompany)    // метод создания компании, когда самолёты захардкоданы в коде
        {
            try
            {
                AirplaneCompany[0] = new PassengerPlane(250, "Boing-111", 10000, 270, 5000);
                AirplaneCompany[1] = new PassengerPlane(300, "Boing-112", 9000, 320, 7000);
                AirplaneCompany[2] = new PassengerPlane(220, "Boing-113", 8500, 240, 2000);
                AirplaneCompany[3] = new PassengerPlane(400, "Boing-114", 7000, 410, 3000);
                AirplaneCompany[4] = new PassengerPlane(500, "Boing-115", 9900, 510, 6000);
                AirplaneCompany[5] = new PassengerPlane(270, "Boing-116", 8000, 280, 9000);
                AirplaneCompany[6] = new PassengerPlane(100, "Boing-117", 7000, 111, 4000);
                AirplaneCompany[7] = new TransportPlane("Tansportir-001", 14000, 10, 7000);
                AirplaneCompany[8] = new MilitaryPlane(MilitaryPlaneType.Attack, "Stels-001", 11000, 2, 10500);
                AirplaneCompany[9] = new MilitaryPlane(MilitaryPlaneType.Attack, "Stels-002", 11000, 3, 8500);

                foreach (Airplane a in AirplaneCompany) // валидация самолётов авикомапнии, поиск массажирских самолётов и их валидация
                {
                    if (a.GetType() == typeof(PassengerPlane)) { a.PlaneDataValidation(); } // валидация осуществляется только для пассажирских самолётов
                }
                //  при выполнении кода ниже получим обработанное исключение
                //  AirplaneCompany[10] = new PassengerPlane(100, "Boing-117", 7000, 111, 4000);
            }
            catch (System.IndexOutOfRangeException) // исключение, когда пользователь пытается создать больше самолёт, чем ожидается
            {
                Console.WriteLine("Planes objects were not created - please check their creation: there was attempt to create more planes than expected. The program will be closed.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return AirplaneCompany;
        }
    }

    class AirCompany
    {
        static void Main()
        {
            // создаём авиа компанию с набором самолётов
            Airplane[] AirplaneCompany = new Airplane[10];
            AirCompanyCreationThroughCode.FirstWayOfCreation(AirplaneCompany);

    //        string AirplanesFile = @"C:\Users\Aliaksei\Documents\Visual Studio 2015\Projects\Airplanes.txt";
    //        if (File.Exists(AirplanesFile))
    //        {
    //            try
    //            {
    //                StreamReader stream = new StreamReader(AirplanesFile);
    //                Console.WriteLine(stream.ReadToEnd());
                    // string inputString = stream.ReadToEnd();
                    // добавить обработку пустого файла ЛИБО с некорректной датой

    //            }
    //            catch (IOException) { Console.WriteLine("Some File error happened. Unable to Read requested file."); Console.ReadKey(); }
    //        }
    //        else { Console.WriteLine("The file " + AirplanesFile + " does not exist"); }

            Console.WriteLine("=== Начальный список самолётов ===\n");
            foreach (Airplane a in AirplaneCompany)
            {
                Exceptions.Output(a);
            }
            Array.Sort(AirplaneCompany); // делаем сортировку
            Console.WriteLine("\n=== Отсортированный список самолётов по дальности полёта ===\n");
            foreach (Airplane a in AirplaneCompany)
            {
                Exceptions.Output(a);
            }

            int sumloadcapacity = 0; int sumtotalcapacity = 0;
            foreach (Airplane a in AirplaneCompany)
            {
                sumloadcapacity += a.LoadCapacity;
                sumtotalcapacity += a.TotalCapacity;
            }
            Console.WriteLine("\n=== Суммарная грузоподъёмность самолётов: {0}, суммарная вместимость самолётов: {1}", sumloadcapacity, sumtotalcapacity);

            Console.WriteLine("\n=== Сделаем выборку по заданному диапазону параметров ===\n");
            Console.WriteLine("Введите минимальную желаемую вместимость самолёта:");
            int minloadcapacity = Exceptions.GetNumber();
            Console.WriteLine("Введите минимальную желаемую дальность полётов самолёта:");
            int minflylength = Exceptions.GetNumber();

            List<Airplane> FilteredPlanes = new List<Airplane>();     // создаём список с отфильтрованными самолётами, которые удовлетворяют условию фильтрации
            foreach (Airplane a in AirplaneCompany.Where(n => n.TotalCapacity >= minloadcapacity && n.LengthFly >= minflylength))
            {
                FilteredPlanes.Add(a);
            }

            if (FilteredPlanes.Count>=1) // выводим список отфильтрованных самолётов, когда нам есть что выводить
            {
                Console.WriteLine("\n Самолёты, удовлетворяющие введённым параметрам следующие:");
                foreach (Airplane a in FilteredPlanes)
                {
                    Exceptions.Output(a);
                }
            }
            else Console.WriteLine("\n Не обнаружено ни одного самолёта, который бы удовлетворял введённым параметрам.");
            Console.ReadLine();
        }
    }
}