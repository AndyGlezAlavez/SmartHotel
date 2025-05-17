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
    public class Agreement : Entity
    {
        #region Properties

        /// Nombre del cliente 
        /// 

        public static string ClientName { get; set; }

        /// Correo del cliente
        /// 
        public static string Clientemail { get; set; }

        // Fecha de inicio
        public static DateTime FechaInicio { get; set; }

        // Fecha final

        public static DateTime FechaFinal { get; set; }

        //Precio pagado 
        public static MoneyType MoneyType { get; set; }

        public static double Cash { get; set; }

        // Habitacion seleccionada

        public static Room Room { get; set; }

        #endregion


        protected Agreement(string clientname, string clientemail, DateTime fechaInicio, DateTime fechaFinal, MoneyType moneytype, double cash, Room room, Guid id) : base(id)
        {
            ClientName = clientname;
            Clientemail = clientemail;
            FechaInicio = fechaInicio;
            FechaFinal = fechaFinal;
            MoneyType = moneytype;
            Cash = cash;
            Room = room;
        }

        public static TimeSpan DuracionRenta()
        {
            return FechaFinal - FechaInicio;

        }

        public static Result<Agreement> Create(string clientname, string clientemail, DateTime fechaInicio, DateTime fechaFinal, MoneyType moneytype, double cash, Room room, Guid id)
        {
            ClientName = clientname;
            Clientemail = clientemail;
            FechaInicio = fechaInicio;
            FechaFinal = fechaFinal;
            MoneyType = moneytype;
            Cash = cash;
            Room = room;
            Guid Id = id;

            // Obtener la duración de la renta en días.
            TimeSpan duracion = DuracionRenta();

            // Se utiliza la propiedad .Days para obtener los días completos.
            double dias = duracion.Days;

            //Logica para generar el precio
            switch (MoneyType)
            {
                case 0:
                    Console.WriteLine("Opción no válida. Por favor ingrese un número entre 1 y 4.");
                    break;
                case (MoneyType)1:
                    dias *= 250;
                    Console.WriteLine("Se seleccionó la opción *1");
                    break;
                case (MoneyType)2:
                    Console.WriteLine("Se seleccionó la opción *1.2");
                    dias = dias * 250 * 1.2;
                    break;
                case (MoneyType)3:
                    Console.WriteLine("Se seleccionó la opción *380");
                    dias = dias * 250 * 380;
                    break;
                case (MoneyType)4:
                    Console.WriteLine("Se seleccionó la opción *1.5");
                    dias = dias * 250 * 1.5;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor ingrese un número entre 1 y 4.");
                    break;
            }

            // Logica para la capacidad de la habitacion

            switch (Capacity)
            {
                case 0:
                    Console.WriteLine("Opción no válida. Por favor ingrese un número entre 1 y 3.");
                    break;

                    case (Capacity)1:
                    dias = dias;
                    Console.WriteLine("Se seleccionó la habitacion sencilla");
                    break;

                case (Capacity)2:
                    dias = dias * 1.5;
                    Console.WriteLine("Se seleccionó la habitacion doble");
                    break;


                case (Capacity)3:
                    dias = dias * 2;
                    Console.WriteLine("Se seleccionó la habitacion familiar");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor ingrese un número entre 1 y 3.");
                    break;
            }

            // Logica para la categoria de la habitacion

            switch (Category)
            {
                case 0:
                    Console.WriteLine("Opción no válida. Por favor ingrese un número entre 1 y 3.");
                    break;

                case (Category)1:
                    dias = dias;
                    Console.WriteLine("Se seleccionó la habitacion estandar");
                    break;

                case (Category)2:
                    dias = dias * 2;
                    Console.WriteLine("Se seleccionó la habitacion suite");
                    break;


                case (Category)3:
                    dias = dias * 5;
                    Console.WriteLine("Se seleccionó la habitacion vip");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor ingrese un número entre 1 y 3.");
                    break;
            }


            // Logica para comprobar el precio
            if (dias > Cash)
            {
                return Result.Fail<Agreement>("Debe pagar una monto mayor");
            }

            // logica para ver si se puede rentar
            if (SmartHotel.Domain.Entities.Room.IsRentable)== 0
            {
                return Result.Fail<Agreement>("La habitacion se encuentra rentada en la fecha seleccionada");
            }

            else
                return Result.Ok(new Agreement(ClientName, Clientemail, FechaInicio, FechaFinal, MoneyType, Cash, Id));
        }
    }
}

