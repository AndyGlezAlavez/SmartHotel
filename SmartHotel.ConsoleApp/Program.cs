using FluentResults;
using SmartHotel.Contracts.Repositories.Managers;
using System;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Types;
using SmartHotel.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.EntityFrameworkCore;
using SmartHotel.GrpcProtos;

namespace SmartHotel.ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Presione una tecla para continuar.");
            Console.ReadKey();

            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            var channel = GrpcChannel.ForAddress(
                "http://localhost:7293",
                new GrpcChannelOptions { HttpHandler = httpHandler });

            if (channel is null)
            {
                Console.WriteLine("Cannot connect");
                return;
            }

            var client = new SmartHotel.GrpcProtos.Room.RoomClient(channel);

            try
            {
                client.CreateRoom(new CreateRoomRequest() { 
                    Number = 1,
                    IsRentable = true, 
                    IsOcupated = false, 
                    RentalPrice = new GrpcProtos.Price(),
                    IsClimatization = true,
                    IsIlumination = false,
                    RoomType = new GrpcProtos.RoomType(),
                    Smoke = new GrpcProtos.SmokeDTO(),
                    Temperature = new GrpcProtos.TemperatureDTO(),
                    Light = new GrpcProtos.LightDTO(),
                    Id = "1409649460458",
                });
            }
            catch (RpcException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("OK");
        }
    }
}