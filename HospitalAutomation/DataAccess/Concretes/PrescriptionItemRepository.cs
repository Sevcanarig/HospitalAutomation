using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Entities;

namespace HospitalAutomation.DataAccess.Concretes
{
    public class PrescriptionItemRepository : IPrescriptionItemRepository
    {
        private readonly HospitalDbContext _context;

        public PrescriptionItemRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Add(PrescriptionItem item)
        {
            _context.PrescriptionItems.Add(item);
            _context.SaveChanges();
        }

        public PrescriptionItem GetById(int id)
        {
            return _context.PrescriptionItems
                .FirstOrDefault(pi => pi.PrescriptionItemId == id);
        }
    }
}