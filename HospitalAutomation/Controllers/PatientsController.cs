using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAutomation.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        [HttpPost]
        public Patient Add(Patient patient)
        {
            return _service.Add(patient);
        }

        [HttpGet]
        public List<Patient> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public Patient? GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpGet("tc/{tcNo}")]
        public Patient? GetByTCNo(string tcNo)
        {
            return _service.GetByTCNo(tcNo);
        }

        [HttpPut("{id}")]
        public Patient? Update(int id, Patient patient)
        {
            return _service.Update(id, patient);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
        [HttpGet("{id}/history")]
        public IActionResult GetPatientHistory(int id)
        {
            var history = _service.GetPatientHistorySimple(id);
            return Ok(history);
        }
    }
    }

