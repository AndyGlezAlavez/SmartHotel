using SmartHotel.API.Services;
using SmartHotel.Application.Commands.Room.CreateRoom;
using SmartHotel.Application.Queries.Room.GetAllsRoom;
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

        /*public override async Task<Empty> CreateRoom(CreateRoomCommand request, ServerCallContext context)
        {
            var command = new CreateRoomCommand(
                request.Id, request.RentalPrice, request.RoomType, request.Temperature, request.Smoke, request.Light) ;

            var result = await _mediator.Send(command);

            if (result.IsFailed)
                throw new RpcException(
                    new Status(StatusCode.InvalidArgument,
                    result.Errors.First().Message));

            return new Empty();
        }

        public override Task<Empty> UpdateRoom(RoomDTO request, ServerCallContext context)
        {
            return base.UpdateRoom(request, context);
        }*/
        /*
        public override async Task<Rooms> GetAllRoom(GetRequestDTO request, ServerCallContext context)
        {
            var query = new GetAllRoomQuery();

            var result = await _mediator.Send(query);

            if (result.IsFailed)
                throw new RpcException(
                    new Status(StatusCode.InvalidArgument,
                    result.Errors.First().Message));

            return result.Value.Map();
        }

        public override Task<Empty> AddAutomationDeviceToUnit(AutomationDeviceUnitRelationDTO request, ServerCallContext context)
        {
            return base.AddAutomationDeviceToUnit(request, context);
        }

        public override Task<Empty> RemoveAutomationDeviceFromUnit(AutomationDeviceUnitRelationDTO request, ServerCallContext context)
        {
            return base.RemoveAutomationDeviceFromUnit(request, context);
        }
   */
        public override Task<Empty> DeleteRoom(DeleteRequestDTO request, ServerCallContext context)
        {
            return base.DeleteRoom(request, context);
        }
    }
}
