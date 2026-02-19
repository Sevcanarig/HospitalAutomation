using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAutomation.Controllers
{
    
        [ApiController]
        [Route("api/departments")]
        public class DepartmentsController : ControllerBase
        {
            private readonly IDepartmentService _departmentService;
            private readonly IDoctorService _doctorService;

            public DepartmentsController(
                IDepartmentService departmentService,
                IDoctorService doctorService)
            {
                _departmentService = departmentService;
                _doctorService = doctorService;
            }

            [HttpPost]
            public IActionResult Add(Department department)
            {
                var result = _departmentService.Add(department);
                return Ok(result);
            }

            [HttpGet]
            public IActionResult GetAll()
            {
                var result = _departmentService.GetAll();
                return Ok(result);
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var department = _departmentService.GetById(id);

                if (department == null)
                    return NotFound();

                return Ok(department);
            }

            
            [HttpGet("{id}/doctors")]
            public IActionResult GetDoctorsByDepartment(int id)
            {
                var doctors = _doctorService.GetByDepartmentId(id);
                return Ok(doctors);
            }
        }
    }


