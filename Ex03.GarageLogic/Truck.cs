using System;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly float r_CargoTankVolume;
        private bool m_IsContainsDangerousMaterials;

        public Truck(string i_ModelName, string i_LicensePlate, Wheel[] i_Wheels, Engine i_Engine,float i_CargoTankVolume,bool i_IsContainsDangerousMaterials) : base(i_ModelName, i_LicensePlate, i_Wheels, i_Engine)
        {
            r_CargoTankVolume = i_CargoTankVolume;
            m_IsContainsDangerousMaterials = i_IsContainsDangerousMaterials;
        }

        public float CargoTankVolume
        {
            get 
            { 
                return r_CargoTankVolume; 
            }
        }

        public bool IsContainDangerousMaterials
        {
            get 
            { 
                return m_IsContainsDangerousMaterials; 
            }
            set
            {
                m_IsContainsDangerousMaterials = value;
            }
        }

        public override string ToString()
        {
            string containsDangerousMaterials = m_IsContainsDangerousMaterials ? "Yes" : "No";
            string details = string.Format(
                "Truck\n" +
                "Model Name: {0}\n" +
                "License Plate: {1}\n" +
                "Cargo Tank Volume: {2} liters\n" +
                "Contains Dangerous Materials: {3}\n" +
                "Wheel Details:\n{4}\n" +
                "Engine Details:\n{5}",
                r_ModelName,
                r_LicensePlate,
                r_CargoTankVolume,
                containsDangerousMaterials,
                string.Join("\n", r_Wheels.Select(wheel => wheel.ToString())),
                r_Engine.ToString());

            return details;
        }
    }
}
