using FluentResults;
using MediatR;
using SmartHotel.Application.Common;
using SmartHotel.Application.Commands;
using SmartHotel.Contracts.Repositories.Managers;
using SmartHotel.Domain.Entities;
using SmartHotel.GrpcProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Google.Protobuf.WellKnownTypes;
using SmartHotel.Application.Queries.Temperature.GetTemperature;

namespace SmartHotel.Application.Queries.Temperature.GetTemperature
{
    public class GetTemperatureQueryHandler
        : IQueryHandler<GetTemperatureQuery, SmartHotel.Domain.Entities.Temperature>
    {
        private readonly IAppRepositoryManager _repositoryManager;

        public GetTemperatureQueryHandler(
            IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Result<SmartHotel.Domain.Entities.Temperature>> Handle(GetTemperatureQuery request, CancellationToken cancellationToken)
        {
            return (Result.Ok(await _repositoryManager.Temperature.GetByIdAsync(request.Id)))!;
        }
    }
}
