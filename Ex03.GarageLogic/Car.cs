using System.Linq;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private readonly eDoorAmount r_CarDoorAmount;

        public Car(string i_ModelName, string i_LicensePlate, Wheel[] i_Wheels, Engine i_Engine, eCarColor i_CarColor, eDoorAmount i_DoorAmount) : base(i_ModelName, i_LicensePlate, i_Wheels, i_Engine)
        {
            m_CarColor = i_CarColor;
            r_CarDoorAmount = i_DoorAmount;
        }

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }
            set
            {
                m_CarColor = value;
            }
        }

        public eDoorAmount DoorAmount
        {
            get
            {
                return r_CarDoorAmount;
            }
        }

        public eVehicleType CarType
        {
            get
            {
                return Engine is FuelEngine ? eVehicleType.FuelCar : eVehicleType.ElectricCar;
            }
        }

        public override string ToString()
        {
            string carType = CarType == eVehicleType.FuelCar ? "Fuel" : "Electric";
            string details = string.Format(
                "Car Type: {0}\n" +
                "Model Name: {1}\n" +
                "License Plate: {2}\n" +
                "Color: {3}\n" +
                "Number of Doors: {4}\n" +
                "Wheel Details:\n{5}\n" +
                "Engine Details:\n{6}",
                carType,
                r_ModelName,
                r_LicensePlate,
                m_CarColor,
                r_CarDoorAmount,
                string.Join("\n", r_Wheels.Select(wheel => wheel.ToString())),
                r_Engine.ToString());

            return details;
        }

        public enum eCarColor
        {
            Yellow = 1,
            White = 2,
            Red = 3,
            Grey = 4
        }

        public enum eDoorAmount
        {
            TwoDoors = 2,
            ThreeDoors = 3,
            FourDoors = 4,
            FiveDoors = 5
        }
    }
}
