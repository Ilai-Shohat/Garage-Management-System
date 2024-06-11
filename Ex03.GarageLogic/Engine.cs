using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Engine
    {
        private float r_EngineMaxCapacity;

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
            return String.Format("Engine Max Capacity: {0}", r_EngineMaxCapacity);
        }
    }
}
