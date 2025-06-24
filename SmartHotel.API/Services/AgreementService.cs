using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows;
using System.Windows.Input;
using Grpc.Net.Client;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using SmartHotel.Application.Commands.Agreement.CreateAgreement;
using SmartHotel.Application.Queries.Agreement.GetAllAgreement;
using SmartHotel.GrpcProtos;
using SmartHotel.API.Mappers;

namespace SmartHotel.API.Services
{
    public class AgreementService : GrpcProtos.Agreement.AgreementBase
    {
        private readonly IMediator _mediator;

        public AgreementService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<AgreementDTO> CreateAgreement(CreateAgreementRequest request, ServerCallContext context)
        {
            var command = new CreateAgreementCommand(
                request.ClientEmail,
                request.ClientName,
                request.StartDate.ToDateTime(),
                request.FinalDate.ToDateTime(),
                request.Room.Map(),
                request.Id,
                request.Price.Map());

            var result = await _mediator.Send(command);

            if (result.IsFailed)
                throw new RpcException(
                    new Status(StatusCode.InvalidArgument,
                    result.Errors.First().Message));

            return new AgreementDTO();
        }
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://localhost:5001/")
        };

        /* public Task<Agreement?> GetAgreementAsync(Guid id)
         {
             return _httpClient.GetFromJsonAsync<Agreement?>($"api/AgreementService/{id}");
         }*/
        public override async Task<Agreements> GetAllAgreement(Empty request, ServerCallContext context)
        {
            var query = new GetAllAgreementQuery();

            var result = await _mediator.Send(query);

            if (result.IsFailed)
                throw new RpcException(
                    new Status(StatusCode.InvalidArgument,
                    result.Errors.First().Message));

            return result.Value.Map();
        }
        public override Task<Empty> AddAgreement(AgreementDTO request, ServerCallContext context)
        {
            return base.AddAgreement(request, context);
        }
        public override Task<Empty> UpdateAgreement(AgreementDTO request, ServerCallContext context)
        {
            return base.UpdateAgreement(request, context);
        }
        public override Task<Empty> DeleteAgreement(DeleteRequestDTO request, ServerCallContext context)
        {
            return base.DeleteAgreement(request, context);
        }
    }
}

