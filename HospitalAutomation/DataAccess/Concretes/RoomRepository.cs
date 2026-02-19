using HospitalAutomation.DataAccess.Abstracts;
using HospitalAutomation.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalAutomation.DataAccess.Concretes
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HospitalDbContext _context;

        public RoomRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public Room Add(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();

            return _context.Rooms
                .Include(r => r.Department)
                .First(r => r.RoomId == room.RoomId);
        }

        public Room GetById(int id)
        {
            return _context.Rooms
                .Include(r => r.Department)
                .FirstOrDefault(r => r.RoomId == id);
        }

        public List<Room> GetByDepartment(int departmentId)
        {
            return _context.Rooms
                .Include(r => r.Department)
                .Where(r => r.DepartmentId == departmentId)
                .ToList();
        }
    }
}