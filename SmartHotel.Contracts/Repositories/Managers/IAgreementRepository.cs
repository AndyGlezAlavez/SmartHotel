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
    public interface IAgreementRepository
    {
        /// <summary>
        /// Añade una operación a base de datos.
        /// </summary>
        Task AddAsync(Agreement agreement);
        /// <summary>
        /// Obtiene una operación a partir de su Id.
        /// </summary>
        Task<Agreement> GetByIdAsync(Guid id);
        /// <summary>
        /// Obtiene todas las operaciones a partir de la unidad a la que pertenecen.
        /// </summary>
        Task<IEnumerable<Agreement>> GetAgreementsByUnitAsync(Guid unitId);
        /// <summary>
        /// Actualiza la información de una operación.
        /// </summary>
        void Update(Agreement agreement);
        /// <summary>
        /// Elimina una operación a partir de su Id.
        /// </summary>
        void DeleteById(Guid id);
    }
}