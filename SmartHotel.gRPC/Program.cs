using SmartHotel.Persistence.Contexts;
using SmartHotel.gRPC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar Kestrel para usar HTTP/2 en el puerto 7293
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(7293, listenOptions =>
    {
        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
    });
});


// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();
// Configure the HTTP request pipeline.
//app.MapGrpcService<GreeterService>();

app.MapGrpcService<AgreementsService>();
app.MapGrpcService<RoomService>();
app.MapGrpcService<TemperatureService>();
app.MapGrpcService<SmokeService>();
app.MapGrpcService<LightService>();



app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
