using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufactorName;
        private float m_CurrentAirPressure;
        private float r_MaxAirPressureRecommended;

        public Wheel(float i_MaxAirPressureRecommended)
        {
            r_MaxAirPressureRecommended = i_MaxAirPressureRecommended;

        }
        public string ManufacturerName
        {
            get { return m_ManufactorName; }
            set { m_ManufactorName = value; } //to do exception

        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set
            {
                if (value >= 0 && value < r_MaxAirPressureRecommended)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    //to do exception of Valuseout...
                }
            }
        }

        public float MaxAirPressureRecommended
        {
            get { return r_MaxAirPressureRecommended; }




        }
         public void Inflate(float i_PSIToAdd)
        {
            if (i_PSIToAdd +  m_CurrentAirPressure <= r_MaxAirPressureRecommended)
            {
                m_CurrentAirPressure = r_MaxAirPressureRecommended;
            }
            else
            {
                // to do exception


            }
        }
    }
}
