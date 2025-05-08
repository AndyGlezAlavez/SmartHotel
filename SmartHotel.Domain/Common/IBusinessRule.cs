using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Common
{
    public interface IBusinessRule
    {
        /// <summary>
        /// Valida la regla de negocio y retorna su resultado
        /// </summary>
        /// <returns></returns>
        Result CheckRule();
    }
}
