using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.FuelEngine;

namespace Ex03.GarageLogic
{
    internal static class VehicleProperties
    {
        public const int k_CarWheelsCount = 4;
        public const int k_MotorcycleWheelsCount = 2;
        public const int k_TruckWheelsCount = 12;

        public const float k_CarWheelMaxAirPressure = 31f;
        public const float k_MotorcycleWheelMaxAirPressure = 33f;
        public const float k_TruckWheelMaxAirPressure = 28f;

        public const eFuelType k_FuelCarFuelType = eFuelType.Octane95;
        public const float k_FuelCarFuelTankCapacity = 45f;

        public const float k_ElectricCarMaxBatteryLife = 3.5f;

        public const eFuelType k_FuelMotorcycleFuelType = eFuelType.Octane98;
        public const float k_FuelMotorcycleFuelTankCapacity = 5.5f;

        public const float k_ElectricMotorcycleMaxBatteryLife = 2.5f;

        public const eFuelType k_TruckFuelType = eFuelType.Soler;
        public const float k_TruckFuelTankCapacity = 120f;

        public static Dictionary<eVehicleType, int> GetWheelsCount()
        {
            return new Dictionary<eVehicleType, int>
            {
                { eVehicleType.FuelCar, k_CarWheelsCount },
                { eVehicleType.ElectricCar, k_CarWheelsCount },
                { eVehicleType.FuelMotorcycle, k_MotorcycleWheelsCount },
                { eVehicleType.ElectricMotorcycle, k_MotorcycleWheelsCount },
                { eVehicleType.FuelTruck, k_TruckWheelsCount }
            };
        }

        public static Dictionary<eVehicleType, float> GetWheelsMaxAirPressure()
        {
            return new Dictionary<eVehicleType, float>            {
                { eVehicleType.FuelCar, k_CarWheelMaxAirPressure },
                { eVehicleType.ElectricCar, k_CarWheelMaxAirPressure },
                { eVehicleType.FuelMotorcycle, k_MotorcycleWheelMaxAirPressure },
                { eVehicleType.ElectricMotorcycle, k_MotorcycleWheelMaxAirPressure },
                { eVehicleType.FuelTruck, k_TruckWheelMaxAirPressure }
            };
        }

        public static Dictionary<eVehicleType, eFuelType> GetFuelType()
        {
            return new Dictionary<eVehicleType, eFuelType>
            {
                { eVehicleType.FuelCar, k_FuelCarFuelType },
                { eVehicleType.FuelMotorcycle, k_FuelMotorcycleFuelType },
                { eVehicleType.FuelTruck, k_TruckFuelType }
            };
        }

        public static Dictionary<eVehicleType, float> GetFuelTankCapacity()
        {
            return new Dictionary<eVehicleType, float>
            {
                { eVehicleType.FuelCar, k_FuelCarFuelTankCapacity },
                { eVehicleType.FuelMotorcycle, k_FuelMotorcycleFuelTankCapacity },
                { eVehicleType.FuelTruck, k_TruckFuelTankCapacity }
            };
        }

        public static Dictionary<eVehicleType, float> GetElectricEngineMaxBatteryLife()
        {
            return new Dictionary<eVehicleType, float>
            {
                { eVehicleType.ElectricCar, k_ElectricCarMaxBatteryLife },
                { eVehicleType.ElectricMotorcycle, k_ElectricMotorcycleMaxBatteryLife }
            };
        }
    }
}