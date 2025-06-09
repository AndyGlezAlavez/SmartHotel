using SmartHotel.API.Services;
using SmartHotel.Application.Commands.Smoke.CreateSmoke;
using SmartHotel.Application.Queries.Smoke.GetAllsSmoke;
using SmartHotel.GrpcProtos;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Types;
using FluentResults;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartHotel.API.Mappers;

namespace SmartHotel.API.Services
{
    public class SmokeService : GrpcProtos.Smoke.SmokeBase
    {
        private readonly IMediator _mediator;

        public SmokeService(IMediator mediator)
        {
            _mediator = mediator;
        }
        /*
    public override async Task<SmokeDTO> CreateSmoke(CreateSmokeRequest request, ServerCallContext context)
    {
        var command = new CreateSmokeCommand(
            request.Unit, request.Reference, request.Value, request.Room) ;

        var result = await _mediator.Send(command);

        if (result.IsFailed)
            throw new RpcException(
                new Status(StatusCode.InvalidArgument,
                result.Errors.First().Message));

        return new SmokeDTO();
    }
          */
        public override Task<NullableSmokeDTO> GetSmoke(GetRequestDTO request, ServerCallContext context)
        {
            return base.GetSmoke(request, context);
        }

        public override async Task<Smokes> GetAllSmoke(Empty request, ServerCallContext context)
        {
            var query = new GetAllSmokeQuery();

            var result = await _mediator.Send(query);

            if (result.IsFailed)
                throw new RpcException(
                    new Status(StatusCode.InvalidArgument,
                    result.Errors.First().Message));

            return result.Value.Map();
        }
       
        public override Task<Empty> DeleteSmoke(DeleteRequestDTO request, ServerCallContext context)
        {
            return base.DeleteSmoke(request, context);
        }
        public override Task<Empty> UpdateSmoke(SmokeDTO request, ServerCallContext context)
        {
            return base.UpdateSmoke(request, context);
        }
    }
}