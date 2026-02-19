using HospitalAutomation.Entities;

namespace HospitalAutomation.DataAccess.Abstracts
{
    public interface IPrescriptionItemRepository
    {
        void Add(PrescriptionItem item);
        PrescriptionItem GetById(int id);
    }
}
