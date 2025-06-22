using SmartHotel.API.Services;
using SmartHotel.Application.Commands.Room.CreateRoom;
using SmartHotel.Application.Queries.Room.GetAllRoom;
using SmartHotel.GrpcProtos;
using FluentResults;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartHotel.API.Mappers;

namespace SmartHotel.API.Services
{
    public class RoomService : GrpcProtos.Room.RoomBase
    {
        private readonly IMediator _mediator;

        public RoomService(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public override async Task<RoomDTO> CreateRoom(CreateRoomRequest request, ServerCallContext context)
        {
            var command = new CreateRoomCommand(
                request.Id, 
                request.Number,
                request.RentalPrice.Map(),
                request.RoomType.Map(),
                request.Temperature.Map(),
                request.Smoke.Map(),
                request.Light.Map());
            

            var result = await _mediator.Send(command);

            if (result.IsFailed)
                throw new RpcException(
                    new Status(StatusCode.InvalidArgument,
                    result.Errors.First().Message));

            return new RoomDTO();
        }
        
        public override async Task<Rooms> GetAllRoom(Empty request, ServerCallContext context)
        {
            var query = new GetAllRoomQuery();

            var result = await _mediator.Send(query);

            if (result.IsFailed)
                throw new RpcException(
                    new Status(StatusCode.InvalidArgument,
                    result.Errors.First().Message));

            return result.Value.Map();
        }
        
        public override Task<Empty> AddAgreementToRoom(AgreementRoomRelationDTO request, ServerCallContext context)
        {
            return base.AddAgreementToRoom(request, context);
        }

        public override Task<Empty> RemoveAgreementFromRoom(AgreementRoomRelationDTO request, ServerCallContext context)
        {
            return base.RemoveAgreementFromRoom(request, context);
        }

        public override Task<Empty> AddRoom(RoomDTO request, ServerCallContext context)
        {
            return base.AddRoom(request, context);
        }
        public override Task<Empty> UpdateRoom(RoomDTO request, ServerCallContext context)
        {
            return base.UpdateRoom(request, context);
        }
        public override Task<Empty> DeleteRoom(DeleteRequestDTO request, ServerCallContext context)
        {
            return base.DeleteRoom(request, context);
        }
    }
}
