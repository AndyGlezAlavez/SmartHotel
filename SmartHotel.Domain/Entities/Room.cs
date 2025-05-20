using SmartHotel.Domain.Common;
using SmartHotel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Types;
using System.ComponentModel.Design;

namespace SmartHotel.Domain.Entities
{
    /// <summary>
    /// Habitación.
    /// </summary>
    public class Room : Entity
    {

        #region Properties

        /// <summary>
        /// Número de la habitación.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// La habitacion está lista para ser alquilada.
        /// </summary>
        public bool IsRentable { get; set; }

        /// <summary>
        /// La habitación ya fue alquilada actualmente.
        /// </summary>
        public bool IsOcupated { get; set; }

        /// <summary>
        /// Precio al que se alquila la habitación.
        /// </summary>
        public Price RentalPrice { get; set; }

        /// <summary>
        /// Está encendida la climatización.
        /// </summary>
        public bool IsClimatizationOn { get; set; }

        /// <summary>
        /// Están encendidas las luces.
        /// </summary>
        public bool IsIluminationOn { get; set; }

        /// <summary>
        /// Tipo de habitación.
        /// </summary>
        public RoomType RoomType { get; set; }

        /// <summary>
        /// Concentración de humo en la habitación.
        /// </summary>
        public Smoke Smoke { get; set; }

        /// <summary>
        /// Temperatura en la habitación.
        /// </summary>
        public Temperature Temperature { get; set; }

        /// <summary>
        /// Iluminación en la habitación.
        /// </summary>
        public Light Light { get; set; }

        /// <summary>
        /// Acuerdos de reservas de una habitación.
        /// </summary>
        public List<Agreement> Agreements { get; set; } = new();

        #endregion

       
        /// <summary>
        /// Requerido por Entity Framework.
        /// </summary>
        private Room() { }
        

        public Room(Guid id, int number, Price rentalPrice, RoomType roomType, Temperature temperature, Smoke smoke, Light light) : base(id)
        {
            Number = number;
            RentalPrice = rentalPrice;
            RoomType = roomType;
            Temperature = temperature;
            Light = light;
            Smoke = smoke;
            IsRentable = !Smoke.Danger();
            IsClimatizationOn = temperature.TemperatureControl();
            IsIluminationOn = light.LightControl();
            IsOcupated = false;
        }





        /// <summary>
        /// Devuelve si es posible rentar la habitación para los días deseados.
        /// </summary>
        /// <param name="startDate">Fecha de inicio deseada.</param>
        /// <param name="finalDate">Fecha de fin deseada.</param>
        /// <returns></returns>
        public bool IsRentabled(DateTime startDate, DateTime finalDate)  
//La función recibe las fecha de inicio y fin deseadas para efectuar una reserva (es llamada mientras se intenta crear un nuevo acuerdo de reserva por la entidad ´Agreement´).  
        {
            if (Smoke.Danger()) //Si la concentración de humo en la habitación solicitada supera el valor normal...
                return false;  //...directamente se indica que no es posible rentar esa habitación.
            
            else               //Si la concentración de humo en la habitación esta OK caemos aquí...
                return !Agreements.Any(a => startDate < a.FinalDate && finalDate > a.StartDate);  
//...donde se recorre la lista de acuerdos de reservas(´Agreements´) asociados a la habitación. Se comparan las fechas donde la habitación ya está rentada (las de la lista) con las nuevas fechas en que se solicita la reserva (las que recibe esta función). Aquí hay 4 posibilidades...
//Posibilidad 1: Que la nueva solicitud comience antes de que finalice una de las previstas (startDate < a.FinalDate) pero termine después del comienzo de esa prevista (finalDate > a.StartDate).
//Ej: SOLICITUD: 15/5-20/5, RESERVA ANTES CONFIRMADA: 18/5-21/5. Lo que implicaría que coincidieran iguales días de 2 reservaciones diferentes (18/5, 19/5 Y 20/5) para una misma habitación (NO PUEDE OCURRIR). Como las 2 condiciones se cumplen, la función ´Any´ devolverá TRUE pero la función ´IsRentabled´ devolverá lo contrario (FALSE), indicando de que NO ES POSIBLE rentar esa habitación para las fechas que se están recibiendo.

//Posibilidad 2: Que la nueva solicitud comience antes de que finalice una de las previstas (startDate < a.FinalDate) y termine antes del comienzo de esa prevista (finalDate < a.StartDate).
//Ej: SOLICITUD: 15/5-20/5, RESERVA ANTES CONFIRMADA: 21/5-24/5. Lo que implicaría que NO coincidieran iguales días de 2 reservaciones diferentes para una misma habitación (JUSTO LO QUE SE BUSCA). Como 1 de las condiciones no se cumplen, la función ´Any´ devolverá FALSE pero la función ´IsRentabled´ devolverá lo contrario (TRUE), indicando de que ES POSIBLE rentar esa habitación para las fechas que se están recibiendo.

//Posibilidad 3: Que la nueva solicitud comience después de que finalice una de las previstas (startDate > a.FinalDate) y termine después del comienzo de esa prevista (finalDate > a.StartDate).
//Ej: SOLICITUD: 15/5-20/5, RESERVA ANTES CONFIRMADA: 12/5-14/5.  Lo que implicaría que NO coincidieran iguales días de 2 reservaciones diferentes para una misma habitación (JUSTO LO QUE SE BUSCA). Como 1 de las condiciones no se cumplen, la función ´Any´ devolverá FALSE pero la función ´IsRentabled´ devolverá lo contrario (TRUE), indicando de que ES POSIBLE rentar esa habitación para las fechas que se están recibiendo.

//Posibilidad 4: Que la nueva solicitud comience después de que finalice una de las previstas (startDate > a.FinalDate) pero termine antes del comienzo de esa prevista (finalDate < a.StartDate).
//Ej: SOLICITUD: 15/5-20/5, RESERVA ANTES CONFIRMADA: 21/5-14/5. ESTO NO TIENE SENTIDO, no debe haber sido almacendada o intentarse almacenar una reservación donde la fecha de inicio sea posterior a la fecha de fin de la reserva. ES RESPONSABILIDAD DEL PROGRAMADOR QUE ESTO NO OCURRA DURANTE LA IMPLEMENTACIÓN DE ´Agreement´ antes de llegar a ´IsRentabled´. De ocurrir, como las dos condiciones no se están cumpliendo la función ´Any´ devolverá FALSE pero la función ´IsRentabled´ devolverá lo contrario (TRUE), indicando de que ES POSIBLE rentar esa habitación para las fechas que se están recibiendo.
        }



        /// <summary>
        /// Enciende/Apaga el sistema de iluminación de la habitación.
        /// </summary>
        /// <param name="turnOn">Estado deseado para el sistema de iluminación en la habitación</param>
        /// <returns></returns>
        public void TurnOnIlumination(bool turnOn)
        {
            Light.TurnOn = turnOn;
        }




        /// <summary>
        /// Enciende/Apaga el sistema de climatización de la habitación.
        /// </summary>
        /// <param name="turnOn">Estado deseado para el sistema de climatización en la habitación</param>
        public void TurnOnClimatization(bool turnOn)
        {
            Temperature.TurnOn = turnOn;
        }
    }
}


