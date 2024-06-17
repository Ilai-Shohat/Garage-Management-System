using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_ModelName;
        protected readonly string r_LicensePlate;
        protected float m_EnergyPercentage;
        protected readonly Wheel[] r_Wheels;
        protected readonly Engine r_Engine;

        public Vehicle(string i_ModelName ,string i_LicensePlate, Wheel[] i_Wheels, Engine i_Engine)
        {
            r_ModelName = i_ModelName;
            r_LicensePlate = i_LicensePlate;
            r_Wheels = i_Wheels;
            r_Engine = i_Engine;
            //TODO: get energy percentage
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

        public void InflateWheelsToMax()
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.InflateToMax();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(
                "Vehicle\n" +
                "Model Name: {0}\n" +
                "License Plate: {1}\n" +
                "Energy Percentage: {2}%\n" +
                "Wheel Details:\n",
                r_ModelName,
                r_LicensePlate,
                m_EnergyPercentage);

            foreach (Wheel wheel in r_Wheels)
            {
                sb.AppendLine(wheel.ToString());
            }

            sb.AppendFormat("Engine Details:\n{0}", r_Engine);

            return sb.ToString();
        }
    }
}
