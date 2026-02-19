using HospitalAutomation.Entities;

namespace HospitalAutomation.DataAccess.Abstracts
{
    public interface IPrescriptionRepository
    {
        Prescription Add(Prescription prescription);
        Prescription? GetById(int id);
        Prescription? GetByMedicalRecordId(int medicalRecordId);
        List<Prescription> GetAll();
    }
}
