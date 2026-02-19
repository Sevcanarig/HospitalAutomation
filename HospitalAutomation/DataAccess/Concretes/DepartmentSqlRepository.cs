using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalAutomation.DataAccess.Concretes
{
    public class DepartmentSqlRepository : IDepartmentRepository
    {
        private readonly HospitalDbContext _context;

        public DepartmentSqlRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public Department Add(Department department)
        {
            _context.Entry(department).State = EntityState.Added;
            _context.SaveChanges();
            return department;
        }

        public List<Department> GetAll()
        {
            return _context.Departments
                .AsNoTracking()
                .ToList();
        }

        public Department? GetById(int id)
        {
            return _context.Departments.Find(id);
        }
    }
}

