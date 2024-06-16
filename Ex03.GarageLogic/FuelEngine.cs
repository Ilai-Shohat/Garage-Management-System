using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private eFuelType m_FuelType;
        private float m_CurrentFuelAmount;

        public FuelEngine(eFuelType i_FuelType, float i_EngineMaxCapacity) : base(i_EngineMaxCapacity)
        {
            m_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
            set
            {
                m_FuelType = value;
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
            if(i_FuelType == m_FuelType)
            {
                if (m_CurrentFuelAmount + i_AmountOfFuelToFill <= EngineMaxCapacity)
                {
                    m_CurrentFuelAmount += i_AmountOfFuelToFill;
                }
                else
                {
                    //TODO: throw exception
                }
            }
            else
            {
                throw new ArgumentException(string.Format("incorrect fuel type, engine takes {0} Fuel", m_FuelType));
            }
            
        }

        public override string ToString()
        {
            string detailes = string.Format(base.ToString() + "\nEngine Fuel type: {0}" + "\nCurrent Fuel Amount: {1}", m_FuelType, m_CurrentFuelAmount);

            return detailes;
        }

        public enum eFuelType
        {
            Soler,
            Octane95,
            Octane96, 
            Octane98
        }
    }
}
