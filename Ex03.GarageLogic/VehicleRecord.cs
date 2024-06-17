using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleRecord
    {
        private readonly string r_OwnerName;
        private readonly string r_PhoneNumber;
        private eVehicleStatus m_VehicleStatus = eVehicleStatus.InRepair;

        public VehicleRecord(string i_Name , string i_Phone) 
        {
            r_OwnerName = i_Name;
            r_PhoneNumber = i_Phone;
        }
        
        public string Name
        {
            get
            {
                return r_OwnerName;
            }
        }

        public string Phone
        {
            get
            {
                return r_PhoneNumber;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }

        public enum eVehicleStatus
        {
            InRepair = 1,
            Repaired = 2,
            PaidFor = 3,
        }
    }
   


}
