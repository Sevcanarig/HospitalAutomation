using HospitalAutomation.Dto.Billing;
using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAutomation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IBillingService _service;

        public BillingController(IBillingService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(Billing billing)
        {
            var created = _service.Create(billing);
            return Ok(created);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("pending")]
        public IActionResult GetPending()
        {
            return Ok(_service.GetPending());
        }

        [HttpPut("{id}/pay")]
        public IActionResult MarkAsPaid(int id)
        {
            _service.MarkAsPaid(id);
            return Ok("Fatura ödendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var billing = _service.GetById(id);
            if (billing == null)
                return NotFound();

            return Ok(billing);
        }
    }
}