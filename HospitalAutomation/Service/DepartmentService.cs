using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;

namespace HospitalAutomation.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public Department Add(Department department)
        {
            return _departmentRepository.Add(department);
        }

        public List<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }

        public Department? GetById(int id)
        {
            return _departmentRepository.GetById(id);
        }
    }
}


