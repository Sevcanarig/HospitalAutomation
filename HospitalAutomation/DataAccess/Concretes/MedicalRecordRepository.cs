using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAutomation.DataAccess.Concretes
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly HospitalDbContext _context;

        public MedicalRecordRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public MedicalRecord Add(MedicalRecord record)
        {
            _context.MedicalRecords.Add(record);
            _context.SaveChanges();
            return record;
        }

        public MedicalRecord? GetById(int id)
        {
            return _context.MedicalRecords
                .Include(m => m.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(m => m.Appointment)
                    .ThenInclude(a => a.Doctor)
                        .ThenInclude(d => d.Department)
                .FirstOrDefault(m => m.MedicalRecordId == id);
        }

        public List<MedicalRecord> GetAll()
        {
            return _context.MedicalRecords
                .Include(m => m.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(m => m.Appointment)
                    .ThenInclude(a => a.Doctor)
                        .ThenInclude(d => d.Department)
                .AsNoTracking()
                .ToList();
        }

        
        public MedicalRecord? GetByAppointmentId(int appointmentId)
        {
            return _context.MedicalRecords
                .Include(m => m.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(m => m.Appointment)
                    .ThenInclude(a => a.Doctor)
                        .ThenInclude(d => d.Department)
                .FirstOrDefault(m => m.AppointmentId == appointmentId);
        }
    }
}
