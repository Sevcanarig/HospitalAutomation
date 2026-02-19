using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;
using System;
using System.Collections.Generic;

namespace HospitalAutomation.Service
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        private readonly IBillingRepository _billingRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public MedicalRecordService(
            IMedicalRecordRepository medicalRecordRepository,
            IBillingRepository billingRepository,
            IAppointmentRepository appointmentRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
            _billingRepository = billingRepository;
            _appointmentRepository = appointmentRepository;
        }

        public MedicalRecord Create(MedicalRecord record)
        {
            
            var existingRecord = _medicalRecordRepository.GetByAppointmentId(record.AppointmentId);
            if (existingRecord != null)
                throw new Exception("Bu randevu için zaten bir muayene kaydı mevcut.");

            record.Appointment = null;

            
            var savedRecord = _medicalRecordRepository.Add(record);

           
            var appointment = _appointmentRepository.GetById(record.AppointmentId);
            if (appointment == null)
                throw new Exception("Randevu bulunamadı.");

            
            var existingBilling =
                _billingRepository.GetByAppointmentId(record.AppointmentId);

            if (existingBilling == null)
            {
                var billing = new Billing
                {
                    PatientId = appointment.PatientId,
                    AppointmentId = record.AppointmentId,
                    TotalAmount = 500,
                    PaymentStatus = "Pending",
                    InvoiceDate = DateTime.Now
                };

                _billingRepository.Add(billing);
            }

           
            savedRecord.Appointment = appointment;

            return savedRecord;
        }

        public MedicalRecord? GetById(int id)
        {
            return _medicalRecordRepository.GetById(id);
        }

        public MedicalRecord? GetByAppointmentId(int appointmentId)
        {
            return _medicalRecordRepository.GetByAppointmentId(appointmentId);
        }

        public List<MedicalRecord> GetAll()
        {
            return _medicalRecordRepository.GetAll();
        }
    }
}