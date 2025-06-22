using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using SmartHotel.API.Mappers;
using SmartHotel.Application.Commands.Light.CreateLight;
using SmartHotel.Application.Queries.Light.GetAllLight;
using SmartHotel.GrpcProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.API.Services
{
    public class LightService : GrpcProtos.Light.LightBase
    {
           private readonly IMediator _mediator;

            public LightService(IMediator mediator)
            {
                _mediator = mediator;
            }
            public override Task<Empty> DeleteLight(DeleteRequestDTO request, ServerCallContext context)
            {
                return base.DeleteLight(request, context);
            }
            public override Task<Empty> UpdateLight(LightDTO request, ServerCallContext context)
            {
                return base.UpdateLight(request, context);
            }
        public override Task<NullableLightDTO> GetLight(GetRequestDTO request, ServerCallContext context)
        {
            return base.GetLight(request, context);
        }
        public override async Task<Lights> GetAllLight(Empty request, ServerCallContext context)
        {
            var query = new GetAllLightQuery();

            var result = await _mediator.Send(query);

            if (result.IsFailed)
                throw new RpcException(
                    new Status(StatusCode.InvalidArgument,
                    result.Errors.First().Message));

            return result.Value.Map();
        }
        public override async Task<LightDTO> CreateLight(CreateLightRequest request, ServerCallContext context)
        {
            var command = new CreateLightCommand(
                request.Unit.Map(), request.Reference, request.Value, request.Room.Map(), request.Id);

            var result = await _mediator.Send(command);

            if (result.IsFailed)
                throw new RpcException(
                    new Status(StatusCode.InvalidArgument,
                    result.Errors.First().Message));

            return new LightDTO();
        }

    }
}
