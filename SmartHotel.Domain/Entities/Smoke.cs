using SmartHotel.Domain.Common;
using SmartHotel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Entities
{
    public class Smoke : Variable
    {
        SmokeUnit Unit { get; set; } = 0;
        public Smoke(Guid id, int number, int reference=1, SmokeUnit Unit = 0) : base(id, number, reference)
        {
            this.Unit = Unit;
        }
        public bool Danger()
        {
            int referencia = Getreference(); //sino no se puede acceder a los metodos
            int numero = Getnumber();
            switch (Unit)
            {
                case (SmokeUnit)0:
                    Console.WriteLine("Opción no válida. Por favor ingrese un número entre 1 y 3.");
                      return true;
                case (SmokeUnit)1:
                     return numero > referencia;
                case (SmokeUnit)2:
                    return numero > 1000 * referencia;
                default:
                    Console.WriteLine("Opción no válida. Por favor ingrese un número entre 1 y 2.");
                    return true;
            }

        }
    }
}
