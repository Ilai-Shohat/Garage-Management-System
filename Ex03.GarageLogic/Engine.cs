using System;

namespace Ex03.GarageLogic
{
    public class Engine
    {
        private readonly float r_EngineMaxCapacity;

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

        public override string ToString()
        {
            string details = string.Format(
                "Engine Max Capacity: {0}",
                r_EngineMaxCapacity);

            return details;
        }
    }
}
