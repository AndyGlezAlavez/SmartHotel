using SmartHotel.Domain.Common;
using SmartHotel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.ValueObjects
{
    /// <summary>
    /// Modela un precio.
    /// </summary>
    public class Price : ValueObject
    {
        #region Properties

        /// <summary>
        /// Valor del precio.
        /// </summary>
        public double Value { get; set; } = 0;

        /// <summary>
        /// Símbolo de la moneda 
        /// </summary>
        public MoneyType MoneyType { get; set; } = MoneyType.euro;

        #endregion
       
        
        /// <summary>
        /// Requerido por Entity Framework.
        /// </summary>
        private Price() { }


        /// <summary>
        /// Inicializa un precio.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="moneyType"></param>
        public Price(double value, MoneyType moneyType)
        {
            Value = value;
            MoneyType = moneyType;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            return new object[] { Value, MoneyType };
        }

        /*public static Price Default => new(100.00, MoneyType.euro);

        // Conversión implícita con valores por defecto
        public static implicit operator Price((double, MoneyType euro) v)
        {
           return new Price(100.00, v.euro);
        }*/
    }

}
