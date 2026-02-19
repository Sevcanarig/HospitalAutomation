using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HospitalAutomation.DataAccess.Concretes
{
    public class BillingRepository : IBillingRepository
    {
        private readonly HospitalDbContext _context;

        public BillingRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public Billing Add(Billing billing)
        {
            _context.Billings.Add(billing);
            _context.SaveChanges();
            return billing;
        }

        public Billing? GetById(int id)
        {
            return _context.Billings
                .Include(b => b.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(b => b.Appointment)
                    .ThenInclude(a => a.Doctor)
                .FirstOrDefault(b => b.BillingId == id);
        }

        
        public Billing? GetByAppointmentId(int appointmentId)
        {
            return _context.Billings
                .FirstOrDefault(b => b.AppointmentId == appointmentId);
        }

        public List<Billing> GetAll()
        {
            return _context.Billings
                .Include(b => b.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(b => b.Appointment)
                    .ThenInclude(a => a.Doctor)
                .AsNoTracking()
                .ToList();
        }

        public List<Billing> GetPending()
        {
            return _context.Billings
                .Include(b => b.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(b => b.Appointment)
                    .ThenInclude(a => a.Doctor)
                .Where(b => b.PaymentStatus == "Pending")
                .AsNoTracking()
                .ToList();
        }

        public void Update(Billing billing)
        {
            _context.Billings.Update(billing);
            _context.SaveChanges();
        }
    }
}