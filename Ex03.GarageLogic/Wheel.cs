using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressure = 0;
        private readonly float r_MaxAirPressureRecommended;

        public Wheel(string i_ManufacturerName, string i_CurrentAirPressure, float i_MaxAirPressureRecommended)
        {
            if (string.IsNullOrEmpty(i_ManufacturerName))
            {
                throw new ArgumentException("Empty manufacturer name");
            }

            r_ManufacturerName = i_ManufacturerName;
            r_MaxAirPressureRecommended = i_MaxAirPressureRecommended;
            Inflate(i_CurrentAirPressure);
        }

        public string ManufacturerName
        {
            get 
            { 
                return r_ManufacturerName; 
            }
        }

        public float CurrentAirPressure
        {
            get 
            { 
                return m_CurrentAirPressure; 
            }
        }

        public float MaxAirPressureRecommended
        {
            get 
            {
                return r_MaxAirPressureRecommended;
            }
        }
        public void Inflate(string i_PSIToAdd)
        {
            if(!float.TryParse(i_PSIToAdd, out float PSIToAdd))
            {
                throw new FormatException("Invalid type for PSI to add");
            }
            else if (PSIToAdd > 0 && PSIToAdd +  m_CurrentAirPressure <= r_MaxAirPressureRecommended)
            {
                m_CurrentAirPressure += PSIToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException("inflating the wheel", 0, MaxAirPressureRecommended - CurrentAirPressure);
            }
        }

        public void InflateToMax()
        {
            Inflate((r_MaxAirPressureRecommended - m_CurrentAirPressure).ToString());
        }

        public override string ToString()
        {
            string wheelDetails = string.Format(
                "    Manufacturer Name: {0}\n" +
                "    Current Air Pressure: {1} PSI\n" +
                "    Max Air Pressure Recommended: {2} PSI",
                r_ManufacturerName,
                m_CurrentAirPressure,
                r_MaxAirPressureRecommended);

            return wheelDetails;
        }
    }
}
