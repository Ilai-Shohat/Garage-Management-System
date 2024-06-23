namespace Ex03.GarageLogic
{
    internal class VehicleGenerator
    {
        public static Vehicle CreateVehicle(
            eVehicleType i_VehicleType,
            string i_ModelName,
            string i_LicensePlate,
            string i_WheelManufacturer,
            string i_CurrentAirPressure)
        {
            Vehicle newVehicle;
            Engine engine = GenerateEngine(i_VehicleType);
            Wheel[] wheels = GenerateWheels(i_VehicleType, i_WheelManufacturer, i_CurrentAirPressure);

            switch (i_VehicleType)
            {
                case eVehicleType.FuelCar:
                    newVehicle = new Car(i_ModelName, i_LicensePlate, wheels, engine as FuelEngine);
                    break;
                case eVehicleType.ElectricCar:
                    newVehicle = new Car(i_ModelName, i_LicensePlate, wheels, engine as ElectricEngine);
                    break;
                case eVehicleType.FuelMotorcycle:
                    newVehicle = new Motorcycle(i_ModelName, i_LicensePlate, wheels, engine as FuelEngine);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    newVehicle = new Motorcycle(i_ModelName, i_LicensePlate, wheels, engine as ElectricEngine);
                    break;
                case eVehicleType.FuelTruck:
                    newVehicle = new Truck(i_ModelName, i_LicensePlate, wheels, engine as FuelEngine);
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

        private static Wheel[] GenerateWheels(eVehicleType i_VehicleType, string i_WheelManufacturer, string i_CurrentAirPressure)
        {
            int wheelsCount = VehicleProperties.GetWheelsCount()[i_VehicleType];
            float maxAirPressure = VehicleProperties.GetWheelsMaxAirPressure()[i_VehicleType];
            Wheel[] wheels = new Wheel[wheelsCount];

            for (int i = 0; i < wheelsCount; i++)
            {
                wheels[i] = new Wheel(i_WheelManufacturer, i_CurrentAirPressure, maxAirPressure);
            }

            return wheels;
        }
    }
}