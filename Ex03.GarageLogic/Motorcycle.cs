using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eMotorcycleLicenseType m_MotorcycleLicenseType;
        private int m_EngineVolume;

        public Motorcycle(string i_ModelName, string i_LicensePlate,Wheel[] i_Wheels, Engine i_Engine, eMotorcycleLicenseType i_MotorcycleLicenseType, int i_EngineVolume) : base(i_ModelName,i_LicensePlate,i_Wheels, i_Engine)
        {
            m_MotorcycleLicenseType = i_MotorcycleLicenseType;
            m_EngineVolume = i_EngineVolume;
        }

        public eMotorcycleLicenseType MotorcycleLicenseType
        {
            get
            {
                return m_MotorcycleLicenseType;
            }
            set
            {
                m_MotorcycleLicenseType = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
            set
            {
                m_EngineVolume = value;
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
