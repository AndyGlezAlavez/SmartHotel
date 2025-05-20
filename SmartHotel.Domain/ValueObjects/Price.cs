using SmartHotel.Domain.Common;
using SmartHotel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.ValueObjects
{
    public class Price : ValueObject
    {
        #region Properties

        /// <summary>
        /// Valor del precio.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Símbolo de la moneda 
        /// </summary>
        public MoneyType MoneyType { get; set; }

        #endregion
        /// <summary>
        /// Inicializa un precio.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="moneyType"></param>
        public Price(double value, MoneyType moneyType)
        {
            this.Value = value;
            this.MoneyType = moneyType;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            return new object[] { Value, MoneyType };
        }
    }
}
