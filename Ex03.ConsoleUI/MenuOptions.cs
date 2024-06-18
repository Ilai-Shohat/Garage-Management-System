using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal static class MenuOptions
    {
        private static readonly string[] sr_MainMenuOptions = new string[8] { "Add new Vehicle", "Show all Vehicles filtered by status", "Change Vehicle status", "Inflate Vehicle wheels to maximum", "Fuel Vehicle's engine", "Charge Vehicle's battery", "Show Vehicle properties", "Exit application" };
        private static readonly string[] sr_FuelMenuOptions = new string[4] { "Soler", "Octan95", "Octan96", "Octan98" };
        private static readonly string[] sr_ModelMenuOptions = new string[5] { "Truck", "Electric Motorcycle", "Regular Motorcycle", "Electric Car", "Regular Car" };
        private static readonly string[] sr_StatusToFilterByMenuOptions = new string[4] { "InRepair", "Repaired", "Paid", "All" };
        private static readonly string[] sr_VehicleStatusMenuOptions = new string[3] { "InRepair", "Repaired", "Paid" };
        public const string k_AddNewVehicleHeadline = "ADD NEW VEHICLE";
        public const string k_ShowVehiclesFilteredByHeadline = "SHOW ALL VEHICLES FILTERED BY GARAGE STATUS";
        public const string k_ChangeVehicleStatusHeadline = "CHANGE VEHICLE STATUS";
        public const string k_InflateWheelsToMaxHeadline = "INFLATE WHEELS TO MAX";
        public const string k_FuelVehicleEngineHeadline = "FUEL VEHICLE ENGINE";
        public const string k_ChargeVehicleBatteryHeadline = "CHARGE VEHICLE ENGINE";
        public const string k_ShowVehiclePropertiesHeadline = "SHOW VEHICLE PROPERTIES";
        public const string k_OwnerCreationHeadline = "OWNER CREDENTIALS";
        public const string k_GarageHeadline = "WELCOME TO OUR GARAGE";
        public const string k_VehicleRegisteredMsg = "Thank you. We've successfully registered your vehicle in our garage, Press 'Enter' to navigate back to the main menu";
        public const string k_AskForLicensePlateMsg = "Please provide the license plate for the vehicle and press 'Enter' :";
        public const string k_VehicleIsAlreadyInTheGarageMsg = "Vehicle is already in the Garage, changing its status to InRepair, Press 'Enter' to navigate back to the main menu";
        public const string k_ShowVehiclesFilteredByMsg = "Please select status to filter all vehicles by:";
        public const string k_PressEnterToGoBackToMainMenuMsg = "Press 'Enter' to navigate back to the main menu.";
        public const string k_FuelEngineSuccessfullyMsg = "Vehicle has been fueled successfully";
        public const string k_ChargeEngineSuccessfullyMsg = "Charged vehicle's battery successfully";
        public const string k_WheelsInflatedSuccessfullyMsg = "Wheels inflated successfully to maximum PSI";
        public const string k_VehicleNotFoundByLicensePlateMsg = "Couldn't find vehicle by the license plate you provided";
        public const string k_VehicleStatusChangedSuccessfullyMsg = "Vehicle status have been changed successfully";
        public const string k_ModelMenuDescription = "Please choose one of the following model's :";
        public const string k_MainMenuDescription = "Main Menu :";
        public const string k_ChargeBatteryDescription = "Please enter for how long would you like to charge the battery :";
        public const string k_FuelEngineDescription = "Please enter how many liters would you like to fuel the vehicle :";

        public static string[] MainMenuOption
        {
            get { return sr_MainMenuOptions; }
        }

        public static string[] FuelMenuOption
        {
            get { return sr_FuelMenuOptions; }
        }

        public static string[] ModelMenuOptions
        {
            get { return sr_ModelMenuOptions; }
        }

        public static string[] StatusToFilterByMenuOptions
        {
            get { return sr_StatusToFilterByMenuOptions; }
        }

        public static string[] VehicleStatusMenuOptions
        {
            get { return sr_VehicleStatusMenuOptions; }
        }

        public enum eMainMenuOption
        {
            AddNewVehicle = 1,
            ShowVehiclesByStatus = 2,
            ChangeVehicleStatus = 3,
            InflateVehicleWheels = 4,
            FuelVehicle = 5,
            ChargeVehicle = 6,
            ShowVehicleProperties = 7,
            ExitApplication = 8,
        }
    }
}
