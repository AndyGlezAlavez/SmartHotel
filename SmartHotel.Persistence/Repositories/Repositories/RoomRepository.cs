using SmartHotel.Contracts.Repositories;
using SmartHotel.Domain.Entities;
using SmartHotel.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace SmartHotel.Persistence.Repositories
{
    public class RoomRepository
        : IRoomRepository
    {
        private readonly AppDbContext _context;

        public RoomRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
        }

        public async void DeleteById(Guid id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room is null)
                return;
            _context.Rooms.Remove(room);
        }

        public async Task<IEnumerable<Room>> GetRoomByUnitAsync(Guid unitId)
        {
            var room = await _context.Rooms.Include(u => u.room).FirstAsync(u => u.Id == unitId);
            return room.room;
        }

        public async Task<Room> GetByIdAsync(Guid id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public void Update(Room room)
        {
            _context.Update (room);
        }
    }
}
