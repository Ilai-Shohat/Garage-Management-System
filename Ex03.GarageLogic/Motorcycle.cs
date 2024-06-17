using System.Linq;

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

        public override string ToString()
        {
            string motorcycleType = MotorcycleType == eVehicleType.FuelMotorcycle ? "Fuel" : "Electric";
            string details = string.Format(
                "Motorcycle Type: {0}\n" +
                "Model Name: {1}\n" +
                "License Plate: {2}\n" +
                "License Type: {3}\n" +
                "Engine Volume: {4}cc\n" +
                "Wheel Details:\n{5}\n" +
                "Engine Details:\n{6}",
                motorcycleType,
                r_ModelName,
                r_LicensePlate,
                r_MotorcycleLicenseType,
                r_EngineVolume,
                string.Join("\n", r_Wheels.Select(wheel => wheel.ToString())),
                r_Engine.ToString());

            return details;
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
