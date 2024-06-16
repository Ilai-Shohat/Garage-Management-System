using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private float m_CargoTankVolume;
        private bool m_IsContainsDangerousMaterials;

        public Truck(string i_LicensePlate, Wheel[] i_Wheels, Engine i_Engine) : base(i_LicensePlate, i_Wheels, i_Engine)
        {
        }

        public float CargoTankVolume
        {
            get { return m_CargoTankVolume; }
            set
            {
                if (value < 0)
                {
                    //TODO: exception
                }
                else
                {
                    m_CargoTankVolume = value;
                }
            }

        }

        public override string ToString()
        {
            string detailes = String.Format("Truck is capable of carrying {0}\nTruck {1} containing dangerous materials", m_CargoTankVolume, m_IsContainsDangerousMaterials ? "is" : "isn't");

            return detailes;
        }
    }
}
