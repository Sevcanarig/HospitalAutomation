using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalAutomation.DataAccess.Concretes
{
    public class PrescriptionSqlRepository : IPrescriptionRepository
    {
        private readonly HospitalDbContext _context;

        public PrescriptionSqlRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public Prescription Add(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            _context.SaveChanges();
            return prescription;
        }

        public Prescription? GetById(int id)
        {
            return _context.Prescriptions
                .Include(p => p.MedicalRecord)
                .ThenInclude(m => m.Appointment)
                .ThenInclude(a => a.Patient)
                .Include(p => p.MedicalRecord)
                .ThenInclude(m => m.Appointment)
                .ThenInclude(a => a.Doctor)
                .FirstOrDefault(p => p.PrescriptionId == id);
        }

        public Prescription? GetByMedicalRecordId(int medicalRecordId)
        {
            return _context.Prescriptions
                .FirstOrDefault(p => p.MedicalRecordId == medicalRecordId);
        }

        public List<Prescription> GetAll()
        {
            return _context.Prescriptions
                .Include(p => p.MedicalRecord)
                .ThenInclude(m => m.Appointment)
                .ThenInclude(a => a.Patient)
                .Include(p => p.MedicalRecord)
                .ThenInclude(m => m.Appointment)
                .ThenInclude(a => a.Doctor)
                .AsNoTracking()
                .ToList();
        }
    }
}