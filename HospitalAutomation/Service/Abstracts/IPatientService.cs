using HospitalAutomation.Dto.MedicalRecord;
using HospitalAutomation.Entities;

namespace HospitalAutomation.Service.Abstracts
{
    public interface IPatientService
    {
        Patient Add(Patient patient);
        Patient? GetById(int id);
        Patient? GetByTCNo(string tcNo);
        List<Patient> GetAll();
        Patient? Update(int id, Patient patient);
        void Delete(int id);
        List<MedicalRecordSimpleDto> GetPatientHistorySimple(int patientId);
    }
}