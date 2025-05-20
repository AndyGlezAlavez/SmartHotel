using SmartHotel.Domain.Entities;
using SmartHotel.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using SmartHotel.Contracts.Repositories;

namespace SmartHotel.Persistence.Repositories
{
    public class RoomRepository
        : IRoomRepsoitory
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

        public async Task<IEnumerable<Room>> GetRoomByUnitAsync(Guid Id)
        {
            var room = await _context.Rooms.Include(u => u.Rooms).FirstAsync(u => u.Id == Id);
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
