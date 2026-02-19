using HospitalAutomation.Dto.PrescriptionItem;

namespace HospitalAutomation.Dto.MedicalRecord
{
    namespace HospitalAutomation.Dto.Prescription
    {
        public class MedicalRecordCreateDto
        {
            public int AppointmentId { get; set; }
            public string Diagnosis { get; set; }
            public string TreatmentPlan { get; set; }
            public DateTime CheckupDate { get; set; }
            public List<PrescriptionItemDto> PrescriptionItems { get; set; } = new List<PrescriptionItemDto>();
        }
    }
}

