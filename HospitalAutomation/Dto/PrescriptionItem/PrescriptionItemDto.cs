namespace HospitalAutomation.Dto.PrescriptionItem
{
    public class PrescriptionItemDto
    {
        public int PrescriptionId { get; set; }
        public int MedicineId { get; set; }
        public string Dosage { get; set; }
        public int Count { get; set; }
    }
}
