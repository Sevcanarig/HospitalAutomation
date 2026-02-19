using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalAutomation.DataAccess.Concretes
{
    public class AppointmentSqlRepository : IAppointmentRepository
    {
        private readonly HospitalDbContext _context;

        public AppointmentSqlRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public Appointment Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return appointment;
        }

        public Appointment? GetById(int id)
        {
            return _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.Department) 
                .FirstOrDefault(a => a.AppointmentId == id);
        }

        public List<Appointment> GetAll()
        {
            return _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.Department) 
                .AsNoTracking()
                .ToList();
        }

        public List<Appointment> GetTodayAppointments()
        {
            var today = DateTime.Today;
            return _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.Department) 
                .Where(a => a.AppointmentDate.Date == today && !a.IsCancelled)
                .ToList();
        }

        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }
    }
}
