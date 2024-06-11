using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private readonly eMotorcycleLicenseType r_MotorcycleLicenseType;
        private int m_EngineVolume;

        public Motorcycle(string i_LicensePlate,Wheel[] i_Wheels, Engine i_Engine) : base(i_LicensePlate,i_Wheels, i_Engine)
        {
        }

        public eMotorcycleLicenseType MotorcycleLicenseType
        {
            get
            {
                return r_MotorcycleLicenseType;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
        }

        public enum eMotorcycleLicenseType
        {
            A,
            A1,
            AA,
            B1
        }
    }
}
