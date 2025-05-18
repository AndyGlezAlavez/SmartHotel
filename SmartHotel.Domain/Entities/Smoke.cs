using SmartHotel.Domain.Common;
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
        /// <summary>
        /// Unidad de medida de la concentración de humo.
        /// </summary>
        public SmokeUnit Unit { get; set; }

        public Smoke(Guid id, double value, double reference) : base(id, value, reference)
        {
            Unit = SmokeUnit.ppt;
        }
        
        
        //Alarma para cuando es detectada una concentración de humo superior a lo normal.
        public bool Danger()
        {
            if (Unit  is SmokeUnit.ppt)
                return Value > Reference;
            else
                return Value > 1000000 * Reference;
        }

        }
        
    }

