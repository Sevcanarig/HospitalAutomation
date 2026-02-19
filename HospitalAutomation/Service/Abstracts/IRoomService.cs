using HospitalAutomation.Dto.Room;
using HospitalAutomation.Entities;

namespace HospitalAutomation.Service.Abstracts
{
    public interface IRoomService
    {
        Room AddRoom(RoomDto dto);
        Room GetRoom(int id);
        List<Room> GetRoomsByDepartment(int departmentId);
    }
}
