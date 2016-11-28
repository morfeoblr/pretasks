using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Solution
{
    class Menu
    {
        public static int ShowMenuAndGetSelectedItem()
        {
            Console.Clear();
            Console.WriteLine("1. Вывести начальный список самолётов.");
            Console.WriteLine("2. Выполнить сортировку списка самолётов по дальности полёта.");
            Console.WriteLine("3. Посчитать суммарную грузоподъёмность и вместимость самолётов.");
            Console.WriteLine("4. Сделать выборку самолётов по вместимости и дальности полётов.");
            Console.WriteLine("5. Выполнить сериализацию Авиакомпании в бинарный файл.");
            Console.WriteLine("6. Выполнить сериализацию Авиакомпании в XML файл.");
            Console.WriteLine("7. Выполнить запись самолётов Авиакомпании в TXT файл.");
            Console.WriteLine("0. Выйти.");
            return Exceptions.GetNumber();
        }

        public static void MenuExecution(AirCompany newCompany)
        {
            var selectedMenu = Menu.ShowMenuAndGetSelectedItem();
            while (selectedMenu != 0)
            {
                switch (selectedMenu)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("=== Список самолётов авиакомпании ===\n");
                            newCompany.PrintAirplanesList();
                            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                            Console.ReadKey();
                            selectedMenu = Menu.ShowMenuAndGetSelectedItem();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            newCompany.MakeSort();
                            Console.WriteLine("\n=== Отсортированный список самолётов по дальности полёта ===\n");
                            newCompany.PrintAirplanesList();
                            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                            Console.ReadKey();
                            selectedMenu = Menu.ShowMenuAndGetSelectedItem();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("\n=== Суммарная грузоподъёмность самолётов: {0}, суммарная вместимость самолётов: {1}", newCompany.SumLoadCapacity(), newCompany.SumTotalCapacity());
                            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                            Console.ReadKey();
                            selectedMenu = Menu.ShowMenuAndGetSelectedItem();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("\n=== Сделаем выборку по заданному диапазону параметров ===\n");
                            Console.WriteLine("Введите минимальную желаемую вместимость самолёта:");
                            int minLoadCapacity = Exceptions.GetNumber();
                            Console.WriteLine("Введите минимальную желаемую дальность полётов самолёта:");
                            int minFlyLength = Exceptions.GetNumber();
                            AirCompany filteredPlanes1 = newCompany.FilterPlanes(minLoadCapacity, minFlyLength);
                            if (filteredPlanes1.AirplanesList.Count>=1)
                            {
                                Console.WriteLine("\n Самолёты, удовлетворяющие введённым параметрам следующие:");
                                filteredPlanes1.PrintAirplanesList();
                            }
                            else Console.WriteLine("\n Не обнаружено ни одного самолёта, который бы удовлетворял введённым параметрам.");
                            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                            Console.ReadKey();
                            selectedMenu = Menu.ShowMenuAndGetSelectedItem();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            newCompany.SerializationOfAirCompany(newCompany);
                            Console.WriteLine("Авиакомпания была сериализована в файл AirCompany.dat в фолдер Debug");
                            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                            Console.ReadKey();
                            selectedMenu = Menu.ShowMenuAndGetSelectedItem();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            newCompany.SerializeToXML(newCompany);
                            Console.WriteLine("Авиакомпания была сериализована в файл AirCompany.xml в фолдер Debug");
                            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                            Console.ReadKey();
                            selectedMenu = Menu.ShowMenuAndGetSelectedItem();
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            newCompany.SaveCompanyToTXTFile(newCompany);
                            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                            Console.ReadKey();
                            selectedMenu = Menu.ShowMenuAndGetSelectedItem();
                            break;
                        }
                    default:
                            Console.WriteLine("Введённого значения нет в меню. Попробуйте ещё раз!");
                            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                            Console.ReadKey();
                            selectedMenu = Menu.ShowMenuAndGetSelectedItem();
                            break;
                }
            }
        }
    }
}
