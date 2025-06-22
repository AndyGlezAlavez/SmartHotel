using FluentResults;
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

        public bool Danger { get; set; } = false;

        #endregion

        public Smoke(SmokeUnit unit, Guid id, double value, double reference, Room room) : base(id, value, reference)
        {
            Unit = unit;
            Room = room;
        }

        /// <summary>
        /// Requerido por Entity Framework.
        /// </summary>
        public Smoke(){ }

        /// <summary>
        /// Indica si la concentración de humo en la habitación supera el valor normal. 
        /// </summary>
        /// <returns></returns>
        public Result<Smoke> Create(SmokeUnit unit, Guid id, double value, double reference, Room room)
        {
            var result = CheckRules(new RoomMustBeSave(unit, value, reference));
            if (result.IsFailed)
            {
                return result.ToResult<Smoke>();
            }
            Unit = unit;
            Room = room;
            Guid Id = id;
            Value = value;
            Reference = reference;
            Danger = true;
            return Result.Ok(new Smoke(Unit, Id, Value, Reference,Room));
        }
        }
        
    }

