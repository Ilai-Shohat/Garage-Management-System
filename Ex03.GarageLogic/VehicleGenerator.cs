using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.GarageLogic
{
    internal class VehicleGenerator
    {
        public static Car createCar(string i_ModelName, string i_LicensePlate, Wheel[] i_Wheels, Engine i_Engine, eCarColor i_CarColor, eDoorAmount i_DoorAmount)
        {
            return new Car(i_ModelName, i_LicensePlate, i_Wheels, i_Engine, i_CarColor, i_DoorAmount);
        }
        public static Motorcycle createMotorcycle(string i_ModelName, string i_LicensePlate, Wheel[] i_Wheels, Engine i_Engine, eMotorcycleLicenseType i_MotorcycleLicenseType, int i_EngineVolume)
        {
            return new Motorcycle(i_ModelName, i_LicensePlate, i_Wheels, i_Engine, i_MotorcycleLicenseType, i_EngineVolume);
        }
        public static Truck createTruck(string i_ModelName, string i_LicensePlate, Wheel[] i_Wheels, Engine i_Engine, float i_CargoTankVolume, bool i_IsContainsDangerousMaterials)
        {
            return new Truck(i_ModelName, i_LicensePlate, i_Wheels, i_Engine, i_CargoTankVolume, i_IsContainsDangerousMaterials);
        }
    }
}
