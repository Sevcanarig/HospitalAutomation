using HospitalAutomation.Dto.PrescriptionItem;
using System.ComponentModel.DataAnnotations;

namespace HospitalAutomation.Dto.Prescription
{
    public class PrescriptionCreateDto
    {
        [Required]
        public int MedicalRecordId { get; set; }

        [Required]
        public string PrescriptionCode { get; set; }

        public string Notes { get; set; }

        
    }
}
