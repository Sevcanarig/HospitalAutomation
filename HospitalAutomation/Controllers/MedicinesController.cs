using HospitalAutomation.Dto.Medicine;
using HospitalAutomation.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAutomation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineService _service;

        public MedicinesController(IMedicineService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add([FromBody] MedicineDto dto)
        {
            var medicine = _service.AddMedicine(dto);

            return Ok(new
            {
                Message = "İlaç eklendi ",
                Data = medicine
            });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var medicine = _service.GetMedicine(id);
            if (medicine == null) return NotFound(new { Message = "İlaç bulunamadı " });
            return Ok(medicine);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var medicines = _service.GetAllMedicines();
            return Ok(medicines);
        }
    }
}