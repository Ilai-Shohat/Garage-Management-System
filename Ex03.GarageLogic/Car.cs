using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eDoorAmount m_CarDoorAmount;

        public Car(string i_ModelName, string i_LicensePlate, Wheel[] i_Wheels, Engine i_Engine) : base(i_ModelName, i_LicensePlate, i_Wheels, i_Engine)
        {
        }

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }
        }

        private void setCarColor(string i_CarColorString)
        {
            eCarColor carColorEnum;

            if (!int.TryParse(i_CarColorString, out _))
            {
                throw new FormatException("Invalid type for car color");
            }
            else
            {
                if (!Enum.TryParse<eCarColor>(i_CarColorString, out carColorEnum))
                {
                    throw new ArgumentException("Undefined option for car color");
                }
            }

            m_CarColor = carColorEnum;
        }

        public eDoorAmount DoorAmount
        {
            get
            {
                return m_CarDoorAmount;
            }
        }

        private void setNumberOfDoors(string i_CarDoorsString)
        {
            eDoorAmount carDoorsEnum;

            if (!int.TryParse(i_CarDoorsString, out _))
            {
                throw new FormatException("Invalid option for car doors");
            }
            else
            {
                if (!Enum.TryParse<eDoorAmount>(i_CarDoorsString, out carDoorsEnum))
                {
                    throw new ArgumentException("Undefined option for car doors");
                }
            }

            m_CarDoorAmount = carDoorsEnum;
        }

        public eVehicleType CarType
        {
            get
            {
                return Engine is FuelEngine ? eVehicleType.FuelCar : eVehicleType.ElectricCar;
            }
        }

        public override Dictionary<string, string[]> GetProperties()
        {
            Dictionary<string, string[]> carProperties = new Dictionary<string, string[]>
            {
                {"car's color", Enum.GetNames(typeof(eCarColor)).ToArray()},
                {"car door amount", Enum.GetNames(typeof(eDoorAmount)).ToArray()},
                {base.Engine is FuelEngine ? "Current Fuel Amount" : "Remaining Operation Time", null}
            };

            return carProperties;
        }

        public override void SetProperties(Dictionary<string, string> i_Properties)
        {
            string carColorString = i_Properties["car's color"];
            string carDoorAmount = i_Properties["car door amount"];

            base.Engine.SetProperties(i_Properties);
            setCarColor(carColorString);
            setNumberOfDoors(carDoorAmount);
        }

        protected override void AppendUniqueProperties(StringBuilder generalProperties)
        {
            generalProperties.AppendFormat("Color: {0}\n", m_CarColor);
            generalProperties.AppendFormat("Number of Doors: {0}\n", m_CarDoorAmount);
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
            TwoDoors = 1,
            ThreeDoors = 2,
            FourDoors = 3,
            FiveDoors = 4
        }
    }
}
