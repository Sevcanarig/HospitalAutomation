using HospitalAutomation.Dto.Prescription;
using HospitalAutomation.Entities;

namespace HospitalAutomation.Service.Abstracts
{
    public interface IPrescriptionService
    {
        Prescription Create(PrescriptionCreateDto dto);
        Prescription? GetById(int id);
        List<Prescription> GetAll();
    }
}
