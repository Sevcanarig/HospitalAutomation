using HospitalAutomation.Entities;

namespace HospitalAutomation.DataAccess.Abstracts
{
    public interface IRoomRepository
    {
        Room Add(Room room);
        Room GetById(int id);
        List<Room> GetByDepartment(int departmentId);
    }
}
