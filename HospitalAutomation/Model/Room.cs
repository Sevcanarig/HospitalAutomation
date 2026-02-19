namespace HospitalAutomation.Entities
{
    public class Room
    {
        public int RoomId { get; set; }

        public int DepartmentId { get; set; }

        public string RoomNumber { get; set; }
        public int Capacity { get; set; }

        public Department Department { get; set; }
    }
}
