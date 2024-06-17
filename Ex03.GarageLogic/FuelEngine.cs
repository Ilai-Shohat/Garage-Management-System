using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;
        private float m_CurrentFuelAmount;

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
            string detailes = string.Format(base.ToString() + "\nEngine Fuel type: {0}" + "\nCurrent Fuel Amount: {1}", r_FuelType, m_CurrentFuelAmount);

            return detailes;
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
