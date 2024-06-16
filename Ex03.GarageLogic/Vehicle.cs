using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_ModelName;
        protected readonly string r_LicensePlate;
        protected float m_EnergyPercentage;
        protected readonly Wheel[] r_Wheels;
        protected readonly Engine r_Engine;

        public Vehicle(string i_ModelName ,string i_LicensePlate, Wheel[] i_Wheels, Engine i_Engine)
        {
            r_ModelName = i_ModelName;
            r_LicensePlate = i_LicensePlate;
            r_Wheels = i_Wheels;
            r_Engine = i_Engine;
            //TODO: get energy percentage
        }
        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public string LicensePlate
        {
            get
            {
                return r_LicensePlate;
            }
        }

        public Wheel[] Wheels
        {
            get
            {
                return r_Wheels;
            }
        }

        public Engine Engine
        {
            get
            {
                return r_Engine;
            }
        }
    }
}
