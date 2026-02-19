using HospitalAutomation.Dto.Appointment;
using HospitalAutomation.Entities;

namespace HospitalAutomation.Service.Abstracts
{
    public interface IAppointmentService
    {
        Appointment Create(AppointmentCreateDto dto);
        Appointment? GetById(int id);
        List<Appointment> GetAll();
        List<Appointment> GetTodayAppointments();
        void Cancel(int id);
    }
}
