using FluentResults;
using SmartHotel.Application.Commands.Smoke.UpdateSmoke;
using SmartHotel.Contracts.Repositories.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Temperature.UpdateTemperature
{
    public class UpdateTemperatureCommandHandler
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public UpdateTemperatureCommandHandler(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }
        public async Task<Result> Handle(UpdateTemperatureCommand request, CancellationToken cancellationToken)
        {
            
            _repositoryManager.Temperature.Update(request.Temperature);
            SmartHotel.Domain.Entities.Temperature Temperature = request.Temperature;
            if (Temperature == null) return Result.Fail("Update operation Fail");
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}
