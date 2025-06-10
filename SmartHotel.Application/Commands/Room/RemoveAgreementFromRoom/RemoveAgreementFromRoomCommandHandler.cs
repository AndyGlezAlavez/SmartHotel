using FluentResults;
using SmartHotel.Application.Commands.Room.DeleteRoom;
using SmartHotel.Contracts.Repositories.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Room.RemoveAgreementFromRoom
{
    public class RemoveAgreementFromRoomCommandHandler
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public RemoveAgreementFromRoomCommandHandler(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }
        public async Task<Result> Handle(RemoveAgreementFromRoomCommand request, CancellationToken cancellationToken)
        {
            _repositoryManager.Agreement.DeleteById(request.Id);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}
