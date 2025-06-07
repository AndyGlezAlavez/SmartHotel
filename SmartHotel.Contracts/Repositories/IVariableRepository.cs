using SmartHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Contracts.Repositories
{
    /// <summary>
    /// Define las funcionalidades de un repositorio de variables.
    /// </summary>
    public interface IVariableRepository
    {
        /// <summary>
        /// Añade una variable a base de datos.
        /// </summary>
        Task AddAsync(Variable variable);
        /// <summary>
        /// Obtiene una variable a partir de su Id.
        /// </summary>
        Task<Variable?> GetByIdAsync(Guid id);
        /// <summary>
        /// Obtiene todas las Variables a partir de la room a la que pertenecen.
        /// </summary>
        Task<IEnumerable<Variable>> GetVariablesAsync();
        ///  Task<IEnumerable<Variable>> GetVariableByUnitAsync(Guid unitId); (Ver como se implementaria)
        /// <summary>
        /// Actualiza una variable.
        /// </summary>
        void Update(Variable variable);
        /// <summary>
        /// Elimina una variable a partir de su Id.
        /// </summary>
        void DeleteById(Guid id);
    }
}

