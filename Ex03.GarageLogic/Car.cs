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
        private eDoorAmount m_CarDoorAmount;

        public Car(string i_LicensePlate, Wheel[] i_Wheels, Engine i_Engine) : base(i_LicensePlate, i_Wheels, i_Engine)
        {
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
                return m_CarDoorAmount;
            }
            set
            {
                m_CarDoorAmount = value;
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
