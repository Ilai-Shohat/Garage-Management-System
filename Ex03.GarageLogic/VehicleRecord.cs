using System.Text;

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

        public override string ToString()
        {
            StringBuilder vehicleRecordDetails = new StringBuilder();
            vehicleRecordDetails.Append("================ Vehicle Record Details ================\n");
            vehicleRecordDetails.AppendFormat("Owner Name: {0}\n", r_OwnerName);
            vehicleRecordDetails.AppendFormat("Phone Number: {0}\n", r_PhoneNumber);
            vehicleRecordDetails.AppendFormat("Vehicle Status: {0}\n", m_VehicleStatus.ToString());

            return vehicleRecordDetails.ToString();
        }
        public enum eVehicleStatus
        {
            InRepair = 1,
            Repaired = 2,
            PaidFor = 3,
        }
    }
    
}
