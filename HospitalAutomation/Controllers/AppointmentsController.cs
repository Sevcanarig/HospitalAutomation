using HospitalAutomation.Dto.Appointment;
using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAutomation.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(IAppointmentService service)
        {
            _service = service;
        }

        
        [HttpPost]
        public IActionResult Create(AppointmentCreateDto dto)
        {
            var result = _service.Create(dto);
            return Ok(result);
        }

        [HttpGet]
        public List<Appointment> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("today")]
        public List<Appointment> GetToday()
        {
            return _service.GetTodayAppointments();
        }

        [HttpPatch("{id}/cancel")]
        public void Cancel(int id)
        {
            _service.Cancel(id);
        }

        [HttpGet("{id}")]
        public Appointment? GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}

