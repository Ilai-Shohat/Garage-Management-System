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
        private readonly int r_EngineVolume;
        private readonly eVehicleType r_MotorCycleType;

        public Motorcycle(string i_ModelName, string i_LicensePlate,Wheel[] i_Wheels, Engine i_Engine, eMotorcycleLicenseType i_MotorcycleLicenseType, int i_EngineVolume) : base(i_ModelName,i_LicensePlate,i_Wheels, i_Engine)
        {
            r_MotorcycleLicenseType = i_MotorcycleLicenseType;
            r_EngineVolume = i_EngineVolume;
            
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
                return r_EngineVolume;
            }
        }

        public eVehicleType MotorcycleType
        {
            get
            {
                return Engine is FuelEngine ? eVehicleType.FuelMotorcycle : eVehicleType.ElectricMotorcycle;
            }
        }

        public enum eMotorcycleLicenseType
        {
            A = 1,
            A1 = 2,
            AA = 3,
            B1 = 4
        }
    }
}
