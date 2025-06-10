using FluentResults;
using SmartHotel.Application.Common;
using SmartHotel.Contracts.Repositories.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Light.DeleteLight
{
    public class DeleteLightCommandHandler : ICommandHandler<DeleteLightCommand>
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public DeleteLightCommandHandler(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }
        public async Task<Result> Handle(DeleteLightCommand request, CancellationToken cancellationToken)
        {
            _repositoryManager.Variable.DeleteById(request.ID);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}
