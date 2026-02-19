namespace HospitalAutomation.Entities
{
    public class PrescriptionItem
    {
        public int PrescriptionItemId { get; set; }

        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        public string Dosage { get; set; }
        public int Count { get; set; }
    }
}
