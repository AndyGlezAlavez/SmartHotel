
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartHotel.Contracts.Repositories.Managers;
using SmartHotel.Persistence.Contexts;
using SmartHotel.Persistence.Repositories.Managers;

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
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<AppDbContext>();
            builder.Services.AddSingleton("User ID =postgres;Password=AAM821988;Server=localhost;Port=5047;Database=SmartHotelDB;Include Error Detail=true;");
            builder.Services.AddScoped<IAppRepositoryManager, AppRepositoryManager>();
            
            var app = builder.Build();
            // Registrando servicios gRPC.
            app.MapGrpcService<Services.AgreementService>();
            app.MapGrpcService<Services.RoomService>();
            app.MapGrpcService<Services.TemperatureService>();
            app.MapGrpcService<Services.SmokeService>();
            app.MapGrpcService<Services.LightService>();

            // Registrando repositorios en la inyección de dependencias.

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}