using SmartHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Contracts.Repositories
{
    /// <summary>
    /// Define las funcionalidades de un repositorio de temperature.
    /// </summary>
    public interface ITemperatureRepository
    {
        /// <summary>
        /// Añade una temperature a base de datos.
        /// </summary>
        Task AddAsync(Temperature temperature);
        /// <summary>
        /// Obtiene una temperature a partir de su Id.
        /// </summary>
        Task<Temperature> GetByIdAsync(Guid id);
        /// <summary>
        /// Actualiza una temperature.
        /// </summary>
        Task<IEnumerable<Temperature>> GetTemperaturesAsync();
        void Update(Temperature temperature);
        /// <summary>
        /// Elimina una temperature a partir de su Id.
        /// </summary>
        void DeleteById(Guid id);
    }
}