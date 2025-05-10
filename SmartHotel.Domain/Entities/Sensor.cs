using SmartHotel.Domain.Types;
using SmartHotel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Entities
{
    /// <summary>
    /// Sensor.
    /// </summary>
    public class Sensor : Equipment
    {

        ///**********¡¡¡Definir el/los tipo/s de dato que modela/n la variable medida por el sensor!!!**********
        #region Properties

        ///**********¡¡¡Definir el/los tipo/s de dato que modela/n la variable medida por el sensor!!!**********

        /// <summary>
        /// Variable medida por el sensor.
        /// </summary>
        public Variable Variable{ get; set; }

        /// <summary>
        /// Valor de la variable medida por el sensor.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Señal de salida del sensor.
        /// </summary>
        public Signal OutputSignal { get; set; }

        #endregion

        //Añadir al constructor la/s propiedad/es definida/s para la variable.
        public Sensor(string name, ManufacturerName manufacturerName, string serialnumber, string valuenode, Guid id, Variable variable) : base(name, manufacturerName, serialnumber, valuenode, id)
        {
            Variable = variable;
            Value = 0;
            OutputSignal = Signal.miliAmperes;
        }

    }
}
