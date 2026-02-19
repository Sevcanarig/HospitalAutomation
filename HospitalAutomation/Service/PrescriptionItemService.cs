using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Dto.PrescriptionItem;
using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;

namespace HospitalAutomation.Service
{
    public class PrescriptionItemService : IPrescriptionItemService
    {
        private readonly IPrescriptionItemRepository _repository;
        private readonly IMedicineRepository _medicineRepository;

        public PrescriptionItemService(IPrescriptionItemRepository repository, IMedicineRepository medicineRepository)
        {
            _repository = repository;
            _medicineRepository = medicineRepository;
        }

        public PrescriptionItem AddPrescriptionItem(PrescriptionItemDto dto)
        {
            
            var medicine = _medicineRepository.GetById(dto.MedicineId);
            if (medicine == null)
            {
                throw new Exception($"MedicineId {dto.MedicineId} veritabanında bulunamadı.");
            }

            var item = new PrescriptionItem
            {
                PrescriptionId = dto.PrescriptionId,
                MedicineId = dto.MedicineId,
                Dosage = dto.Dosage,
                Count = dto.Count
            };

            _repository.Add(item);
            return item;
        }

        public PrescriptionItem GetPrescriptionItem(int id)
        {
            return _repository.GetById(id);
        }
    }
}