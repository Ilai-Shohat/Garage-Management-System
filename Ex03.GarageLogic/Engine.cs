using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected readonly float r_EngineMaxCapacity;

        public Engine(float i_EngineMaxCapacity)
        {
            r_EngineMaxCapacity = i_EngineMaxCapacity;
        }

        public float EngineMaxCapacity
        {
            get
            {
                return r_EngineMaxCapacity;
            }
        }

        public abstract float GetRemainingEnergyPercentage();

        public abstract void SetProperties(Dictionary<string, string> i_Properties);

        public override string ToString()
        {
            string engineDetails = string.Format(
                "Engine Max Capacity: {0}",
                r_EngineMaxCapacity);

            return engineDetails;
        }
    }
}
