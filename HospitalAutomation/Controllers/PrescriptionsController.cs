using HospitalAutomation.Dto.Prescription;
using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAutomation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _service;

        public PrescriptionsController(IPrescriptionService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(PrescriptionCreateDto dto)
        {
            var result = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.PrescriptionId }, result);
        }

        [HttpGet]
        public List<Prescription> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public Prescription? GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}