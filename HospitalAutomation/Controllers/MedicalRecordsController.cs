using HospitalAutomation.Dto.MedicalRecord;
using HospitalAutomation.Dto.MedicalRecord.HospitalAutomation.Dto.Prescription;
using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAutomation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IMedicalRecordService _service;

        public MedicalRecordsController(IMedicalRecordService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create([FromBody] MedicalRecordCreateDto dto)
        {
            try
            {
                var record = new MedicalRecord
                {
                    AppointmentId = dto.AppointmentId,
                    Diagnosis = dto.Diagnosis,
                    TreatmentPlan = dto.TreatmentPlan,
                    CheckupDate = dto.CheckupDate
                };

                var created = _service.Create(record);
                return Ok(created);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var record = _service.GetById(id);
            if (record == null) return NotFound();
            return Ok(record);
        }
    }
}
