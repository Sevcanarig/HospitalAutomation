using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAutomation.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        
        [HttpPost]
        public IActionResult Add(Doctor doctor)
        {
            return Ok(_doctorService.Add(doctor));
        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_doctorService.GetAll());
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var doctor = _doctorService.GetById(id);
            if (doctor == null)
                return NotFound();

            return Ok(doctor);
        }

        
        [HttpGet("department/{departmentId}")]
        public IActionResult GetByDepartmentId(int departmentId)
        {
            var doctors = _doctorService.GetByDepartmentId(departmentId);
            return Ok(doctors);
        }
    }
}