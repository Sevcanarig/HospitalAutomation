using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;

namespace HospitalAutomation.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Doctor Add(Doctor doctor)
        {
            return _doctorRepository.Add(doctor);
        }

        public List<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }

        public Doctor? GetById(int id)
        {
            return _doctorRepository.GetById(id);
        }

        public List<Doctor> GetByDepartmentId(int departmentId)
        {
            return _doctorRepository.GetByDepartmentId(departmentId);
        }
    }
}