using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using Microsoft.VisualBasic.FileIO;
using SmartHotel.Domain.Common;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Types;
using SmartHotel.Domain.ValueObjects;
using SmartHotel.Domain.Rules;

namespace SmartHotel.Domain.Entities
{
    /// <summary>
    /// Acuerdo de reserva de una habitación.
    /// </summary>
    public class Agreement : Entity
    {

        #region Properties

        /// <summary>
        /// Nombre del cliente.
        /// </summary>
        public string ClientName { get; set; } = string.Empty;

        /// <summary>
        /// Correo del cliente.
        /// </summary>
        public string Clientemail { get; set; } = string.Empty; //Correo se puede hacer con un IBusinessRule y que reciba un sting y lo vaya checkeando
        // Porque no esta el + @gmail.com¡¡¡¡
        /// <summary>
        /// Fecha de inicio de la reserva. 
        /// </summary>
        public DateTime StartDate { get; set; }

        
        /// <summary>
        /// Fecha final de la reserva.
        /// </summary>
        public DateTime FinalDate { get; set; }

        public Price Price { get; set; } 

        /// <summary>
        /// Habitación del acuerdo de reserva.
        /// </summary>
        public Room Room { get; set; }

        /// <summary>
        /// Identificador de la habitación del acuerdo de reserva.
        /// </summary>
        public Guid RoomId { get; set; }

        #endregion

        /// <summary>
        /// Requerido por Entity Framework.
        /// </summary>
        public Agreement() { }
      
        public Agreement(string clientname, string clientemail, DateTime startDate, DateTime finalDate, Room room, Guid id) : base(id)
        {
            ClientName = clientname;
            Clientemail = clientemail;
            StartDate = startDate;
            FinalDate = finalDate;
            Room = room;
            Price = Room.RentalPrice;
            RoomId = Room.Id;
        }

        public Result<Agreement> Create(string clientname, string clientemail, DateTime startDate, DateTime finalDate, Room room, Guid id)
        {
            var result = CheckRules(new EmailMustBeGmail(clientemail));
            if (result.IsFailed) {
            return result.ToResult<Agreement>();
            }
            var resulted = CheckRules(new DateMustBeFree(startDate, finalDate, room.Agreements));
            if (resulted.IsFailed)
            {
                return resulted.ToResult<Agreement>();
            }
            ClientName = clientname;
            Clientemail = clientemail;
            StartDate = startDate;
            FinalDate = finalDate;
            Price = Room.RentalPrice;
            Room = room;
            RoomId = Room.Id;
            Guid Id = id;

            var resultado = CheckRules(new ComparationPrice(StartDate,FinalDate, Price, Room));
            if (resultado.IsFailed)
            {
                return resultado.ToResult<Agreement>();
            }
            Room.Agreements.Add(new Agreement (ClientName, Clientemail, StartDate, FinalDate, Room, Id)); //Agregando el acuerdo a la lista

                return Result.Ok(new Agreement(ClientName, Clientemail, StartDate, FinalDate, Room, Id));
           
        }
    }
}

