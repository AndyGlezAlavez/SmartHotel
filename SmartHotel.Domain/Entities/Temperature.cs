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
        #region Properties

        /// <summary>
        /// Unidad de medida de la temperatura.
        /// </summary>
        public TempUnit Unit { get; set; }

        /// <summary>
        /// Indica si se está realizando o no control en el clima.
        /// </summary>
        public bool TurnOn { get; set; } = false;  

        /// <summary>
        /// Habitación a la que pertenece la temperatura. 
        /// </summary>
        public Room Room { get; set; }

        #endregion

        /// <summary>
        /// Requerido por Entity Framework.
        /// </summary>
        private Temperature() { }


        public Temperature(Guid id, double value, double reference, TempUnit unit, Room room) : base(id, value, reference)
        {
            Unit = unit;
            Room = room;
        }

        /// <summary>
        /// Indica si está encendido o no el clima de la habitación actualmente.
        /// </summary>
        /// <returns></returns>
        public bool TemperatureControl()
        {
            if(!TurnOn)
                return false;
            else if (Unit is TempUnit.Celsius)
                return Value > Reference + 2;
            else if (Unit is TempUnit.Farenheit)
                return Value > (Reference*33.8) + 2;
            else 
                return Value > (Reference+275) + 2;
        }
    }
}
