using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SmartHotel.GrpcProtos;

namespace SmartHotel.gRPC.Services
{
    public class AgreementsService : Agreement.AgreementBase
    {
        public override Task<Empty> AddAgreement(AgreementDTO request, ServerCallContext context)
        {
            return base.AddAgreement(request, context);
        }

        public override Task<AgreementDTO> CreateAgreement(CreateAgreementRequest request, ServerCallContext context)
        {
            return base.CreateAgreement(request, context);
        }
        public override Task<Empty> DeleteAgreement(DeleteRequestDTO request, ServerCallContext context)
        {
            return base.DeleteAgreement(request, context);
        }
        public override Task<Agreements> GetAllAgreement(Empty request, ServerCallContext context)
        {
            return base.GetAllAgreement(request, context);
        }
        public override Task<Empty> RemoveAgreement(AgreementDTO request, ServerCallContext context)
        {
            return base.RemoveAgreement(request, context);
        }
        public override Task<Empty> UpdateAgreement(AgreementDTO request, ServerCallContext context)
        {
            return base.UpdateAgreement(request, context);
        }
    }
}
