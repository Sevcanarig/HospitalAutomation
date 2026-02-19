using HospitalAutomation.Entities;

namespace HospitalAutomation.DataAccess.Abstracts
{
    public interface IMedicalRecordRepository
    {
        MedicalRecord Add(MedicalRecord record);
        MedicalRecord? GetById(int id);
        List<MedicalRecord> GetAll();
        MedicalRecord? GetByAppointmentId(int appointmentId);
    }
}
