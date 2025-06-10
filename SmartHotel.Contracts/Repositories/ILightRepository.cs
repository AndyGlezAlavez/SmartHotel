using SmartHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Contracts.Repositories
{
    /// <summary>
    /// Define las funcionalidades de un repositorio de light.
    /// </summary>
    public interface ILightRepository
    {
        /// <summary>
        /// Añade una light a base de datos.
        /// </summary>
        Task AddAsync(Light light);
        /// <summary>
        /// Obtiene una light a partir de su Id.
        /// </summary>
        Task<Light> GetByIdAsync(Guid id);
        /// <summary>
        /// Actualiza una light.
        /// </summary>
        Task<IEnumerable<Light>> GetLightsAsync();
        void Update(Light light);
        /// <summary>
        /// Elimina una light a partir de su Id.
        /// </summary>
        void DeleteById(Guid id);
    }
}