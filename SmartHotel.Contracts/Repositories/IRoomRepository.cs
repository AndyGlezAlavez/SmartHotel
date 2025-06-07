using SmartHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Contracts.Repositories
{
    /// <summary>
    /// Define las funcionalidades de un repositorio de room.
    /// </summary>
    public interface IRoomRepsoitory
    {
        /// <summary>
        /// Añade una room a base de datos.
        /// </summary>
        Task AddAsync(Room room);
        /// <summary>
        /// Obtiene una room a partir de su Id.
        /// </summary>
        Task<Room> GetByIdAsync(Guid id);
        /// <summary>
        /// Actualiza una room.
        /// </summary>
        Task<IEnumerable<Room>> GetRoomsAsync();
        void Update(Room room);
        /// <summary>
        /// Elimina una room a partir de su Id.
        /// </summary>
        void DeleteById(Guid id);
    }
}
