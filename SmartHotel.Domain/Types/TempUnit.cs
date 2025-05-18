using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Types
{
    public enum TempUnit
    {
        /// <summary>
        /// Normal
        /// </summary>
        Celsius,

        /// <summary>
        /// 0 absoluto
        /// </summary>
        Kelivn,

        /// <summary>
        /// Usado en paises del primer mundo
        /// </summary>
        Farenheit
    }
}