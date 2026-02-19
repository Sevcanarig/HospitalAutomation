using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Dto.Medicine;
using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;

namespace HospitalAutomation.Service
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _repository;

        public MedicineService(IMedicineRepository repository)
        {
            _repository = repository;
        }

        public Medicine AddMedicine(MedicineDto dto)
        {
            var medicine = new Medicine
            {
                Name = dto.Name,
                Type = dto.Type,
                Price = dto.Price
            };

            _repository.Add(medicine);
            return medicine;
        }

        public Medicine GetMedicine(int id)
        {
            return _repository.GetById(id);
        }

        public List<Medicine> GetAllMedicines()
        {
            return _repository.GetAll();
        }
    }
}