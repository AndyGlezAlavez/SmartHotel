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
using SmartHotel.Application.Queries.Temperature.GetAllsTemperature;

namespace SmartHotel.Application.Queries.Temperature.GetAllsTemperature
{
    public class GetAllTemperatureQueryHandler
        : IQueryHandler<GetAllTemperatureQuery, IEnumerable<SmartHotel.Domain.Entities.Temperature>>
    {
        private readonly IAppRepositoryManager _repositoryManager;

        public GetAllTemperatureQueryHandler(
            IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Result<IEnumerable<SmartHotel.Domain.Entities.Temperature>>> Handle(GetAllTemperatureQuery request, CancellationToken cancellationToken)
        {
            return Result.Ok(await _repositoryManager.Temperature.GetTemperaturesAsync());
        }
    }
}
