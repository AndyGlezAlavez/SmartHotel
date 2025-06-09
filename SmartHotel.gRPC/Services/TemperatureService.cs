using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SmartHotel.GrpcProtos;

namespace SmartHotel.gRPC.Services
{
    public class TemperatureService : Temperature.TemperatureBase
    {
        public override Task<TemperatureDTO> CreateTemperature(CreateTemperatureRequest request, ServerCallContext context)
        {
            return base.CreateTemperature(request, context);
        }
        public override Task<Empty> DeleteTemperature(DeleteRequestDTO request, ServerCallContext context)
        {
            return base.DeleteTemperature(request, context);
        }
        public override Task<Temperatures> GetAllTemperature(Empty request, ServerCallContext context)
        {
            return base.GetAllTemperature(request, context);
        }
        public override Task<NullableTemperatureDTO> GetTemperature(GetRequestDTO request, ServerCallContext context)
        {
            return base.GetTemperature(request, context);
        }
        public override Task<Empty> UpdateTemperature(TemperatureDTO request, ServerCallContext context)
        {
            return base.UpdateTemperature(request, context);
        }
    }
}
