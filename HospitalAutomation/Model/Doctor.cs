namespace HospitalAutomation.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        public int DepartmentId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Department? Department { get; set; }
    }
}
