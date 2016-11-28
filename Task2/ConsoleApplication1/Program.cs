using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using Solution.Airplanes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;

namespace Solution
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Пожалуйства введите способ создания самолётов: ");
            Console.WriteLine("1. Использовать захардкоданые данные в коде.");
            Console.WriteLine("2. Считать данные из файла Sources/Airplanes.txt.");
            Console.WriteLine("3. Считать данные из бинарного файла в Sources/AirCompany.dat (десериализация бинарного файла).");
            Console.WriteLine("4. Считать данные из XML файла в Sources/AirCompany.xml (десериализация xml файла).");
            Console.WriteLine("5. Хочу поработать с БД.");

            int choice = Exceptions.GetNumber();
            switch (choice)
            {
                case 1:
                    {
                        AirCompany newCompany = new AirCompany("TestCompany-Hardcode");
                        newCompany.CreateAirCompany(AirCompanySourceTypes.Default);
                        Console.WriteLine("Компания успешно создана, нажмите любую клавишу, чтобы продолжить...");
                        Console.ReadKey();
                        Menu.MenuExecution(newCompany);
                        break;
                    }
                case 2:
                    {
                        AirCompany newCompany = new AirCompany("TestCompany-FromTXTFile");
                        newCompany.CreateAirCompany(AirCompanySourceTypes.TXT);
                        Console.WriteLine("Компания успешно создана, нажмите любую клавишу, чтобы продолжить...");
                        Console.ReadKey();
                        Menu.MenuExecution(newCompany);
                        break;
                    }
                case 3:
                    {
                        AirCompany newCompany = new AirCompany();
                        newCompany = newCompany.DeserializationOfAirCompany();
                        Console.WriteLine("Компания успешно создана, нажмите любую клавишу, чтобы продолжить...");
                        Console.ReadKey();
                        Menu.MenuExecution(newCompany);
                        break;
                    }
                case 4:
                    {
                        AirCompany newCompany;
                        XmlSerializer deserializer = new XmlSerializer(typeof(AirCompany));
                        TextReader textReader = new StreamReader("AirCompany.xml");
                        newCompany = (AirCompany)deserializer.Deserialize(textReader);
                        textReader.Close();
                        Console.WriteLine("Компания успешно создана, нажмите любую клавишу, чтобы продолжить...");
                        Console.ReadKey();
                        Menu.MenuExecution(newCompany);
                        break;
                    }
                case 5:
                    {
                        using (var cn = new SqlConnection())
                        {
                            Console.WriteLine("Connection object --> " + cn.GetType().Name);
                            cn.ConnectionString = ConfigurationManager.AppSettings["cnStr"];
                            cn.Open();
                        }
                            break;
                    }
                default:
                        break;
            }
        }
    }
}