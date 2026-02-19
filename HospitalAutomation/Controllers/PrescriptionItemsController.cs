using HospitalAutomation.Dto.PrescriptionItem;
using HospitalAutomation.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAutomation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionItemsController : ControllerBase
    {
        private readonly IPrescriptionItemService _service;

        public PrescriptionItemsController(IPrescriptionItemService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add([FromBody] PrescriptionItemDto dto)
        {
            var added = _service.AddPrescriptionItem(dto);
            return Ok(new { message = "Reçete içeriği eklendi", id = added.PrescriptionItemId });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _service.GetPrescriptionItem(id);
            if (item == null) return NotFound("Reçete içeriği bulunamadı.");
            return Ok(item);
        }
    }
}