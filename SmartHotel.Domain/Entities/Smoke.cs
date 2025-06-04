using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartHotel.Domain.Common;
using SmartHotel.Domain.Rules;
using SmartHotel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Entities
{
    /// <summary>
    /// Variable concentración de humo.
    /// </summary>
    public class Smoke : Variable
    {
        #region Properties

        /// <summary>
        /// Unidad de medida de la concentración de humo.
        /// </summary>
        public SmokeUnit Unit { get; set; }

        /// <summary>
        /// Habitación a la que pertenece la concentración de humo.
        /// </summary>
        public Room Room { get; set; }

        #endregion

        public Smoke(Guid id, double value, double reference, Room room) : base(id, value, reference)
        {
            Unit = SmokeUnit.Ppt;
            Room = room;
        }

        /// <summary>
        /// Requerido por Entity Framework.
        /// </summary>
        private Smoke(){ }

        /// <summary>
        /// Indica si la concentración de humo en la habitación supera el valor normal. 
        /// </summary>
        /// <returns></returns>
        public bool Danger()
        {
            if (Unit is SmokeUnit.Ppt)
                return Value > Reference;
            else
                return Value > 1000000 * Reference;
        }

        }
        
    }

