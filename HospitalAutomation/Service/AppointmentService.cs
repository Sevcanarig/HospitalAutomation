using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Dto.Appointment;
using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;

namespace HospitalAutomation.Service
{

    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public Appointment Create(AppointmentCreateDto dto)
        {
            var appointment = new Appointment
            {
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                AppointmentDate = dto.AppointmentDate,
                Complaint = dto.Complaint,
                IsCancelled = false
            };

            _repository.Add(appointment);

            return _repository.GetById(appointment.AppointmentId);
        }

        public Appointment? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Appointment> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Appointment> GetTodayAppointments()
        {
            return _repository.GetTodayAppointments();
        }

        public void Cancel(int id)
        {
            var appointment = _repository.GetById(id);
            if (appointment != null)
            {
                appointment.IsCancelled = true;
                _repository.Update(appointment);
            }
        }
    }
}