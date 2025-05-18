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
    public class Room : Entity
    {

        #region Properties
        
        /// <summary>
        /// Número de la habitación.
        /// </summary>
        int Number { get; set; }
        
        /// <summary>
        /// La habitacion está lista para ser alquilada.
        /// </summary>
        bool IsRentable { get; set; }
        
        /// <summary>
        /// La habitación ya fue alquilada actualmente.
        /// </summary>
        bool IsOcupated { get; set; }

        /// <summary>
        /// Precio al que se alquila la habitación.
        /// </summary>
        Price RentalPrice { get; set; }

        /// <summary>
        /// Está encendida la climatización.
        /// </summary>
        bool IsClimatizationOn { get; set; }

        /// <summary>
        /// Están encendidas las luces.
        /// </summary>
        bool IsIluminationOn { get; set; }

        /// <summary>
        /// Tipo de habitación.
        /// </summary>
        RoomType RoomType { get; set; }

        /// <summary>
        /// Concentración de humo en la habitación.
        /// </summary>
        Smoke Smoke { get; set; }

        /// <summary>
        /// Temperatura en la habitación.
        /// </summary>
        Temperature Temperature { get; set; }

        /// <summary>
        /// Iluminación en la habitación.
        /// </summary>
        Light Light { get; set; } 
        #endregion

        //*****Revisar este constructor. Creo que las variables no hay que pasarlas aquí. Eso se hace después en la etapa de persistencia a datos.
        public Room(Guid id, int number, Price RentalPrice, RoomType roomType, bool IsRentable, bool IsCliamtizationOn, bool IsIluminationOn, Temperature temperature, Smoke smoke, Light light) : base(id)
        {
            Number = number;
            RoomType = roomType;
            this.IsRentable = IsRentable;
            this.IsClimatizationOn = IsClimatizationOn;
            this.IsIluminationOn = IsIluminationOn;
            this.Smoke = smoke;
            this.Temperature = temperature;
            this.Light = light;
            IsOcupated = false;
        }

        //***** A quién modificaría esta función dentro de ´Room´???
        public bool IsRentabled() {
            if (Smoke.Danger()) return false;
            else return true;
        }
    } }


