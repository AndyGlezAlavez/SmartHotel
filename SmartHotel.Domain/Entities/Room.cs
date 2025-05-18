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

       
        public Room(Guid id, int number, Price rentalPrice, RoomType roomType, Temperature temperature, Smoke smoke, Light light) : base(id)
        {
            Number = number;
            RentalPrice = rentalPrice;
            RoomType = roomType;
            Temperature = temperature;
            Light = light;
            Smoke = smoke;
            IsRentable = !Smoke.Danger();
            IsClimatizationOn = Temperature.TurnOn();
            IsIluminationOn = Light.TurnOn();
            IsOcupated = false;
        }
        public bool IsRentabled(DateTime startDate, DateTime finalDate)
        {
            if (Smoke.Danger())
                return false;
            else
                return !Agreements.Any(a => startDate < a.FinalDate && finalDate > a.StartDate);       
        }
        }
}


