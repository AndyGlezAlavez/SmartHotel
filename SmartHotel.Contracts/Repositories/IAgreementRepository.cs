using SmartHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Contracts.Repositories
{
    /// <summary>
    /// Define las funcionalidades de un repositorio de agreement.
    /// </summary>
    public interface IAgreementRepository
    {
        /// <summary>
        /// Añade un agreement a base de datos.
        /// </summary>
        Task AddAsync(Agreement agreement);
        /// <summary>
        /// Obtiene un agreement a partir de su Id.
        /// </summary>
        Task<Agreement> GetAgreementsByIdAsync(Guid id);
        /// <summary>
        /// Obtiene todas los agreement a partir de la room a la que pertenecen.
        /// </summary>
        Task<IEnumerable<Agreement>> GetAgreementsByUnitAsync(Guid unitId);
        /// <summary>
        /// Actualiza la información de un agreement.
        /// </summary>
        void Update(Agreement agreement);
        /// <summary>
        /// Elimina un agreement a partir de su Id.
        /// </summary>
        void DeleteById(Guid id);
    }
}