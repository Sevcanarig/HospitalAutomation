using HospitalAutomation.Entities;

namespace HospitalAutomation.DataAccess.Abstracts
{
        public interface IDoctorRepository
        {
            Doctor Add(Doctor doctor);
            List<Doctor> GetAll();
            Doctor? GetById(int id);
            List<Doctor> GetByDepartmentId(int departmentId);
        }
    }


