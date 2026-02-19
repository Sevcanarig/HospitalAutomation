using HospitalAutomation.Entities;

namespace HospitalAutomation.Service.Abstracts
{
    public interface IMedicalRecordService
    {
        MedicalRecord Create(MedicalRecord record);
        MedicalRecord? GetById(int id);
        List<MedicalRecord> GetAll();
        MedicalRecord? GetByAppointmentId(int appointmentId);
    }
}
