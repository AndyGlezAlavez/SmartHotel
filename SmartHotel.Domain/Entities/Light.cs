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
        #region Properties 

        /// <summary>
        /// Unidad de medida de la iluminación.
        /// </summary>
        public LightUnit Unit { get; set; }

        /// <summary>
        /// Indica si se está realizando o no el control en la iluminación.
        /// </summary>
        public bool TurnOn { get; set; } = false;

        /// <summary>
        /// Habitación a la que pertenece la iluminación.
        /// </summary>
        public Room Room { get; set; }

        /// <summary>
        /// Identificador de la habitación a la cual pertenece la iluminación.
        /// </summary>
        public Guid RoomId { get; set; }

        #endregion

        /// <summary>
        /// Requerido por Entity Framework.
        /// </summary>
        private Light(Guid id) : base(id) { }


        public Light(Guid id, double value, double reference, Room room, Guid roomId) : base(id, value, reference)
        {
            Unit = LightUnit.LUX;
            Room = room;
            RoomId = roomId;
        }


        
        /// <summary>
        /// Indica si están encendidas o no las luces de la habitación actualmente.
        /// </summary>
        /// <returns></returns>
        public bool LightControl()
        {
            if(!TurnOn)
                return false;
            else if (Unit == LightUnit.LUX)
                return Value < 100 * Reference;
            else if (Unit == LightUnit.Candela)
                return Value < 100 * (Reference*9);
            else
                return Value < 100 * (Reference* 0.01);
        }
          
    }
}
