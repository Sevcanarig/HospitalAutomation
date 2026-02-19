using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Entities;

namespace HospitalAutomation.DataAccess.Concretes
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly HospitalDbContext _context;

        public MedicineRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Add(Medicine medicine)
        {
            _context.Medicines.Add(medicine);
            _context.SaveChanges();
        }

        public Medicine GetById(int id)
        {
            return _context.Medicines.FirstOrDefault(m => m.MedicineId == id);
        }

        public List<Medicine> GetAll()
        {
            return _context.Medicines.ToList();
        }
    }

}
