using FluentResults; 
using SmartHotel.Domain.Common;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Types;
using SmartHotel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.Rules
{
    public sealed record ComparationPrice(DateTime StartDate, DateTime FinalDate, Price Price, Room Room) : IBusinessRule
    {
        public Result CheckRule()
        {
            TimeSpan duracion = FinalDate-StartDate;
            double dias = duracion.Days;

            //Logica para generar el precio
            switch (Price.MoneyType)
            {
                case (MoneyType.Euro):
                    dias *= 100;
                    Console.WriteLine("You choose EURO");
                    break;
                case (MoneyType.USD):
                    Console.WriteLine("You choose USD");
                    dias = dias * 100 * 1.2;
                    break;
                case (MoneyType.Peso):
                    Console.WriteLine("You choose MN");
                    dias = dias * 100 * 380;
                    break;
                case (MoneyType.MLC):
                    Console.WriteLine("You choose MLC");
                    dias = dias * 100 * 1.5;
                    break;
                default:
                    Console.WriteLine("Option not avaible. Please choose a number between 0 and 3.");
                    break;
            }

            // Logica para la capacidad de la habitacion
            switch (Room.RoomType.Capacity)
            {
                case (Capacity.Sencilla):
                    Console.WriteLine("You choose sencilla");
                    break;

                case (Capacity.Doble):
                    dias *= 1.5;
                    Console.WriteLine("You choose doble");
                    break;


                case (Capacity.Familiar):
                    dias *= 2;
                    Console.WriteLine("You choose familiar");
                    break;

                default:
                    Console.WriteLine("Option not avaible. Please choose a number between 0 and 2.");
                    break;
            }

            // Logica para la categoria de la habitacion

            switch (Room.RoomType.Category)
            {
                case (Category.Estandar):
                    Console.WriteLine("You choose estandar");
                    break;

                case (Category.Suit):
                    dias *= 2;
                    Console.WriteLine("You choose suite");
                    break;

                case (Category.VIP):
                    dias *= 5;
                    Console.WriteLine("You choose vip");
                    break;

                default:
                    Console.WriteLine("Option not avaible. Please choose a number between 0 and 2.");
                    break;
            }
            Price.Value = dias;
            if (Price.Value < Room.RentalPrice.Value)
                return Result.Ok();
            return Result.Fail(new Error("Verify your payment, you have to pay more"));
        }
        public static Result<ComparationPrice> Create(DateTime StartDate, DateTime FinalDate, Price Price, Room room)
        {
            // Obtener la duración de la renta en días.
            // Se utiliza la propiedad .Days para obtener los días completos.
            TimeSpan duracion = FinalDate - StartDate;
            double dias = duracion.Days;

            //Logica para generar el precio
            switch (Price.MoneyType)
            {
                case (MoneyType.Euro):
                    dias *= 100;
                    Console.WriteLine("You choose EURO");
                    break;
                case (MoneyType.USD):
                    Console.WriteLine("You choose USD");
                    dias = dias * 100 * 1.2;
                    break;
                case (MoneyType.Peso):
                    Console.WriteLine("You choose MN");
                    dias = dias * 100 * 380;
                    break;
                case (MoneyType.MLC):
                    Console.WriteLine("You choose MLC");
                    dias = dias * 100 * 1.5;
                    break;
                default:
                    Console.WriteLine("Option not avaible. Please choose a number between 0 and 3.");
                    break;
            }

            // Logica para la capacidad de la habitacion
            switch (room.RoomType.Capacity)
            {
                case (Capacity.Sencilla):
                    Console.WriteLine("You choose sencilla");
                    break;

                case (Capacity.Doble):
                    dias *= 1.5;
                    Console.WriteLine("You choose doble");
                    break;


                case (Capacity.Familiar):
                    dias *= 2;
                    Console.WriteLine("You choose familiar");
                    break;

                default:
                    Console.WriteLine("Option not avaible. Please choose a number between 0 and 2.");
                    break;
            }

            // Logica para la categoria de la habitacion

            switch (room.RoomType.Category)
            {
                case (Category.Estandar):
                    Console.WriteLine("You choose estandar");
                    break;

                case (Category.Suit):
                    dias *= 2;
                    Console.WriteLine("You choose suite");
                    break;

                case (Category.VIP):
                    dias *= 5;
                    Console.WriteLine("You choose vip");
                    break;

                default:
                    Console.WriteLine("Option not avaible. Please choose a number between 0 and 2.");
                    break;
            }
            Price.Value = dias;
            if (Price.Value < room.RentalPrice.Value)
                return Result.Ok();
            return Result.Fail(new Error("Verify your payment, you have to pay more"));
        }
    }
}
