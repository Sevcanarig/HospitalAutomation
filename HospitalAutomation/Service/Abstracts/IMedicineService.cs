using HospitalAutomation.Dto.Medicine;
using HospitalAutomation.Entities;

namespace HospitalAutomation.Service.Abstracts
{
    public interface IMedicineService
    {
        Medicine AddMedicine(MedicineDto dto);
        Medicine GetMedicine(int id);
        List<Medicine> GetAllMedicines();
    }
}
