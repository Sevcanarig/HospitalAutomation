using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalAutomation.DataAccess.Concretes
{
    public class DoctorSqlRepository : IDoctorRepository
    {
        private readonly HospitalDbContext _context;

        public DoctorSqlRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public Doctor Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public List<Doctor> GetAll()
        {
            return _context.Doctors
                .Include(d => d.Department)
                .AsNoTracking()
                .ToList();
        }

        public Doctor? GetById(int id)
        {
            return _context.Doctors
                .Include(d => d.Department)
                .FirstOrDefault(d => d.DoctorId == id);
        }

        public List<Doctor> GetByDepartmentId(int departmentId)
        {
            return _context.Doctors
                .Where(d => d.DepartmentId == departmentId)
                .Include(d => d.Department)
                .AsNoTracking()
                .ToList();
        }
    }
}