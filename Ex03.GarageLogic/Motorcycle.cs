using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eMotorcycleLicenseType m_MotorcycleLicenseType;
        private int m_EngineVolume;
        private readonly eVehicleType r_MotorCycleType;

        public Motorcycle(string i_ModelName, string i_LicensePlate,Wheel[] i_Wheels, Engine i_Engine) : base(i_ModelName,i_LicensePlate,i_Wheels, i_Engine)
        {
        }

        public eMotorcycleLicenseType MotorcycleLicenseType
        {
            get
            {
                return m_MotorcycleLicenseType;
            }
        }

        private void setMotorcycleLicenseType(string i_MotorcycleLicenseType)
        {
            if (!int.TryParse(i_MotorcycleLicenseType, out _))
            {
                throw new FormatException("Invalid type for motorcycle license type selected");
            }
            else
            {
                if (!Enum.TryParse<eMotorcycleLicenseType>(i_MotorcycleLicenseType, out eMotorcycleLicenseType motorcycleLicenseTypeEnum))
                {
                    throw new ArgumentException("Undefined option for motorcycle license type");
                }

                m_MotorcycleLicenseType = motorcycleLicenseTypeEnum;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
        }

        private void setEngineVolume(string i_EngineVolume)
        {
            if (!int.TryParse(i_EngineVolume, out int engineVolume))
            {
                throw new FormatException("Invalid type for engine volume provided");
            }

            if (engineVolume <= 0)
            {
                throw new ArgumentException("Engine volume cannot be non-positive");
            }

            m_EngineVolume = engineVolume;
        }

        public eVehicleType MotorcycleType
        {
            get
            {
                return Engine is FuelEngine ? eVehicleType.FuelMotorcycle : eVehicleType.ElectricMotorcycle;
            }
        }

        public override Dictionary<string, string[]> GetProperties()
        {
            Dictionary<string, string[]> carProperties = new Dictionary<string, string[]>
            {
                { "motorcycle license type", Enum.GetNames(typeof(eMotorcycleLicenseType)).ToArray() },
                { "engine volume", null },
                { base.Engine is FuelEngine ? "Current Fuel Amount" : "battery remaining Operation Time", null}
            };

            return carProperties;
        }

        public override void SetProperties(Dictionary<string, string> i_Properties)
        {
            string motorcycleLicenseType = i_Properties["motorcycle license type"];
            string engineVolume = i_Properties["engine volume"];

            base.Engine.SetProperties(i_Properties);
            setMotorcycleLicenseType(motorcycleLicenseType);
            setEngineVolume(engineVolume);
        }

        protected override void AppendUniqueProperties(StringBuilder generalProperties)
        {
            generalProperties.AppendFormat("License Type: {0}\n", m_MotorcycleLicenseType);
            generalProperties.AppendFormat("Engine Volume: {0}cc\n", m_EngineVolume);
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
