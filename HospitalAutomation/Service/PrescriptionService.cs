using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Dto.Prescription;
using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;

namespace HospitalAutomation.Service
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public PrescriptionService(
            IPrescriptionRepository prescriptionRepository,
            IMedicalRecordRepository medicalRecordRepository)
        {
            _prescriptionRepository = prescriptionRepository;
            _medicalRecordRepository = medicalRecordRepository;
        }

        public Prescription Create(PrescriptionCreateDto dto)
        {
            var medicalRecord = _medicalRecordRepository.GetById(dto.MedicalRecordId);
            if (medicalRecord == null)
                throw new Exception("Muayene kaydı bulunamadı.");

            var existing = _prescriptionRepository.GetByMedicalRecordId(dto.MedicalRecordId);
            if (existing != null)
                throw new Exception("Bu muayene için zaten reçete oluşturulmuş.");

            var prescription = new Prescription
            {
                MedicalRecordId = dto.MedicalRecordId,
                PrescriptionCode = dto.PrescriptionCode,
                Notes = dto.Notes
            };

            _prescriptionRepository.Add(prescription);

            return prescription;
        }

        public Prescription? GetById(int id)
        {
            return _prescriptionRepository.GetById(id);
        }

        public List<Prescription> GetAll()
        {
            return _prescriptionRepository.GetAll();
        }
    }
}