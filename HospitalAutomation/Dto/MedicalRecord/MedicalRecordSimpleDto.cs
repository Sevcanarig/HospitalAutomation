using HospitalAutomation.Dto.PrescriptionItem;

namespace HospitalAutomation.Dto.MedicalRecord
{
    public class MedicalRecordSimpleDto
    {
        public int MedicalRecordId { get; set; }
        public string Diagnosis { get; set; }
        public string TreatmentPlan { get; set; }
        public DateTime CheckupDate { get; set; }
        public List<PrescriptionItemSimpleDto> Medicines { get; set; } = new List<PrescriptionItemSimpleDto>();
    }
}
