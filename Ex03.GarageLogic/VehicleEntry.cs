namespace Ex03.GarageLogic
{
    public class VehicleEntry
    {
        private readonly Vehicle r_Vehicle;
        private readonly VehicleRecord r_VehicleRecord;

        public VehicleEntry(Vehicle i_Vehicle, VehicleRecord i_VehicleRecord)
        {
            r_Vehicle = i_Vehicle;
            r_VehicleRecord = i_VehicleRecord;
        }

        public Vehicle Vehicle
        {
            get { return r_Vehicle; }
        }

        public VehicleRecord VehicleRecord
        {
            get { return r_VehicleRecord; }
        }

        public override string ToString()
        {
            
            return r_Vehicle.ToString() + r_VehicleRecord.ToString();
        }
    }
}
