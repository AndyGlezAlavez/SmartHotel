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

        #endregion


        public Agrement(string clientname, string clientemail,DateTime fechaInicio, DateTime fechaFinal, Guid id) : base(id)
        {   ClientName = clientname;
            Clientemail = clientemail;
                FechaInicio = fechaInicio;
                FechaFinal = fechaFinal;
            }

            public TimeSpan DuracionRenta()
            {
                return FechaFinal - FechaInicio;
           
        }




    }
}
