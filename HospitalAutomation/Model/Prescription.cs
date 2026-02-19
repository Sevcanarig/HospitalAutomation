namespace HospitalAutomation.Entities
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }

        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }

        public string PrescriptionCode { get; set; }
        public string Notes { get; set; }
        public List<PrescriptionItem> PrescriptionItems { get; set; } = new List<PrescriptionItem>();
    }
}
