using HospitalAutomation.Dto.MedicalRecord;
using HospitalAutomation.Entities;

namespace HospitalAutomation.DataAccess.Abstracts
{
    public interface IPatientRepository
    {
        Patient Add(Patient patient);
        Patient? GetById(int id);
        Patient? GetByTCNo(string tcNo);
        List<Patient> GetAll();
        Patient Update(Patient patient);
        void Delete(int id);
        List<MedicalRecordSimpleDto> GetPatientHistorySimple(int patientId);

    }
}
