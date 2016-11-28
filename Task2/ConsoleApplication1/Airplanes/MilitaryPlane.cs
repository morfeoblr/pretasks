using System;
using System.Xml.Serialization;

namespace Solution.Airplanes
{
    [Serializable]
    public class MilitaryPlane : Airplane // военный самолёт
    {
        [XmlElement("AirplaneName_MilitaryPlaneType")]
        private MilitaryPlaneType Militaryplanetype { get; set; } // тип военного самолёта

        public MilitaryPlane()
        {        }

        //конструктор
        public MilitaryPlane(string name, int loadcapacity, int totalcapacity, int lengthfly, MilitaryPlaneType militaryplanetype) : base(name, loadcapacity, totalcapacity, lengthfly)
        {
            Militaryplanetype = militaryplanetype;
        }

        // переопределение ToString для вывода дополнительных данных у класса
        public override string ToString()
        {
            return string.Format("{0}: {1} --- {2}", "Military plane", Militaryplanetype, base.ToString());
        }

        public static MilitaryPlaneType DefinePlaneType(string type)  // define plane type based on string value
        {
            switch (type)
            {
                case "Fighter":
                    {
                        return MilitaryPlaneType.Fighter;
                    }
                case "Attack":
                    {
                        return MilitaryPlaneType.Attack;
                    }
                case "Bomber":
                    {
                        return MilitaryPlaneType.Bomber;
                    }
                default:
                    {
                        // throw error!!!
                        return MilitaryPlaneType.Bomber;
                    }
            }
        }

        public override string ToStringToSaveInTXTFile()
        {
            var s = "MilitaryPlane, " + this.Name + ", " + this.LoadCapacity.ToString() + ", " + this.TotalCapacity.ToString() + ", "
                + this.LengthFly.ToString() + ", " + this.Militaryplanetype;
            return s;
        }
    }
}
