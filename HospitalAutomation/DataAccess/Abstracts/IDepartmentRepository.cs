using HospitalAutomation.Entities;

namespace HospitalAutomation.DataAccess.Abstracts
{
    public interface IDepartmentRepository
    {
        Department Add(Department department);
        List<Department> GetAll();
        Department? GetById(int id);

    }
}
