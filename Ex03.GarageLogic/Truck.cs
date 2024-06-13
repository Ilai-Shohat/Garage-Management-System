using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private float m_CargoVolume;
        private bool IsContainsDangerousMaterials;


        public Truck(string i_LicensePlate, Wheel[] i_Wheels, Engine i_Engine ) : base(i_LicensePlate, i_Wheels, i_Engine)
        {
            
        }

        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Cargo volume is invalid");
                }
                else
                {
                    m_CargoVolume = value;

                }
            }

        }

        //i think we should write class of To String
        //i dont use the 2 fields in the constrctur because i dont understad if i get them from the user and then put in construtur or we should do a deafult veribale ???
       
    }
    
    
}
