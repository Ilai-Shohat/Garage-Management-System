using System;

namespace Ex03.GarageLogic
{
    internal class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException(string i_Message, float i_MinValue, float i_MaxValue) : base(string.Format("The value you have entered for {0} is out of range, it should be between {1} - {2}", i_Message, i_MinValue, i_MaxValue))
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }

        public float MaxValue
        {
            get 
            {
                return r_MaxValue; 
            }
        }

        public float MinValue
        {
            get 
            {
                return r_MinValue; 
            }
        }
    }
}
