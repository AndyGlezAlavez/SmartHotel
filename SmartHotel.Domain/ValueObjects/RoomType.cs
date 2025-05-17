using SmartHotel.Domain.Common;
using SmartHotel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.ValueObjects
{
    public class RoomType : ValueObject
    {
        #region Properties
        /// <summary>
        /// valor del precio
        /// </summary>
        Category Category { get; set; }
        /// <summary>
        /// Simbolo de la moneda 
        /// </summary>
        Capacity Capacity { get; set; }
        #endregion
        /// <summary>
        /// Inicializa un precio
        /// </summary>
        /// <param name="Category"></param>
        /// <param name="Capacity"></param>
        public RoomType(Capacity Capacity, Category Category)
        {
            this.Category = Category;
            this.Capacity = Capacity;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            return new object[] { Category, Capacity };
        }
    }
}