using HospitalAutomation.Entities;

namespace HospitalAutomation.Service.Abstracts
{
    public interface IDepartmentService
    {
        Department Add(Department department);
        List<Department> GetAll();
        Department? GetById(int id);
    }
}
