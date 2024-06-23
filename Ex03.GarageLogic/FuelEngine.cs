using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;
        private float m_CurrentFuelAmount = 0;

        public FuelEngine(eFuelType i_FuelType, float i_EngineMaxCapacity) : base(i_EngineMaxCapacity)
        {
            r_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public float CurrentFuelAmount
        {
            get
            {
                return m_CurrentFuelAmount;
            }
        }

        public override float GetRemainingEnergyPercentage()
        {
            return m_CurrentFuelAmount / EngineMaxCapacity * 100;
        }

        public void Refuel(eFuelType i_FuelType, string i_AmountOfFuelToFill)
        {
            if(!float.TryParse(i_AmountOfFuelToFill, out float amountOfFuelToFill))
            {
                throw new FormatException("Please provide a valid number of liters to refuel the engine");
            }
            else if (i_FuelType == r_FuelType)
            {
                if (amountOfFuelToFill > 0 && m_CurrentFuelAmount + amountOfFuelToFill <= EngineMaxCapacity)
                {
                    m_CurrentFuelAmount += amountOfFuelToFill;
                }
                else
                {
                    throw new ValueOutOfRangeException("refueling the engine", 0, EngineMaxCapacity - CurrentFuelAmount);
                }
            }
            else
            {
                throw new ArgumentException(string.Format("incorrect fuel type, engine takes {0} Fuel", r_FuelType));
            }
        }

        public override void SetProperties(Dictionary<string, string> i_Properties)
        {
            string currentFuelAmount = i_Properties["Current Fuel Amount"];

            Refuel(r_FuelType ,currentFuelAmount);
        }

        public override string ToString()
        {
            string engineDetails = string.Format(
                "Fuel Engine\n" +
                "Fuel Type: {0}\n" +
                "Max Fuel Capacity: {1} liters\n" +
                "Current Fuel Amount: {2} liters",
                r_FuelType,
                EngineMaxCapacity,
                m_CurrentFuelAmount);

            return engineDetails;
        }
        public enum eFuelType
        {
            Soler = 1,
            Octane95 = 2,
            Octane96 = 3,
            Octane98 = 4
        }
    }
}
