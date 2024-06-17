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

        public void Recharge(float i_HoursToAdd)
        {
            if(i_HoursToAdd > 0 && i_HoursToAdd + RemainingOperationTime <= EngineMaxCapacity)
            {
                m_RemainingOperationTime += i_HoursToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException("recharging the engine", 0, EngineMaxCapacity - RemainingOperationTime);
            }
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
