using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private float m_CargoTankVolume;
        private bool m_IsContainsDangerousMaterials;

        public Truck(string i_ModelName, string i_LicensePlate, Wheel[] i_Wheels, Engine i_Engine) : base(i_ModelName, i_LicensePlate, i_Wheels, i_Engine)
        {
        }

        public float CargoTankVolume
        {
            get 
            { 
                return m_CargoTankVolume; 
            }
        }

        private void setCargoTankVolume(string i_CargoTankVolume)
        {
            if (!float.TryParse(i_CargoTankVolume, out float cargoTankVolume))
            {
                throw new FormatException("Invalid value provided for cargo tank volume");
            }

            if(cargoTankVolume <= 0)
            {
                throw new ArgumentException("Cargo tank volume must be a positive number");
            }

            m_CargoTankVolume = cargoTankVolume;
        }

        public bool IsContainDangerousMaterials
        {
            get 
            { 
                return m_IsContainsDangerousMaterials; 
            }
        }

        private void setIsContainsDangerousMaterials(string i_IsContainsDangerousMaterials)
        {
            if(i_IsContainsDangerousMaterials != "1" && i_IsContainsDangerousMaterials != "2")
            {
                throw new ArgumentException("Invalid option for dangerous materials was chosen");
            }

            m_IsContainsDangerousMaterials = i_IsContainsDangerousMaterials == "1";
        }

        public override Dictionary<string, string[]> GetProperties()
        {
            Dictionary<string, string[]> carProperties = new Dictionary<string, string[]>
            {
                {"cargo Tank Volume", null},
                {"contains dangerous materials", new []{ "contains dangerous materials", "doesn't contain dangerous materials" } },
                {"Current Fuel Amount", null}
            };

            return carProperties;
        }

        public override void SetProperties(Dictionary<string, string> i_Properties)
        {
            string cargoTankVolume = i_Properties["cargo Tank Volume"];
            string IsContainsDangerousMaterials = i_Properties["contains dangerous materials"];

            base.Engine.SetProperties(i_Properties);
            setCargoTankVolume(cargoTankVolume);
            setIsContainsDangerousMaterials(IsContainsDangerousMaterials);
        }

        protected override void AppendUniqueProperties(StringBuilder generalProperties)
        {
            generalProperties.AppendFormat("Cargo Tank Volume: {0} liters\n", m_CargoTankVolume);
            generalProperties.AppendFormat("Contains Dangerous Materials: {0}\n", m_IsContainsDangerousMaterials ? "Yes" : "No");
        }
    }
}
