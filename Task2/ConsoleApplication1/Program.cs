using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Solution
{
    class AirCompany
    {
        public static void FirstWayOfCreation(List<Airplane> AirplaneCompany)    // метод создания компании, когда самолёты захардкоданы в коде
        {
            try
            {
                AirplaneCompany.Add(new PassengerPlane(250, "Boing-111", 10000, 270, 5000));
                AirplaneCompany.Add(new PassengerPlane(300, "Boing-112", 9000, 320, 7000));
                AirplaneCompany.Add(new PassengerPlane(220, "Boing-113", 8500, 240, 2000));
                AirplaneCompany.Add(new PassengerPlane(400, "Boing-114", 7000, 410, 3000));
                AirplaneCompany.Add(new PassengerPlane(500, "Boing-115", 9900, 510, 6000));
                AirplaneCompany.Add(new PassengerPlane(270, "Boing-116", 8000, 280, 9000));
                AirplaneCompany.Add(new PassengerPlane(100, "Boing-117", 7000, 111, 4000));
                AirplaneCompany.Add(new TransportPlane("Tansportir-001", 14000, 10, 7000));
                AirplaneCompany.Add(new MilitaryPlane(MilitaryPlaneType.Attack, "Stels-001", 11000, 2, 10500));
                AirplaneCompany.Add(new MilitaryPlane(MilitaryPlaneType.Attack, "Stels-002", 11000, 3, 8500));
                //  при выполнении кода ниже получим обработанное исключение
                //  AirplaneCompany[10] = new PassengerPlane(100, "Boing-117", 7000, 111, 4000);
            }
            catch (System.IndexOutOfRangeException) // исключение, когда пользователь пытается создать больше самолётов, чем ожидается
            {
                Console.WriteLine("Planes objects were not created - please check their creation: there was attempt to create more planes than expected. The program will be closed.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public static void SecondWayOfCreation(List<Airplane> AirplaneCompany)    // метод создания компании, когда данные считываются с файла
        {
            try
            {
                string AirplanesFile = @"c:\Users\Aliaksei\Documents\Visual Studio 2015\Projects\Task2\Airplanes.txt";
                if (File.Exists(AirplanesFile))
                {
                    try
                    {
                        StreamReader stream = new StreamReader(AirplanesFile);
                        string s = stream.ReadLine();
                        while (s != null)
                        {
                            s = s.Replace("  ", string.Empty);
                            s = stream.ReadLine();
                            Console.WriteLine(s);
                        }
                        Console.ReadLine();

                        // добавить обработку пустого файла ЛИБО с некорректной датой

                        AirplaneCompany.Add(new PassengerPlane(250, "Boing-111", 10000, 270, 5000));
                        AirplaneCompany.Add(new TransportPlane("Tansportir-001", 14000, 10, 7000));
                        AirplaneCompany.Add(new MilitaryPlane(MilitaryPlaneType.Attack, "Stels-001", 11000, 2, 10500));
                    }
                    catch (IOException) { Console.WriteLine("Some File error happened. Unable to Read requested file."); Console.ReadKey(); }
                }
                else { Console.WriteLine("The file " + AirplanesFile + " does not exist"); }
            }
            catch (System.IndexOutOfRangeException) // исключение, когда пользователь пытается создать больше самолётов, чем ожидается
            {
                Console.WriteLine("Planes objects were not created - please check their creation: there was attempt to create more planes than expected. The program will be closed.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        static void Main()
        {
            // создаём авиа компанию с набором самолётов
            var AirplaneCompany = new List <Airplane>(10);

            Console.WriteLine("Пожалуйства введите способ создания самолётов: ");
            Console.WriteLine("1. Использовать захардкоданые данные в коде.");
            Console.WriteLine("2. Считать данные с файла.");
            int choice = Exceptions.GetNumber();
            switch (choice)
            {
                case 1:
                    {
                        FirstWayOfCreation(AirplaneCompany);
                        break;
                    }
                case 2:
                    {
                        SecondWayOfCreation(AirplaneCompany);
                        break;
                    }
                default:
                    {
                        FirstWayOfCreation(AirplaneCompany);
                        break;
                    }
            }

            foreach (Airplane a in AirplaneCompany) // валидация самолётов авикомапнии, поиск массажирских самолётов и их валидация
            {
                if (a.GetType() == typeof(PassengerPlane)) { a.PlaneDataValidation(); } // валидация осуществляется только для пассажирских самолётов
            }

            Console.WriteLine("=== Начальный список самолётов ===\n");
            foreach (Airplane a in AirplaneCompany)
            {
                Exceptions.Output(a);
            }
            AirplaneCompany.Sort(); // делаем сортировку
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