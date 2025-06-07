using FluentResults;
using SmartHotel.Application.Commands.Smoke.DeleteSmoke;
using SmartHotel.Contracts.Repositories.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Room.DeleteRoom
{
    public class DeleteRoomCommandHandler
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public DeleteRoomCommandHandler(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }
        public async Task<Result> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            _repositoryManager.Room.DeleteById(request.ID);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}
