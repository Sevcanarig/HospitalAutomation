using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Dto.MedicalRecord;
using HospitalAutomation.Dto.MedicalRecord.HospitalAutomation.Dto.Prescription;
using HospitalAutomation.Dto.PrescriptionItem;
using HospitalAutomation.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalAutomation.DataAccess.Concretes
{
    public class PatientSqlRepository : IPatientRepository
    {
        private readonly HospitalDbContext _context;

        public PatientSqlRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public Patient Add(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient;
        }

        public Patient? GetById(int id)
        {
            return _context.Patients.Find(id);
        }

        public Patient? GetByTCNo(string tcNo)
        {
            return _context.Patients
                .FirstOrDefault(p => p.TCNo == tcNo);
        }

        public List<Patient> GetAll()
        {
            return _context.Patients
                .AsNoTracking()
                .ToList();
        }

        public Patient Update(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
            return patient;
        }

        public void Delete(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }
        public List<MedicalRecordSimpleDto> GetPatientHistorySimple(int patientId)
        {
            return _context.MedicalRecords
                .Include(m => m.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(m => m.Appointment)
                    .ThenInclude(a => a.Doctor)
                        .ThenInclude(d => d.Department)
                .Include(m => m.Prescriptions)
                    .ThenInclude(p => p.PrescriptionItems)
                        .ThenInclude(pi => pi.Medicine) 
                .Where(m => m.Appointment.PatientId == patientId)
                .OrderByDescending(m => m.CheckupDate)
                .AsNoTracking()
                .Select(m => new MedicalRecordSimpleDto
                {
                    MedicalRecordId = m.MedicalRecordId,
                    Diagnosis = m.Diagnosis,
                    TreatmentPlan = m.TreatmentPlan,
                    CheckupDate = m.CheckupDate,
                    Medicines = m.Prescriptions
                                .SelectMany(p => p.PrescriptionItems)
                                .Select(pi => new PrescriptionItemSimpleDto
                                {
                                    MedicineName = pi.Medicine.Name,
                                    Dosage = pi.Dosage,
                                    Count = pi.Count
                                }).ToList()
                })
                .ToList();
        }
    }
}