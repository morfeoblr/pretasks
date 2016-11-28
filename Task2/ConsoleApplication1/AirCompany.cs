using System;
using System.Collections.Generic;
using Solution.Airplanes;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Solution
{
    [Serializable]
    public class AirCompany
    {
        [XmlElement("AirplaneCompanyName")]
        public string CompanyName { get; set; }

        [XmlElement("AirplaneCompany_Airplanes")]
        private List<Airplane> airplanesList;

        public AirCompany(string companyName)
        {
            airplanesList = new List<Airplane>();
            CompanyName = companyName;
        //    Count = airplanesList.Count;
        }

        public AirCompany()
        {
            airplanesList = new List<Airplane>();
        }

        public List<Airplane> AirplanesList
        {
            get { return airplanesList ?? new List<Airplane>(); }
            private set { }
          //  set { airplanesList = value; } 
        }

        public void MakeSort()
        {
            airplanesList.Sort();
        }

        public void AddAirplane(Airplane airplane)
        {
            airplanesList.Add(airplane);
        }

        public void AddAirplane(string airPlaneFromFile) // method to add airplanes from TXT file
        {
            string[] arrayOfPlaneFields = airPlaneFromFile.Split(',');  // add handling incorrect data? e.g. more commas? + count of fields?
            var name = arrayOfPlaneFields[1];
            int loadCapacity = Convert.ToInt32(arrayOfPlaneFields[2]);
            int totalCapacity = Convert.ToInt32(arrayOfPlaneFields[3]);
            int lengthFly = Convert.ToInt32(arrayOfPlaneFields[4]);
            switch (arrayOfPlaneFields[0])
            {
                case "PassengerPlane":
                    {
                        int passengerPlaces = Convert.ToInt32(arrayOfPlaneFields[5]);
                        airplanesList.Add(new PassengerPlane(name, loadCapacity, totalCapacity, lengthFly, passengerPlaces));
                        break;
                    }
                case "TransportPlane":
                    {
                        airplanesList.Add(new TransportPlane(name, loadCapacity, totalCapacity, lengthFly));
                        break;
                    }
                case "MilitaryPlane":
                    {
                        MilitaryPlaneType militaryplanetype = MilitaryPlane.DefinePlaneType(arrayOfPlaneFields[5]);
                        airplanesList.Add(new MilitaryPlane(name, loadCapacity, totalCapacity, lengthFly, militaryplanetype));
                        break;
                    }
                default:
                    // throw error?
                    break;
            }
        }

        public void RemoveAirplane(Airplane airplane)
        {
            airplanesList.Remove(airplane);
            AirplanesList = AirplanesList;      //
        }

        public void PrintAirplanesList()
        {
            foreach (var airplane in AirplanesList)
            {
                Console.WriteLine(airplane.ToString());
            }
        }

        public void ValidateCompanyPlanes()
        {
            foreach (var airplane in AirplanesList) // валидация самолётов авикомапнии (пассажирских)
            {
                airplane.PlaneDataValidation();  // валидация осуществляется только для пассажирских самолётов
            }
        }

        public int SumLoadCapacity()
        {
            var sumLoadCapacity = 0;
            foreach (var plane in AirplanesList)
            {
                sumLoadCapacity += plane.LoadCapacity;
            }
            return sumLoadCapacity;
        }

        public int SumTotalCapacity()
        {
            var sumTotalCapacity = 0;
            foreach (var plane in AirplanesList)
            {
                sumTotalCapacity += plane.TotalCapacity;
            }
            return sumTotalCapacity;
        }

        public AirCompany FilterPlanes(int minLoadCapacity, int minFlyLength)
        {
            AirCompany filteredPlanes = new AirCompany();
            foreach (var plane in airplanesList)
            {
                if (plane.TotalCapacity >= minLoadCapacity && plane.LengthFly >= minFlyLength)
                {
                    filteredPlanes.AddAirplane(plane);
                }
            }
            return filteredPlanes;
        }

        public void SerializationOfAirCompany(AirCompany airCompany)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("AirCompany.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, airCompany);
            }
        }

        public AirCompany DeserializationOfAirCompany()
        {
            AirCompany newCompany = new AirCompany("TestCompany-FromDatFile");
            using (FileStream fs = new FileStream("AirCompany.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                newCompany = (AirCompany)formatter.Deserialize(fs);
                //          Console.WriteLine("\nPlease see DeSerialized planes of the AirCompany:\n");
                //          this.PrintAirplanesList();
                //          Console.ReadKey();
                return newCompany;
            }
        }

        public void SerializeToXML(AirCompany airCompany)
        {
            using (FileStream fs = new FileStream("AirCompany.xml", FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(airCompany.GetType());
                serializer.Serialize(fs, airCompany);
            }
        }

        public void CreateAirCompany(AirCompanySourceTypes source)
        {
            switch (source)
            {
                case AirCompanySourceTypes.Default:
                    AddAirplane(new PassengerPlane("Boing-111", 10000, 270, 5000, 250));
                    AddAirplane(new PassengerPlane("Boing-111", 10000, 270, 5000, 260));
                    AddAirplane(new PassengerPlane("Boing-112", 9000, 320, 7000, 300));
                    AddAirplane(new PassengerPlane("Boing-113", 8500, 240, 2000, 220));
                    AddAirplane(new PassengerPlane("Boing-114", 7000, 410, 3000, 400));
                    AddAirplane(new PassengerPlane("Boing-115", 9900, 510, 6000, 500));
                    AddAirplane(new PassengerPlane("Boing-116", 8000, 280, 9000, 270));
                    AddAirplane(new PassengerPlane("Boing-117", 7000, 111, 4000, 100));
                    AddAirplane(new TransportPlane("Tansportir-001", 14000, 10, 7000));
                    AddAirplane(new MilitaryPlane("Stels-001", 11000, 2, 10500, MilitaryPlaneType.Attack));
                    AddAirplane(new MilitaryPlane("Stels-002", 11000, 3, 8500, MilitaryPlaneType.Attack));
                    ValidateCompanyPlanes();
                    break;
                case AirCompanySourceTypes.TXT:
                    string airplanesFile = @"Sources\Airplanes.txt";
                    try
                    {
                        StreamReader stream = new StreamReader(airplanesFile);
                        while (true)
                        {
                            string airPlaneFromFile = stream.ReadLine();
                            if (airPlaneFromFile == null) break;
                            airPlaneFromFile = airPlaneFromFile.Replace(" ", string.Empty); // null reference is not handled, remove all spaced in the file
                            AddAirplane(airPlaneFromFile);
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        throw new SourceNotFoundException("The file " + airplanesFile + " does not exist");
                    }
                    catch (IOException)
                    {
                        throw new SourceEmptyOrIncorrectException("Some File error happened. Unable to Read requested file.");
                    }
                    
                    break;
                case AirCompanySourceTypes.XML:
                    //
                    break;
                case AirCompanySourceTypes.Dat:
                    //         this.DeserializationOfAirCompany();
                    break;
                default:
                    break;
            }
        }
    }
}