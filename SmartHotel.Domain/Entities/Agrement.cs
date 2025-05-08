using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHotel.Domain.Common;
using SmartHotel.Domain.Entities;

namespace SmartHotel.Domain.Entities
{
    public class Agrement : Entity
    {
      #region Properties
      
        /// Nombre del cliente 
        /// 

        public string ClientName { get; set; }
        
        /// Correo del cliente
        /// 
        public string Clientemail { get; set; }

        // Fecha de inicio
        public DateTime FechaInicio { get; set; }

        // Fecha final

        public DateTime FechaFinal { get; set; }

        // Precio final esperado
        public Price endPrice { get; set; }
        #endregion
 

        public Agrement(string clientname, string clientemail,DateTime fechaInicio, DateTime fechaFinal, Price precio, Guid id) : base(id)
        {   ClientName = clientname;
            Clientemail = clientemail;
                FechaInicio = fechaInicio;
                FechaFinal = fechaFinal;
                precio = precio;
            }

            public TimeSpan DuracionRenta()
            {
                return FechaFinal - FechaInicio;
           
        }


        public Price SetPrice (MoneyType moneyType)
        {
            // Obtener la duración de la renta en días.
            TimeSpan duracion = DuracionRenta();

            // Se utiliza la propiedad .Days para obtener los días completos.
            double dias = duracion.Days;
            monto = new Price(dias *200 , moneyType);
            return monto;
        }



    }
}
