using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SmartHotel.GrpcProtos;

namespace SmartHotel.gRPC.Services
{
    public class SmokeService : Smoke.SmokeBase
    {
        public override Task<SmokeDTO> CreateSmoke(CreateSmokeRequest request, ServerCallContext context)
        {
            return base.CreateSmoke(request, context);
        }
        public override Task<Empty> DeleteSmoke(DeleteRequestDTO request, ServerCallContext context)
        {
            return base.DeleteSmoke(request, context);
        }
        public override Task<Smokes> GetAllSmoke(Empty request, ServerCallContext context)
        {
            return base.GetAllSmoke(request, context);
        }
        public override Task<NullableSmokeDTO> GetSmoke(GetRequestDTO request, ServerCallContext context)
        {
            return base.GetSmoke(request, context);
        }
        public override Task<Empty> UpdateSmoke(SmokeDTO request, ServerCallContext context)
        {
            return base.UpdateSmoke(request, context);
        }
    }
}
