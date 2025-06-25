using SmartHotel.Application.Commands.Temperature.CreateTemperature;
using SmartHotel.Application.Queries.Temperature;
using SmartHotel.GrpcProtos;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Types;
using FluentResults;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartHotel.Application.Queries.Temperature.GetAllsTemperature;
using SmartHotel.Application.Commands.Smoke.CreateSmoke;
using SmartHotel.gRPC.Mappers;

namespace SmartHotel.gRPC.Services
{
    public class TemperatureService : GrpcProtos.Temperature.TemperatureBase
    {
        private readonly IMediator _mediator;

        public TemperatureService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override Task<Empty> DeleteTemperature(DeleteRequestDTO request, ServerCallContext context)
        {
            return base.DeleteTemperature(request, context);
        }
        public override Task<Empty> UpdateTemperature(TemperatureDTO request, ServerCallContext context)
        {
            return base.UpdateTemperature(request, context);
        }
        public override async Task<Temperatures> GetAllTemperature(Empty request, ServerCallContext context)
        {
            var query = new GetAllTemperatureQuery();

            var result = await _mediator.Send(query);

            if (result.IsFailed)
                throw new RpcException(
                    new Status(StatusCode.InvalidArgument,
                    result.Errors.First().Message));

            return result.Value.Map();
        }
        public override Task<NullableTemperatureDTO> GetTemperature(GetRequestDTO request, ServerCallContext context)
        {
            return base.GetTemperature(request, context);
        }
        public override async Task<TemperatureDTO> CreateTemperature(CreateTemperatureRequest request, ServerCallContext context)
        {
            var command = new CreateTemperatureCommand(
                request.Unit.Map(), request.Reference, request.Value, request.Room.Map());

            var result = await _mediator.Send(command);

            if (result.IsFailed)
                throw new RpcException(
                    new Status(StatusCode.InvalidArgument,
                    result.Errors.First().Message));

            return new TemperatureDTO();
        }
    }
    }
