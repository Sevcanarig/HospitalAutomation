using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Dto.Billing;
using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;

namespace HospitalAutomation.Service
{
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _repository;

        public BillingService(IBillingRepository repository)
        {
            _repository = repository;
        }

        public Billing Create(Billing billing)
        {
            billing.PaymentStatus = "Pending";
            billing.InvoiceDate = DateTime.Now;
            return _repository.Add(billing);
        }

        public Billing? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Billing> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Billing> GetPending()
        {
            return _repository.GetPending();
        }

        public void MarkAsPaid(int id)
        {
            var billing = _repository.GetById(id);
            if (billing != null)
            {
                billing.PaymentStatus = "Paid";
                _repository.Update(billing);
            }
        }
    }
}