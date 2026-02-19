using HospitalAutomation.Entities;

namespace HospitalAutomation.DataAccess.Abstracts
{
    public interface IBillingRepository
    {
        Billing Add(Billing billing);
        Billing? GetById(int id);
        List<Billing> GetAll();
        Billing? GetByAppointmentId(int appointmentId);
        List<Billing> GetPending();
        void Update(Billing billing);


    }
}
