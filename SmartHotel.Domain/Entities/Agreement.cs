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
        public string Clientemail { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de inicio de la reserva. 
        /// </summary>
        public DateTime StartDate { get; set; }

        // Fecha de inicio
        public static DateTime FechaInicio { get; set; }
        
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
            Price = Room.RentalPrice;
            Room = room;
            RoomId = Room.Id;
        }

        public TimeSpan DuracionRenta()
        {
            return FinalDate - StartDate;

        }

        public Result<Agreement> Create(string clientname, string clientemail, DateTime startDate, DateTime finalDate, Room room, Guid id, Capacity capacity, Category category)
        {
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
                case 0:
                    Console.WriteLine("Opción no válida. Por favor ingrese un número entre 1 y 4.");
                    break;
                case (MoneyType)1:
                    dias *= 100;
                    Console.WriteLine("Se seleccionó la opción *1");
                    break;
                case (MoneyType)2:
                    Console.WriteLine("Se seleccionó la opción *1.2");
                    dias = dias * 100 * 1.2;
                    break;
                case (MoneyType)3:
                    Console.WriteLine("Se seleccionó la opción *380");
                    dias = dias * 100 * 380;
                    break;
                case (MoneyType)4:
                    Console.WriteLine("Se seleccionó la opción *1.5");
                    dias = dias * 100 * 1.5;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor ingrese un número entre 1 y 4.");
                    break;
            }

            // Logica para la capacidad de la habitacion

            switch (capacity)
            {
                case 0:
                    Console.WriteLine("Opción no válida. Por favor ingrese un número entre 1 y 3.");
                    break;

                    case (Capacity)1:
                    Console.WriteLine("Se seleccionó la habitacion sencilla");
                    break;

                case (Capacity)2:
                    dias *= 1.5;
                    Console.WriteLine("Se seleccionó la habitacion doble");
                    break;


                case (Capacity)3:
                    dias *= 2;
                    Console.WriteLine("Se seleccionó la habitacion familiar");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor ingrese un número entre 1 y 3.");
                    break;
            }

            // Logica para la categoria de la habitacion

            switch (category)
            {
                case 0:
                    Console.WriteLine("Opción no válida. Por favor ingrese un número entre 1 y 3.");
                    break;

                case (Category)1:
                    Console.WriteLine("Se seleccionó la habitacion estandar");
                    break;

                case (Category)2:
                    dias *= 2;
                    Console.WriteLine("Se seleccionó la habitacion suite");
                    break;


                case (Category)3:
                    dias *= 5;
                    Console.WriteLine("Se seleccionó la habitacion vip");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor ingrese un número entre 1 y 3.");
                    break;
            }
            Price.Value = dias;

            // Logica para comprobar el precio
            if (Price.Value > Room.RentalPrice.Value)
            {
                return Result.Fail<Agreement>("Debe pagar una monto mayor");
            }

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

