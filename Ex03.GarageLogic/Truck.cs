using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly float r_CargoTankVolume;
        private  bool m_IsContainsDangerousMaterials;

        public Truck(string i_LicensePlate, Wheel[] i_Wheels, Engine i_Engine,float i_CargoTankVolume,bool i_IsContainsDangerousMaterials) : base(i_LicensePlate, i_Wheels, i_Engine)
        {
            r_CargoTankVolume = i_CargoTankVolume;
            m_IsContainsDangerousMaterials = i_IsContainsDangerousMaterials;
        }

        public float CargoTankVolume
        {
            get { return r_CargoTankVolume; }

        }

        public bool IsContainDangerousMaterials
        {
            get { return m_IsContainsDangerousMaterials; }
            set
            {
                m_IsContainsDangerousMaterials = value;
            }
        }

        public override string ToString()
        {
            string detailes = String.Format("Truck is capable of carrying {0}\nTruck {1} containing dangerous materials", m_CargoTankVolume, m_IsContainsDangerousMaterials ? "is" : "isn't");

            return detailes;
        }
    }
}
