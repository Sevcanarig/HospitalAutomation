using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Dto.Room;
using HospitalAutomation.Entities;
using HospitalAutomation.Service.Abstracts;

namespace HospitalAutomation.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;

        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }

        public Room AddRoom(RoomDto dto)
        {
            var room = new Room
            {
                RoomNumber = dto.RoomNumber,
                DepartmentId = dto.DepartmentId
            };

            return _repository.Add(room);
        }

        public Room GetRoom(int id)
        {
            return _repository.GetById(id);
        }

        public List<Room> GetRoomsByDepartment(int departmentId)
        {
            return _repository.GetByDepartment(departmentId);
        }
    }
}