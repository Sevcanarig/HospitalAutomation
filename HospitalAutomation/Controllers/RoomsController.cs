using HospitalAutomation.Dto.Room;
using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAutomation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomsController(IRoomService service)
        {
            _service = service;
        }

        
        [HttpPost]
        public IActionResult Add([FromBody] RoomDto dto)
        {
            var room = _service.AddRoom(dto);

            return Ok(new
            {
                message = "Oda eklendi.",
                room
            });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var room = _service.GetRoom(id);
            if (room == null)
                return NotFound("Oda bulunamadı.");

            return Ok(room);
        }

        [HttpGet("department/{departmentId}")]
        public IActionResult GetByDepartment(int departmentId)
        {
            var rooms = _service.GetRoomsByDepartment(departmentId);
            return Ok(rooms);
        }
    }
}