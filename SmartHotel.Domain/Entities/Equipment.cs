using SmartHotel.Domain.Common;
using SmartHotel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Entities
{
    public abstract class Equipment : Entity
    {
        #region Properties

        /// <summary>
        /// nombre del equipamiento
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// Fabricante del equipamiento
        /// </summary>

        public ManufacturerName ManufacturerName { get; set; }

        // Numero de serie

        public string SerialNumber { get; set; }

        /// Valor del nodo del equipamiento
        /// 

        public string ValueNode { get; set; }

        #endregion


        public Equipment(string name, ManufacturerName manufacturerName, string serialnumber, string valuenode, Guid id) : base(id)
        {
            Name = name;
            ManufacturerName = manufacturerName;
            SerialNumber = serialnumber;
            ValueNode = valuenode;
        }
    }
}
