using HospitalAutomation.Dto.PrescriptionItem;
using HospitalAutomation.Entities;

namespace HospitalAutomation.Service.Abstracts
{
    public interface IPrescriptionItemService
    {
        PrescriptionItem AddPrescriptionItem(PrescriptionItemDto dto);
        PrescriptionItem GetPrescriptionItem(int id);
    }

}
