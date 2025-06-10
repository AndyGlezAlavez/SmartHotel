using FluentResults;
using SmartHotel.Application.Commands.Room.RemoveAgreementFromRoom;
using SmartHotel.Contracts.Repositories.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Room.AddAgreementToRoom
{
    public class AddAgreementToRoomCommandHandler
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public AddAgreementToRoomCommandHandler(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }
        public async Task<Result> Handle(AddAgreementToRoomCommand request, CancellationToken cancellationToken)
        {
            await _repositoryManager.Agreement.AddAsync(request.Agreement);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}