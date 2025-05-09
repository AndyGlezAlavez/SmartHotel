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
    public class Agrement : Entity
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
        private static Price Prices { get; set; }

        #endregion


        protected Agrement(string clientname, string clientemail,DateTime fechaInicio, DateTime fechaFinal, Price prices, Guid id) : base(id)
        {   ClientName = clientname;
            Clientemail = clientemail;
                FechaInicio = fechaInicio;
                FechaFinal = fechaFinal;
                Price Prices= prices;
            }

            public static TimeSpan DuracionRenta()
            {
                return FechaFinal - FechaInicio;
           
        }

        public static Result<Agrement> Create(string clientname, string clientemail, DateTime fechaInicio, DateTime fechaFinal, Price prices, Guid id) {
            ClientName = clientname;
            Clientemail = clientemail;
            FechaInicio = fechaInicio;
            FechaFinal = fechaFinal;
            Prices = prices;
            Id = id;

                        if (!CheckPrice ())
            {
                return Result.Fail<Agrement>("Debe pagar una monto mayor");
            }
            else
                return Result.Ok(new Agrement(ClientName, Clientemail, FechaInicio, FechaFinal, Prices, Id));
            }
        public static bool CheckPrice()
        {
            // Obtener la duración de la renta en días.
            TimeSpan duracion = DuracionRenta();

            // Se utiliza la propiedad .Days para obtener los días completos.
            double dias = duracion.Days;
            if ()
            Price thisprice = new Price(dias, MoneyType = "1");     
            
        }
            public bool Equals(Price other)
            {
                if (ReferenceEquals(this, other))
                    return true;
            else 
                return  false;
            }

            // Sobrecarga de los operadores de igualdad.
            public static bool operator ==(Price prices, Price pay)
            {
                return prices.Equals(pay);
            }

            public static bool operator !=(Price prices, Price pay)
            {
                return !(prices == pay);
            }
    }
}
