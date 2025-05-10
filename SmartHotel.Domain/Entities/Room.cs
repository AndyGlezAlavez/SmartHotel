using SmartHotel.Domain.Common;
using SmartHotel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Entities
{
    public abstract class Room : Entity 
    {
        public int NumeroHabitacion { get; set; }
        public decimal Precio { get; set; }
        public bool Ocupada { get; set; }
        public bool Rentada { get; set; }
        public bool ClimatizacionEncendida { get; set; }
        public bool IluminacionEncendida { get; set; }

        public List<ISensor> Sensores { get; set; } ;
        public List<IActuador> Actuadores { get; set; };

        public Room(int NumeroHabitacion, decimal Precio, bool Ocupada, bool Rentada, bool ClimatizacionEncendida, bool IlumicacionEncendida, List <ISensor>, List <IActuador>, Guid id) {
            NumeroHabitacion = numerohabitacion;
            Precio = precio;
            Ocupada = ocupada;
            Rentada = rentada;
            ClimatizacionEncendida = climatizacionencendida;
            Actuadores = new List<IActuador>();
            Sensores = = new List<ISensor>();
        }

        public void AgregarSensor(ISensor sensor)
        {
            Sensores.Add(sensor);
        }

        public void AgregarActuador(IActuador actuador)
        {
            Actuadores.Add(actuador);
        }
    }

}
