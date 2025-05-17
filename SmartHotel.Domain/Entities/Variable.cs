using SmartHotel.Domain.Common;
using SmartHotel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Entities
{
    public abstract class Variable: Entity, IActuador, ISensor
    {

        #region Properties
        /// <summary>
        /// valor
        /// </summary>
        int Number { get; set; }
        /// <summary>
        /// Valor deseado
        /// </summary>
        int Reference { get; set; }

        string IActuador.TipoSeñalEntrada => throw new NotImplementedException();

        bool IActuador.Estado { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        string ISensor.NombreVariable => throw new NotImplementedException();

        string ISensor.UnidadMedida => throw new NotImplementedException();

        double ISensor.ValorMedido { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        string ISensor.TipoSeñalSalida => throw new NotImplementedException();
        #endregion

        public Variable(Guid id, int number, int reference) : base(id)
        {
            this.Number = number;
            this.Reference = reference;
        }
        public int Getnumber( ) => Number;
        public int Getreference( ) => Reference;
    }
}
