using SmartHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Contracts.Repositories
{
    /// <summary>
    /// Define las funcionalidades de un repositorio de operación.
    /// </summary>
    public interface IRoomRepsoitory
    {
        /// <summary>
        /// Añade un dispositivo de automatización a base de datos.
        /// </summary>
        Task AddAsync(Room room);
        /// <summary>
        /// Obtiene un dispositivo de automatización a partir de su Id.
        /// </summary>
        Task<Room> GetByIdAsync(Guid id);
        /// <summary>
        /// Obtiene todos los dispositivos de automatización a partir de la unidad a la que se relacionan.
        /// </summary>
        Task<IEnumerable<Room>> GetRoomByUnitAsync(Guid unitId);
        /// <summary>
        /// Actualiza la información de un dispositivo de automatización.
        /// </summary>
        void Update(Room room);
        /// <summary>
        /// Elimina un dispositivo de automatización a partir de su Id.
        /// </summary>
        void DeleteById(Guid id);
    }
}
