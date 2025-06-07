using FluentResults;
using SmartHotel.Application.Commands.Temperature.DeleteTemperature;
using SmartHotel.Contracts.Repositories.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Temperature.DeleteTemperature
{
    public class DeleteTemperatureCommandHandler
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public DeleteTemperatureCommandHandler(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }
        public async Task<Result> Handle(DeleteTemperatureCommand request, CancellationToken cancellationToken)
        {
            _repositoryManager.Variable.DeleteById(request.ID);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}
