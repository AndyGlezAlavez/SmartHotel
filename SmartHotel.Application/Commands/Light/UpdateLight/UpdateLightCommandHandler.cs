using FluentResults;
using SmartHotel.Application.Common;
using SmartHotel.Contracts.Repositories.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Light.UpdateLight
{
    public class UpdateLightCommandHandler : ICommandHandler<UpdateLightCommand>
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public UpdateLightCommandHandler(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }
        public async Task<Result> Handle(UpdateLightCommand request, CancellationToken cancellationToken)
        {
            _repositoryManager.Variable.Update(request.Light);
            SmartHotel.Domain.Entities.Light light = request.Light;
            if (light == null) return Result.Fail("Update operation Fail");
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}
