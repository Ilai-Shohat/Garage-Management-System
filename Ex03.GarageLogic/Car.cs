using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private readonly eCarColor r_CarColor;
        private readonly eDoorAmount r_CarDoorAmount;

        public Car(string i_LicensePlate, Wheel[] i_Wheels, Engine i_Engine) : base(i_LicensePlate, i_Wheels, i_Engine)
        {
        }

        public eCarColor CarColor
        {
            get
            {
                return r_CarColor;
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
