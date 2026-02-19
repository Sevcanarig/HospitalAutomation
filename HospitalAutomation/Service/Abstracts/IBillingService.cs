using HospitalAutomation.Dto.Billing;
using HospitalAutomation.Entities;

namespace HospitalAutomation.Service.Abstracts
{
    public interface IBillingService
    {
        Billing Create(Billing billing);
        Billing? GetById(int id);
        List<Billing> GetAll();
        List<Billing> GetPending();
        void MarkAsPaid(int id);
    }
}