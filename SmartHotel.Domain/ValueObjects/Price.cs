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
        /// valor del precio
        /// </summary>
        double value;
        /// <summary>
        /// Simbolo de la moneda 
        /// </summary>
        MoneyType moneyType;
        #endregion
        /// <summary>
        /// Inicializa un precio
        /// </summary>
        /// <param name="value"></param>
        /// <param name="moneyType"></param>
        public Price(double value, MoneyType moneyType)
        {
            this.value = value;
            this.moneyType = moneyType;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            return new object[] { value, moneyType };
        }
    }

}
