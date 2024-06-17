namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufactorName;
        private float m_CurrentAirPressure = 0;
        private readonly float r_MaxAirPressureRecommended;

        public Wheel(float i_MaxAirPressureRecommended)
        {
            r_MaxAirPressureRecommended = i_MaxAirPressureRecommended;

        }
        public string ManufacturerName
        {
            get 
            { 
                return r_ManufactorName; 
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
        public void Inflate(float i_PSIToAdd)
        {
            if (i_PSIToAdd > 0 && i_PSIToAdd +  m_CurrentAirPressure <= r_MaxAirPressureRecommended)
            {
                m_CurrentAirPressure = r_MaxAirPressureRecommended;
            }
            else
            {
                throw new ValueOutOfRangeException("inflating the wheel", 0, MaxAirPressureRecommended - CurrentAirPressure);
            }
        }

        public void InflateToMax()
        {
            Inflate(r_MaxAirPressureRecommended - m_CurrentAirPressure);
        }

        public override string ToString()
        {
            string details = string.Format(
                "Wheel\n" +
                "Manufacturer Name: {0}\n" +
                "Current Air Pressure: {1} PSI\n" +
                "Max Air Pressure Recommended: {2} PSI",
                r_ManufactorName,
                m_CurrentAirPressure,
                r_MaxAirPressureRecommended);

            return details;
        }
    }
}
