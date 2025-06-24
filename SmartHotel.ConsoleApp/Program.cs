using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using SmartHotel.GrpcProtos;

namespace SmartHotel.ConsoleApp
{
    internal class Program
    {
            static async Task Main()
            {
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();

                var httpHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback =
                        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                var channel = GrpcChannel.ForAddress(
                    "http://localhost:5047",
                    new GrpcChannelOptions { HttpHandler = httpHandler });

                var client = new SmartHotel.GrpcProtos.Room.RoomClient(channel);

                try
                {
                    var response = await client.CreateRoomAsync(new CreateRoomRequest
                    {
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

                    Console.WriteLine("Room created: " + response);
                }
                catch (RpcException ex)
                {
                    Console.WriteLine("gRPC error: " + ex.Status);
                }

                Console.WriteLine("OK");
            }
        }
    }
