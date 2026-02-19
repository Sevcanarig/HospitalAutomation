using HospitalAutomation.Entities;

namespace HospitalAutomation.DataAccess.Abstracts
{
    public interface IAppointmentRepository
    {
        Appointment Add(Appointment appointment);
        Appointment? GetById(int id);
        List<Appointment> GetAll();
        List<Appointment> GetTodayAppointments();
        void Update(Appointment appointment);
    }
}
