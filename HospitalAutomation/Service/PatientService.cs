using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Dto.MedicalRecord;
using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;

namespace HospitalAutomation.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Patient Add(Patient patient)
        {
            var existing = _patientRepository.GetByTCNo(patient.TCNo);
            if (existing != null)
                throw new Exception("Bu TCNo zaten kayıtlı!");

            return _patientRepository.Add(patient);
        }

        public Patient? GetById(int id)
        {
            return _patientRepository.GetById(id);
        }

        public Patient? GetByTCNo(string tcNo)
        {
            return _patientRepository.GetByTCNo(tcNo);
        }

        public List<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public Patient? Update(int id, Patient patient)
        {
            var existing = _patientRepository.GetById(id);
            if (existing == null)
                return null;

            existing.TCNo = patient.TCNo;
            existing.FirstName = patient.FirstName;
            existing.LastName = patient.LastName;
            existing.BirthDate = patient.BirthDate;
            existing.Gender = patient.Gender;
            existing.Phone = patient.Phone;
            existing.Address = patient.Address;

            return _patientRepository.Update(existing);
        }

        public void Delete(int id)
        {
            _patientRepository.Delete(id);
        }

        public List<MedicalRecordSimpleDto> GetPatientHistorySimple(int patientId)
        {
            var history = _patientRepository.GetPatientHistorySimple(patientId);

            return history
                .Where(x => x.CheckupDate != DateTime.MinValue) 
                .OrderByDescending(x => x.CheckupDate)          
                .ToList();
        }
    }
}