using SmartHotel.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SmartHotel.Contracts.Repositories.Managers;
using SmartHotel.Persistence.Contexts;
using SmartHotel.Persistence.Repositories.Managers;
using static System.Net.Mime.MediaTypeNames;
using SmartHotel.gRPC.Services;

namespace SmartHotel.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddGrpc();

            builder.Services.AddMediatR(new MediatRServiceConfiguration()
            {
                AutoRegisterRequestProcessors = true,
            }
            .RegisterServicesFromAssemblies(typeof(Application.AssemblyReference).Assembly));

            var app = builder.Build();

            // Registrando servicios gRPC.
            //app.MapGrpcService<SmartHotel.API.Services.AgreementService>();
            app.MapGrpcService<SmartHotel.API.Services.RoomService>();
            app.MapGrpcService<SmartHotel.API.Services.TemperatureService>();
            app.MapGrpcService<SmartHotel.API.Services.SmokeService>();
            //app.MapGrpcService<SmartHotel.API.Services.LightService>();

            // Registrando repositorios en la inyección de dependencias.
            builder.Services.AddSingleton("User ID =postgres;Password=qwerty;Server=localhost;Port=5047;Database=SmartHotelDB;Include Error Detail=true;");
            builder.Services.AddScoped<AppDbContext>();
            builder.Services.AddScoped<IAppRepositoryManager, AppRepositoryManager>();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}