using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
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
}
