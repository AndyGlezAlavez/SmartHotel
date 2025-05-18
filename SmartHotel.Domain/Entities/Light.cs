using SmartHotel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Entities
{   
    /// <summary>
    /// Variable iluminación.
    /// </summary>
    public class Light : Variable
    {
        /// <summary>
        /// Unidad de medida de la iluminación.
        /// </summary>
        public LightUnit Unit { get; set; }

        public Light(Guid id, double value, double reference) : base(id, value, reference)
        {
            Unit = LightUnit.LUX;
        }


        //*****PONER CONVERSIONES!!!!!!
        //Enciende las luces
        public bool TurnOn()
        {
            if (Unit == LightUnit.LUX)
                return Value < 100 * Reference;
            else if (Unit == LightUnit.Candela)
                return Value < 100 * (Reference*9);
            else
                return Value < 100 * (Reference* 0.01);
        }

    }
}
