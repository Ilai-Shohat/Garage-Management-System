using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddVehicle(eVehicleType i_VehicleType)
        {
            switch(i_VehicleType)
            {
                case eVehicleType.FuelCar:
                    break;
                case eVehicleType.ElectricCar:
                    break;
                case eVehicleType.FuelMotorcycle:
                    break;
                case eVehicleType.ElectricMotorcycle:
                    break;
                case eVehicleType.FuelTruck:
                    break;

            }

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
                if (float.TryParse(i_LitersToFillString, out float litersToFill))
                {
                    engineToRefuel.Refuel(i_FuelType, litersToFill);
                }
                else
                {
                    throw new FormatException("Fuel parameter is invalid");
                }
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
                if (float.TryParse(i_TimeToChargeString, out float timeToCharge))
                {
                    engineToRecharge.Recharge(timeToCharge);
                }
                else
                {
                    throw new FormatException("Charging parameter is invalid");
                }
            }
            else
            {
                throw new ArgumentException("Cannot charge a gasoline vehicle");
            }
        }

        public void DisplayVehicleInformation(string i_LicensePlate)
        {
            Console.WriteLine(r_VehiclesInGarage[i_LicensePlate].ToString());
        }
    }
}
