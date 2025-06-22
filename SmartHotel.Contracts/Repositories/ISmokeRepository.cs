using SmartHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Contracts.Repositories
{
    /// <summary>
    /// Define las funcionalidades de un repositorio de smoke.
    /// </summary>
    public interface ISmokeRepository
    {
        /// <summary>
        /// Añade una smoke a base de datos.
        /// </summary>
        Task AddAsync(Smoke smoke);
        /// <summary>
        /// Obtiene una smoke a partir de su Id.
        /// </summary>
        Task<Smoke?> GetByIdAsync(Guid id);
        /// <summary>
        /// Actualiza una smoke.
        /// </summary>
        Task<IEnumerable<Smoke>> GetSmokesAsync();
        void Update(Smoke smoke);
        /// <summary>
        /// Elimina una smoke a partir de su Id.
        /// </summary>
        void DeleteById(Guid id);
    }
}