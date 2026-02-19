using HospitalAutomation.Entities;

namespace HospitalAutomation.Service.Abstracts
{
    public interface IDoctorService
    {
        Doctor Add(Doctor doctor);
        List<Doctor> GetAll();
        Doctor? GetById(int id);
        List<Doctor> GetByDepartmentId(int departmentId);
    }
}