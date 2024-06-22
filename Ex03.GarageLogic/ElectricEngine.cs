using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private float m_RemainingOperationTime = 0;
        public ElectricEngine(float i_EngineMaxCapacity) : base(i_EngineMaxCapacity)
        {
        }

        public float RemainingOperationTime
        {
            get
            {
                return m_RemainingOperationTime;
            }
        }

        public override float GetRemainingEnergyPercentage()
        {
            return (m_RemainingOperationTime / EngineMaxCapacity) * 100;
        }

        public void Recharge(string i_HoursToAdd)
        {
            if(!float.TryParse(i_HoursToAdd, out float hoursToAdd))
            {
                throw new FormatException("Please provide a valid number of hours to recharge the engine");
            }
            else if(hoursToAdd > 0 && hoursToAdd + RemainingOperationTime <= EngineMaxCapacity)
            {
                m_RemainingOperationTime += hoursToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException("recharging the engine", 0, EngineMaxCapacity - RemainingOperationTime);
            }
        }

        public override void SetProperties(Dictionary<string, string> i_Properties)
        {
            string remainingOperationTime = i_Properties["battery remaining Operation Time"];

            Recharge(remainingOperationTime);
        }

        public override string ToString()
        {
            string details = string.Format(
                "Electric Engine\n" +
                "Max Battery Capacity: {0} hours\n" +
                "Remaining Battery Time: {1} hours",
                EngineMaxCapacity,
                m_RemainingOperationTime);

            return details;
        }
    }
}
