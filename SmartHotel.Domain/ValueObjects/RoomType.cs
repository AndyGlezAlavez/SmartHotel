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
        /// Categoría de la habitación.
        /// </summary>
        public Category Category { get; set; } = Category.Estandar;

        /// <summary>
        /// Capacidad de la habitación.
        /// </summary>
        public Capacity Capacity { get; set; }= Capacity.Sencilla;

        #endregion

        /// <summary>
        /// Inicializa un tipo de habitación.
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

        public static RoomType Default => new (Capacity.Sencilla, Category.Estandar);

        // Conversión implícita con valores por defecto
        public static implicit operator RoomType((Capacity sencilla, Category estandar) v)
        {
            return new RoomType(v.sencilla, v.estandar);
        }
    }
}