using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SmartHotel.GrpcProtos;

namespace SmartHotel.gRPC.Services
{
    public class LightService : Light.LightBase
    {
        public override Task<LightDTO> CreateLight(CreateLightRequest request, ServerCallContext context)
        {
            return base.CreateLight(request, context);
        }

        public override Task<Empty> DeleteLight(DeleteRequestDTO request, ServerCallContext context)
        {
            return base.DeleteLight(request, context);
        }
        public override Task<Lights> GetAllLight(Empty request, ServerCallContext context)
        {
            return base.GetAllLight(request, context);
        }
        public override Task<NullableLightDTO> GetLight(GetRequestDTO request, ServerCallContext context)
        {
            return base.GetLight(request, context);
        }
        public override Task<Empty> UpdateLight(LightDTO request, ServerCallContext context)
        {
            return base.UpdateLight(request, context);
        }
    }
}
