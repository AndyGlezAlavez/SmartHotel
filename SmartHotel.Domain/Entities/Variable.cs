using SmartHotel.Domain.Common;
using SmartHotel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Entities
{
    public class Variable: Entity
    {

        #region Properties
        /// <summary>
        /// valor
        /// </summary>
        int number { get; set; }
        /// <summary>
        /// Valor deseado
        /// </summary>
        int reference { get; set; }
        #endregion

        public Variable(Guid id, int number, int reference) : base(id)
        {
            this.number = number;
            this.reference = reference;
        }
    }
}
