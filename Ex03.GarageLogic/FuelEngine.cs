using System;

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

        public void Refuel(eFuelType i_FuelType, float i_AmountOfFuelToFill)
        {
            if(i_FuelType == r_FuelType)
            {
                if (i_AmountOfFuelToFill > 0 && m_CurrentFuelAmount + i_AmountOfFuelToFill <= EngineMaxCapacity)
                {
                    m_CurrentFuelAmount += i_AmountOfFuelToFill;
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

        public override string ToString()
        {
            string details = string.Format(
                "Fuel Engine\n" +
                "Fuel Type: {0}\n" +
                "Max Fuel Capacity: {1} liters\n" +
                "Current Fuel Amount: {2} liters",
                r_FuelType,
                EngineMaxCapacity,
                m_CurrentFuelAmount);

            return details;
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
