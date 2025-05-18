using SmartHotel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Entities
{
    /// <summary>
    /// Variable temperatura.
    /// </summary>
    public class Temperature : Variable
    {
        /// <summary>
        /// Unidad de medida de la temperatura.
        /// </summary>
        public TempUnit Unit { get; set; } 

        public Temperature(Guid id, double value, double reference, TempUnit unit) : base(id, value, reference)
        {
            Unit = unit;
        }

        //Enciende el aire acondicionado
        public bool TurnOn()
        {
            if (Unit is TempUnit.Celsius)
                return Value > Reference + 2;
            else if (Unit is TempUnit.Farenheit)
                return Value > (Reference*33.8) + 2;
            else 
                return Value > (Reference+275) + 2;
        }
    }
}
