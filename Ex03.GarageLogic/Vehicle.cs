using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_ModelName;
        protected readonly string r_LicensePlate;
        protected readonly Wheel[] r_Wheels;
        protected readonly Engine r_Engine;

        public Vehicle(string i_ModelName ,string i_LicensePlate, Wheel[] i_Wheels, Engine i_Engine)
        {
            if (string.IsNullOrEmpty(i_ModelName))
            {
                throw new ArgumentException("Empty model name");
            }

            r_ModelName = i_ModelName;

            if (string.IsNullOrEmpty(i_LicensePlate))
            {
                throw new ArgumentException("Empty license plate");
            }

            r_LicensePlate = i_LicensePlate;
            r_Wheels = i_Wheels;
            r_Engine = i_Engine;
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public string LicensePlate
        {
            get
            {
                return r_LicensePlate;
            }
        }

        public Wheel[] Wheels
        {
            get
            {
                return r_Wheels;
            }
        }

        public Engine Engine
        {
            get
            {
                return r_Engine;
            }
        }

        public float RemainingEnergyPercentage
        {
            get
            {
                return r_Engine.GetRemainingEnergyPercentage();
            }
        }

        public void InflateWheelsToMax()
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.InflateToMax();
            }
        }

        public abstract Dictionary<string, string[]> GetProperties();

        public abstract void SetProperties(Dictionary<string, string> i_Properties);

        public override string ToString()
        {
            StringBuilder vehicleDetailsBuilder = new StringBuilder();
            vehicleDetailsBuilder.Append("================ Vehicle Details ================\n");
            vehicleDetailsBuilder.AppendFormat("Model Name: {0}\n", r_ModelName);
            vehicleDetailsBuilder.AppendFormat("License Plate: {0}\n", r_LicensePlate);
            AppendUniqueProperties(vehicleDetailsBuilder);
            vehicleDetailsBuilder.AppendLine("================ Wheel Details ================");
            for (int i = 0; i < r_Wheels.Length; i++)
            {
                vehicleDetailsBuilder.AppendFormat(" - Wheel number {0}:\n{1}\n", i + 1, r_Wheels[i].ToString());
            }

            vehicleDetailsBuilder.AppendLine("================ Engine Details ================");
            vehicleDetailsBuilder.AppendLine(r_Engine.ToString());
            vehicleDetailsBuilder.AppendFormat("Remaining Energy Percentage: {0:F2}%\n", RemainingEnergyPercentage);

            return vehicleDetailsBuilder.ToString();
        }

        protected abstract void AppendUniqueProperties(StringBuilder sb);
    }
}
