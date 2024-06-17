using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.GarageLogic
{
    internal class VehicleGenerator
    {
        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, string i_ModelName, string i_LicensePlate, object[] i_VehicleSpecificData)
        {
            Vehicle newVehicle;
            Engine engine = GenerateEngine(i_VehicleType);
            Wheel[] wheels = GenerateWheels(i_VehicleType);

            switch (i_VehicleType)
            {
                case eVehicleType.FuelCar:
                    newVehicle = new Car(i_ModelName, i_LicensePlate, wheels, engine as FuelEngine, (eCarColor)i_VehicleSpecificData[0], (eDoorAmount)i_VehicleSpecificData[1]);
                    break;
                case eVehicleType.ElectricCar:
                    newVehicle = new Car(i_ModelName, i_LicensePlate, wheels, engine as ElectricEngine, (eCarColor)i_VehicleSpecificData[0], (eDoorAmount)i_VehicleSpecificData[1]);
                    break;
                case eVehicleType.FuelMotorcycle:
                    newVehicle = new Motorcycle(i_ModelName, i_LicensePlate, wheels, engine as FuelEngine, (eMotorcycleLicenseType)i_VehicleSpecificData[0], (int)i_VehicleSpecificData[1]);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    newVehicle = new Motorcycle(i_ModelName, i_LicensePlate, wheels, engine as ElectricEngine, (eMotorcycleLicenseType)i_VehicleSpecificData[0], (int)i_VehicleSpecificData[1]);
                    break;
                case eVehicleType.FuelTruck:
                    newVehicle = new Truck(i_ModelName, i_LicensePlate, wheels, engine as FuelEngine, (float)i_VehicleSpecificData[0], (bool)i_VehicleSpecificData[1]);
                    break;
                default:
                    newVehicle = null;
                    break;
            }

            return newVehicle;
        }

        private static Engine GenerateEngine(eVehicleType i_VehicleType)
        {
            Engine newEngine;
            if(i_VehicleType == eVehicleType.ElectricMotorcycle || i_VehicleType == eVehicleType.ElectricCar)
            {
                newEngine = new ElectricEngine(VehicleProperties.GetElectricEngineMaxBatteryLife()[i_VehicleType]);
            }
            else
            {
                newEngine = new FuelEngine(VehicleProperties.GetFuelType()[i_VehicleType], VehicleProperties.GetFuelTankCapacity()[i_VehicleType]);
            }

            return newEngine;
        }

        private static Wheel[] GenerateWheels(eVehicleType i_VehicleType)
        {
            int wheelsCount = VehicleProperties.GetWheelsCount()[i_VehicleType];
            float maxAirPressure = VehicleProperties.GetWheelsMaxAirPressure()[i_VehicleType];

            Wheel[] wheels = new Wheel[wheelsCount];
            for (int i = 0; i < wheelsCount; i++)
            {
                wheels[i] = new Wheel(maxAirPressure);
            }

            return wheels;
        }
    }
}