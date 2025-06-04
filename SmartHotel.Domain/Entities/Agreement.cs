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
        private Agreement() { }
      
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

        public TimeSpan DuracionRenta()
        {
            return FinalDate - StartDate;

        }

        public Result<Agreement> Create(string clientname, string clientemail, DateTime startDate, DateTime finalDate, Room room, Guid id, Capacity capacity, Category category)
        {
            var result = CheckRules(new EmailMustBeGmail(clientemail));
            if (result.IsFailed) {
            return result.ToResult<Agreement>();
            }
            ClientName = clientname;
            Clientemail = clientemail;
            StartDate = startDate;
            FinalDate = finalDate;
            Price = Room.RentalPrice;
            Room = room;
            RoomId = Room.Id;
            Guid Id = id;

            // Obtener la duración de la renta en días.
            TimeSpan duracion = DuracionRenta();

            // Se utiliza la propiedad .Days para obtener los días completos.
            double dias = duracion.Days;

            //Logica para generar el precio
            switch (Price.MoneyType)
            {
                case (MoneyType.Euro):
                    dias *= 100;
                    Console.WriteLine("Se seleccionó la opción *1");
                    break;
                case (MoneyType.USD):
                    Console.WriteLine("Se seleccionó la opción *1.2");
                    dias = dias * 100 * 1.2;
                    break;
                case (MoneyType.Peso):
                    Console.WriteLine("Se seleccionó la opción *380");
                    dias = dias * 100 * 380;
                    break;
                case (MoneyType.MLC):
                    Console.WriteLine("Se seleccionó la opción *1.5");
                    dias = dias * 100 * 1.5;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor ingrese un número entre 0 y 3.");
                    break;
            }

            // Logica para la capacidad de la habitacion
            switch (capacity)
            {
                case (Capacity.Sencilla):
                    Console.WriteLine("Se seleccionó la habitacion sencilla");
                    break;

                case (Capacity.Doble):
                    dias *= 1.5;
                    Console.WriteLine("Se seleccionó la habitacion doble");
                    break;


                case (Capacity.Familiar):
                    dias *= 2;
                    Console.WriteLine("Se seleccionó la habitacion familiar");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor ingrese un número entre 0 y 2.");
                    break;
            }

            // Logica para la categoria de la habitacion

            switch (category)
            {
                case (Category.Estandar):
                    Console.WriteLine("Se seleccionó la habitacion estandar");
                    break;

                case (Category.Suit):
                    dias *= 2;
                    Console.WriteLine("Se seleccionó la habitacion suite");
                    break;

                case (Category.VIP):
                    dias *= 5;
                    Console.WriteLine("Se seleccionó la habitacion vip");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor ingrese un número entre 0 y 2.");
                    break;
            }
            Price.Value = dias;

            // Logica para comprobar el precio
            var resultado = CheckRules(new ComparationPrice(Price.Value, Room.RentalPrice.Value));
            if (resultado.IsFailed)
            {
                return result.ToResult<Agreement>();
            }

            //var resuelto = CheckRules(new DateMustBeFree())
            // logica para ver si se puede rentar
            bool analisys = room.IsRentabled(StartDate, FinalDate);
            if (!analisys)
            {
                return Result.Fail<Agreement>("La habitacion se encuentra rentada en la fecha seleccionada");
            }
            else
            {
                return Result.Ok(new Agreement(ClientName, Clientemail, StartDate, FinalDate, Room, Id));
            }
        }
    }
}

