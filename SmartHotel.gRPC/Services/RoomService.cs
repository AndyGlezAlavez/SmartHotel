using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SmartHotel.GrpcProtos;

namespace SmartHotel.gRPC.Services
{
    public class RoomService : Room.RoomBase
    {
        public override Task<Empty> AddRoom(RoomDTO request, ServerCallContext context)
        {
            return base.AddRoom(request, context);
        }
        public override Task<RoomDTO> CreateRoom(CreateRoomRequest request, ServerCallContext context)
        {
            return base.CreateRoom(request, context);
        }
        public override Task<Empty> DeleteRoom(DeleteRequestDTO request, ServerCallContext context)
        {
            return base.DeleteRoom(request, context);
        }
        public override Task<Rooms> GetAllRoom(Empty request, ServerCallContext context)
        {
            return base.GetAllRoom(request, context);
        }
        public override Task<Empty> AddAgreementToRoom(AgreementRoomRelationDTO request, ServerCallContext context)
        {
            return base.AddAgreementToRoom(request, context);
        }

        public override Task<Empty> RemoveAgreementFromRoom(AgreementRoomRelationDTO request, ServerCallContext context)
        {
            return base.RemoveAgreementFromRoom(request, context);
        }
        public override Task<Empty> RemoveRoom(RoomDTO request, ServerCallContext context)
        {
            return base.RemoveRoom(request, context);
        }
        public override Task<Empty> UpdateRoom(RoomDTO request, ServerCallContext context)
        {
            return base.UpdateRoom(request, context);
        }
    }
}
