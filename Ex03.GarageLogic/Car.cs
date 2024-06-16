using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private readonly eDoorAmount r_CarDoorAmount;

        public Car(string i_ModelName, string i_LicensePlate, Wheel[] i_Wheels, Engine i_Engine, eCarColor i_CarColor, eDoorAmount i_DoorAmount) : base(i_ModelName, i_LicensePlate, i_Wheels, i_Engine)
        {
            m_CarColor = i_CarColor;
            r_CarDoorAmount = i_DoorAmount;
        }

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }
            set
            {
                m_CarColor = value;
            }
        }

        public eDoorAmount DoorAmount
        {
            get
            {
                return r_CarDoorAmount;
            }
        }

        public enum eCarColor
        {
            Yellow,
            White,
            Red,
            Grey
        }

        public enum eDoorAmount
        {
            TwoDoors = 2,
            ThreeDoors = 3,
            FourDoors = 4,
            FiveDoors = 5
        }
    }
}
