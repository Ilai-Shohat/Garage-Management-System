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

            string details = string.Format(
                "Vehicle Record\n" +
                "Owner Name: {0}\n" +
                "Phone Number: {1}\n" +
                "Vehicle Status: {2}",
                r_OwnerName,
                r_PhoneNumber,
                m_VehicleStatus);

            return details;
        }

        public enum eVehicleStatus
        {
            InRepair = 1,
            Repaired = 2,
            PaidFor = 3,
        }
    }
}
