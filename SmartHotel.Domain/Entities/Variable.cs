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

        #endregion

        public Variable(Guid id, int number) : base(id)
        {
            this.number = number;
        }
    }
}
