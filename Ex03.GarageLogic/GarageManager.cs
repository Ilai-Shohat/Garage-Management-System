using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        protected readonly Dictionary<string, VehicleEntry> r_VehiclesInGarage;

        public GarageManager()
        {
            r_VehiclesInGarage = new Dictionary<string, VehicleEntry>();
        }

        public Dictionary<string, VehicleEntry> VehiclesInGarage
        {
            get
            {
                return r_VehiclesInGarage;
            }
        }

        public bool Contains(string i_LicensePlate)
        {
            return r_VehiclesInGarage.ContainsKey(i_LicensePlate);
        }

        public VehicleEntry GetVehicleByLicensePlate(string i_LicensePlate)
        {
            return r_VehiclesInGarage[i_LicensePlate];
        }

        public void AddVehicleToGarage(
            VehicleRecord i_VehicleRecord, 
            eVehicleType i_VehicleType,
            string i_ModelName,
            string i_LicensePlate,
            string i_WheelManufacturer,
            string i_CurrentAirPressure)
        {
            Vehicle vehicleToBeAdded = VehicleGenerator.CreateVehicle(i_VehicleType, i_ModelName, i_LicensePlate, i_WheelManufacturer, i_CurrentAirPressure);
            VehicleEntry vehicleEntry = new VehicleEntry(vehicleToBeAdded, i_VehicleRecord);

            r_VehiclesInGarage[i_LicensePlate] = vehicleEntry;
        }

        public Dictionary<string, VehicleEntry> GetVehiclesByStatus(VehicleRecord.eVehicleStatus i_VehicleStatus)
        {
            Dictionary<string, VehicleEntry> registeredVehiclesByStatusDict = new Dictionary<string, VehicleEntry>();

            foreach (string registeredVehicleLicensePlate in r_VehiclesInGarage.Keys)
            {
                if (r_VehiclesInGarage[registeredVehicleLicensePlate].VehicleRecord.VehicleStatus == i_VehicleStatus)
                {
                    registeredVehiclesByStatusDict.Add(registeredVehicleLicensePlate, r_VehiclesInGarage[registeredVehicleLicensePlate]);
                }
            }

            return registeredVehiclesByStatusDict;
        }

        public void ChangeVehicleStatus(string i_LicensePlate, VehicleRecord.eVehicleStatus i_NewStatus)
        {
            r_VehiclesInGarage[i_LicensePlate].VehicleRecord.VehicleStatus = i_NewStatus;
        }

        public void InflateVehiclesWheelsToMax(string i_LicensePlate)
        {
            r_VehiclesInGarage[i_LicensePlate].Vehicle.InflateWheelsToMax();
        }

        public void RefuelVehicleEngine(string i_LicensePlate, string i_LitersToFillString, FuelEngine.eFuelType i_FuelType)
        {
            if (r_VehiclesInGarage[i_LicensePlate].Vehicle.Engine is FuelEngine engineToRefuel)
            {
                engineToRefuel.Refuel(i_FuelType, i_LitersToFillString);
            }
            else
            {
                throw new ArgumentException("Cannot fuel an Electric engine with gasoline");
            }
        }

        public void ChargeVehicleBattery(string i_LicensePlate, string i_TimeToChargeString)
        {

            if (r_VehiclesInGarage[i_LicensePlate].Vehicle.Engine is ElectricEngine engineToRecharge)
            {
                engineToRecharge.Recharge(i_TimeToChargeString);
            }
            else
            {
                throw new ArgumentException("Cannot charge a gasoline vehicle");
            }
        }

        public string GetVehicleInformation(string i_LicensePlate)
        {
            return r_VehiclesInGarage[i_LicensePlate].ToString();
        }
    }
}
