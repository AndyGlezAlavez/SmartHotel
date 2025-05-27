using SmartHotel.Domain.Common;
using SmartHotel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Entities
{
    /// <summary>
    /// Variable.
    /// </summary>
    public abstract class Variable: Entity
    {

        #region Properties

        /// <summary>
        /// Valor de la variable.
        /// </summary>
       public double Value { get; set; }

        /// <summary>
        /// Valor deseado.
        /// </summary>
        public double Reference { get; set; }

        #endregion


        /// <summary>
        /// Requerido por Entity Framework.
        /// </summary>
        protected Variable() { }


        public Variable(Guid id, double value, double reference) : base(id)
        {
            Value = value;
            Reference = reference;
        }
    }
}
