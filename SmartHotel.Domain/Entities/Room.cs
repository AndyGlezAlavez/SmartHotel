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
        /// numero de la habitación
        /// </summary>
        int Number { get; set; }
        /// <summary>
        /// La habitacion esta lista para ser alquilada
        /// </summary>
        bool IsRentable { get; set; }
        /// <summary>
        /// Ya fue alquilada actualmente
        /// </summary>
        bool IsRenteable { get; set; }
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
        public List<ISensor> Sensores { get; set; }
        public List<IActuador> Actuadores { get; set; }
        Smoke Smoke { get; set; }
        Temperature Temperature { get; set; }
        Light Light { get; set; } 
        #endregion

        public Room(Guid id, int number, Price RentalPrice, RoomType roomType, List<ISensor> sensors, List<IActuador> actuadors, bool IsRenteable, bool IsCliamtizationOn, bool IsIluminationON, Temperature temperature, Smoke smoke, Light light) : base(id)
        {
            Number = number;
            RoomType = roomType;
            this.Actuadores = new List<IActuador>();
            this.Sensores = new List<ISensor>();
            this.IsRentable = IsRentable;
            this.IsClimatizationOn = IsClimatizationOn;
            this.IsIluminationOn = IsIluminationOn;
            this.Smoke = smoke;
            this.Temperature = temperature;
            this.Light = light;
        }

        public void AgregarSensor(ISensor sensor)
        {
            Sensores.Add(sensor);
        }

        public void AgregarActuador(IActuador actuador)
        {
            Actuadores.Add(actuador);
        }
        public bool IsRentabled() {
            if (Smoke.Danger()) return false;
            else return true;
        }
    } }


