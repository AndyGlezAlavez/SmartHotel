using FluentResults;
using SmartHotel.Application.Commands.Temperature.CreateTemperature;
using SmartHotel.Contracts.Repositories.Managers;
using SmartHotel.Domain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Temperature.CreateTemperature
{
    public class CreateTemperatureCommandHandler
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public CreateTemperatureCommandHandler(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }

        public async Task<Result> Handle(CreateTemperatureCommand request, CancellationToken cancellationToken)
        {
            var temperature = new Domain.Entities.Temperature( Guid.NewGuid(), request.Value, request.Reference, request.TempUnit,  request.Room);

            await _repositoryManager.Variable.AddAsync(temperature);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}

