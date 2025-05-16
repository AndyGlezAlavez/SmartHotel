using SmartHotel.Domain.Common;
using SmartHotel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Entities
{
    public class Room : Entity
    {

        #region Properties
        /// <summary>
        /// numero de la habitación
        /// </summary>
        int Number {  get; set; }
        /// <summary>
        /// La habitacion esta lista para ser alquilada
        /// </summary>
        bool IsRentable { get; set; }
        /// <summary>
        /// Ya fue alquilada actualmente
        /// </summary>
        bool IsOcupated { get; set; }
        /// <summary>
        /// Precio al que se alquila la habitación
        /// </summary>
        Price RentalPrice { get; set; }
        /// <summary>
        /// Esta encendida la climatización
        /// </summary>
        bool IsClimatizationOn { get; set; }
        /// <summary>
        /// Estan encendidas las luces 
        /// </summary>
        bool IsIluminationOn { get; set; }
        RoomType RoomType { get; set; }
        #endregion

        public Room(Guid id, int number, Price  RentalPrice, RoomType roomType) : base(id)
        {
            Number = number;
            RoomType = roomType;
        }
    }
}
