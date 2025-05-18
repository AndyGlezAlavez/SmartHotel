using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Types
{
    public enum Capacity
    {
        /// <summary>
        /// 1 persona en una habitación.
        /// </summary>
        Sencilla,

        /// <summary>
        /// 2 personas en una habitación.
        /// </summary>
        Doble,
        /// <summary>
        /// +2 personas en una habitación.
        /// </summary>
        Familiar
    }
}