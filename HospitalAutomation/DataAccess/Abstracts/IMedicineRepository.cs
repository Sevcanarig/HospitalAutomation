using HospitalAutomation.Entities;

namespace HospitalAutomation.DataAccess.Abstracts
{
    public interface IMedicineRepository
    {
        void Add(Medicine medicine);
        Medicine GetById(int id);
        List<Medicine> GetAll();
    }
}
