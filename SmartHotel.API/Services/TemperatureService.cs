using SmartHotel.API.Services;
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
using SmartHotel.API.Mappers;

namespace SmartHotel.API.Services
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
    }
    }
