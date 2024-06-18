using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using ConsoleUI;


namespace Ex03.ConsoleUI
{
    internal static class Runner
    {
        private static GarageManager s_GarageManager = new GarageManager();

        public static void StartGarageManagementSystem()
        {
            mainMenu();
        }

        private static void mainMenu()
        {
            bool isQuitOptionPressed = false;

            while (!isQuitOptionPressed)
            {
                ConsoleRenderer.RenderHeadline(MenuOptions.k_GarageHeadline);
                ConsoleRenderer.RenderMenu(MenuOptions.k_MainMenuDescription, MenuOptions.MainMenuOption);
                MenuOptions.eMainMenuOption selectedOption = (MenuOptions.eMainMenuOption)int.Parse(Validator.InputValidatorGeneric<int>((i_MaxValue, i_UserInput) => Validator.IsNumberTypeAndInRange(i_MaxValue, i_UserInput, int.TryParse), MenuOptions.MainMenuOption.Length));

                switch (selectedOption)
                {
                    case MenuOptions.eMainMenuOption.AddNewVehicle:
                        addNewVehicle();
                        break;

                    case MenuOptions.eMainMenuOption.ShowVehiclesByStatus:
                        showVehiclesByStatus();
                        break;

                    case MenuOptions.eMainMenuOption.ChangeVehicleStatus:
                        changeVehicleStatus();
                        break;

                    case MenuOptions.eMainMenuOption.InflateVehicleWheels:
                        inflateVehicleWheelsToMax();
                        break;

                    case MenuOptions.eMainMenuOption.FuelVehicle:
                        fuelVehicle();
                        break;

                    case MenuOptions.eMainMenuOption.ChargeVehicle:
                        chargeVehicle();
                        break;

                    case MenuOptions.eMainMenuOption.ShowVehicleProperties:
                        DisplayVehicleInformation();
                        break;

                    case MenuOptions.eMainMenuOption.ExitApplication:
                        isQuitOptionPressed = true;
                        break;

                }
            }
        }

        private static void addNewVehicle()
        {
            ConsoleRenderer.RenderHeadline(MenuOptions.k_AddNewVehicleHeadline);
            string userInputLicensePlate = ConsoleRenderer.RenderRequestForANonEmptyString(MenuOptions.k_AskForLicensePlateMsg);

            if (s_GarageManager.Contains(userInputLicensePlate))
            {
                ConsoleRenderer.RenderMessageAndWaitForUserEnterAnyKey(MenuOptions.k_VehicleIsAlreadyInTheGarageMsg);
                s_GarageManager.ChangeVehicleStatus(userInputLicensePlate, VehicleRecord.eVehicleStatus.InRepair);
            }
            else
            {

            }
        }

        private static void showVehiclesByStatus()
        {
            ConsoleRenderer.RenderHeadline(MenuOptions.k_ShowVehiclesFilteredByHeadline);
            ConsoleRenderer.RenderMenu(MenuOptions.k_ShowVehiclesFilteredByMsg, MenuOptions.StatusToFilterByMenuOptions);

            string selectedStatus = Validator.InputValidatorGeneric<int>((i_MaxValue, i_UserInput) => Validator.IsNumberTypeAndInRange(i_MaxValue, i_UserInput, int.TryParse), MenuOptions.StatusToFilterByMenuOptions.Length);
            int vehiclesStatusConvertedToInt = int.Parse(selectedStatus);
            Dictionary<string, VehicleEntry> filteredVehiclesByStatus;

            if(vehiclesStatusConvertedToInt != 4)
            {
                filteredVehiclesByStatus = s_GarageManager.GetVehiclesByStatus((VehicleRecord.eVehicleStatus)vehiclesStatusConvertedToInt);
            }
            else
            {
                filteredVehiclesByStatus = s_GarageManager.VehiclesInGarage;
            }

            ConsoleRenderer.RenderHeadline(MenuOptions.k_ShowVehiclePropertiesHeadline);
            ConsoleRenderer.RenderVehiclesLicensePlateByStatus(filteredVehiclesByStatus, MenuOptions.StatusToFilterByMenuOptions[vehiclesStatusConvertedToInt - 1]);
        }

        private static void changeVehicleStatus()
        {
            ConsoleRenderer.RenderHeadline(MenuOptions.k_ChangeVehicleStatusHeadline);
            string licensePlateFromUserString = ConsoleRenderer.RenderRequestForANonEmptyString(MenuOptions.k_AskForLicensePlateMsg);

            if (s_GarageManager.Contains(licensePlateFromUserString))
            {
                ConsoleRenderer.RenderMenu("Select status to modify to : ", MenuOptions.VehicleStatusMenuOptions);
                VehicleRecord.eVehicleStatus statusToChange = (VehicleRecord.eVehicleStatus)int.Parse(Validator.InputValidatorGeneric<int>((i_MaxValue, i_UserInput) => Validator.IsNumberTypeAndInRange(i_MaxValue, i_UserInput, int.TryParse), MenuOptions.VehicleStatusMenuOptions.Length));
                s_GarageManager.ChangeVehicleStatus(licensePlateFromUserString, statusToChange);
                ConsoleRenderer.RenderMessageAndWaitForUserEnterAnyKey(string.Format("{0} , {1}", MenuOptions.k_VehicleStatusChangedSuccessfullyMsg, MenuOptions.k_PressEnterToGoBackToMainMenuMsg));
            }
            else
            {
                ConsoleRenderer.RenderMessageAndWaitForUserEnterAnyKey(string.Format("{0} ,{1}", MenuOptions.k_VehicleNotFoundByLicensePlateMsg, MenuOptions.k_PressEnterToGoBackToMainMenuMsg));
            }
        }

        private static void inflateVehicleWheelsToMax()
        {
            ConsoleRenderer.RenderHeadline(MenuOptions.k_InflateWheelsToMaxHeadline);
            string licensePlateFromUserString = ConsoleRenderer.RenderRequestForANonEmptyString(MenuOptions.k_AskForLicensePlateMsg);

            if (s_GarageManager.Contains(licensePlateFromUserString))
            {
                s_GarageManager.InflateVehiclesWheelsToMax(licensePlateFromUserString);
                ConsoleRenderer.RenderMessageAndWaitForUserEnterAnyKey(string.Format("{0} ,{1}", MenuOptions.k_WheelsInflatedSuccessfullyMsg, MenuOptions.k_PressEnterToGoBackToMainMenuMsg));
            }
            else
            {
                ConsoleRenderer.RenderMessageAndWaitForUserEnterAnyKey(string.Format("{0} ,{1} ", MenuOptions.k_VehicleNotFoundByLicensePlateMsg, MenuOptions.k_PressEnterToGoBackToMainMenuMsg));
            }
        }

        private static void fuelVehicle()
        {
            ConsoleRenderer.RenderHeadline(MenuOptions.k_FuelVehicleEngineHeadline);
            string licensePlateFromUserString = ConsoleRenderer.RenderRequestForANonEmptyString(MenuOptions.k_AskForLicensePlateMsg);
            FuelEngine.eFuelType fuelTypeFromUser = getFuelTypeFromUser();
            ConsoleRenderer.RenderMessage(MenuOptions.k_FuelEngineDescription);
            string amountToFillFromUser = Validator.InputValidatorGeneric<float>((i_MaxValue, i_UserInput) => Validator.IsNumberTypeAndInRange(i_MaxValue, i_UserInput, float.TryParse), float.MaxValue);

            if (s_GarageManager.Contains(licensePlateFromUserString))
            {
                try
                {
                    s_GarageManager.RefuelVehicleEngine(licensePlateFromUserString, amountToFillFromUser, fuelTypeFromUser);
                    ConsoleRenderer.RenderMessageAndWaitForUserEnterAnyKey(string.Format("{0} ,{1}", MenuOptions.k_FuelEngineSuccessfullyMsg, MenuOptions.k_PressEnterToGoBackToMainMenuMsg));
                }
                catch (Exception e)
                {
                    ConsoleRenderer.RenderMessageAndWaitForUserEnterAnyKey(string.Format("{0} ,{1}", e.Message, MenuOptions.k_PressEnterToGoBackToMainMenuMsg));
                }
            }
            else
            {
                ConsoleRenderer.RenderMessageAndWaitForUserEnterAnyKey(string.Format("{0} ,{1}", MenuOptions.k_VehicleNotFoundByLicensePlateMsg, MenuOptions.k_PressEnterToGoBackToMainMenuMsg));
            }
        }

        private static FuelEngine.eFuelType getFuelTypeFromUser()
        {
            ConsoleRenderer.RenderMenu("Please choose the fuel type :", MenuOptions.FuelMenuOption);

            return (FuelEngine.eFuelType)int.Parse(Validator.InputValidatorGeneric<int>((i_MaxValue, i_UserInput) => Validator.IsNumberTypeAndInRange(i_MaxValue, i_UserInput, int.TryParse), MenuOptions.FuelMenuOption.Length));
        }

        private static void chargeVehicle()
        {
            ConsoleRenderer.RenderHeadline(MenuOptions.k_FuelVehicleEngineHeadline);
            string licensePlateFromUserString = ConsoleRenderer.RenderRequestForANonEmptyString(MenuOptions.k_AskForLicensePlateMsg);

            if (s_GarageManager.Contains(licensePlateFromUserString))
            {
                ConsoleRenderer.RenderMessage(MenuOptions.k_ChargeBatteryDescription);
                string timeToChargeFromUser = Validator.InputValidatorGeneric<float>((i_MaxValue, i_UserInput) => Validator.IsNumberTypeAndInRange(i_MaxValue, i_UserInput, float.TryParse), float.MaxValue);

                try
                {
                    s_GarageManager.ChargeVehicleBattery(licensePlateFromUserString, timeToChargeFromUser);
                    ConsoleRenderer.RenderMessageAndWaitForUserEnterAnyKey(string.Format("{0} ,{1}", MenuOptions.k_ChargeEngineSuccessfullyMsg, MenuOptions.k_PressEnterToGoBackToMainMenuMsg));
                }
                catch (Exception e)
                {
                    ConsoleRenderer.RenderMessageAndWaitForUserEnterAnyKey(string.Format("{0} ,{1}", e.Message, MenuOptions.k_PressEnterToGoBackToMainMenuMsg));
                }
            }
            else
            {
                ConsoleRenderer.RenderMessageAndWaitForUserEnterAnyKey(string.Format("{0} ,{1}", MenuOptions.k_VehicleNotFoundByLicensePlateMsg, MenuOptions.k_PressEnterToGoBackToMainMenuMsg));
            }
        }

        private static void DisplayVehicleInformation()
        {
            ConsoleRenderer.RenderHeadline(MenuOptions.k_ShowVehiclePropertiesHeadline);
            string licensePlateFromUserString = ConsoleRenderer.RenderRequestForANonEmptyString(MenuOptions.k_AskForLicensePlateMsg);

            try
            {
                if (s_GarageManager.Contains(licensePlateFromUserString))
                {
                    ConsoleRenderer.RenderMessage(s_GarageManager.GetVehicleInformation(licensePlateFromUserString));
                    ConsoleRenderer.RenderMessageAndWaitForUserEnterAnyKey(MenuOptions.k_PressEnterToGoBackToMainMenuMsg);
                }
                else
                {
                    ConsoleRenderer.RenderMessageAndWaitForUserEnterAnyKey(string.Format("{0} ,{1} ", MenuOptions.k_VehicleNotFoundByLicensePlateMsg, MenuOptions.k_PressEnterToGoBackToMainMenuMsg));
                }
            }
            catch (Exception)
            {
                ConsoleRenderer.RenderMessageAndWaitForUserEnterAnyKey(string.Format("{0} ,{1} ", MenuOptions.k_VehicleNotFoundByLicensePlateMsg, MenuOptions.k_PressEnterToGoBackToMainMenuMsg));
            }
        }
    }
}
