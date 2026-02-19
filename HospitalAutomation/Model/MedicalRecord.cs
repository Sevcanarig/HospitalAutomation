namespace HospitalAutomation.Entities
{
    public class MedicalRecord
    {
        public int MedicalRecordId { get; set; }

        public int AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }

        public string Diagnosis { get; set; } = string.Empty;
        public string TreatmentPlan { get; set; } = string.Empty;
        public DateTime CheckupDate { get; set; }
        public List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
