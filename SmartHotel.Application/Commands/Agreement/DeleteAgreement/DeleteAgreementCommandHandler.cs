using FluentResults;
using SmartHotel.Application.Commands.Room.DeleteRoom;
using SmartHotel.Application.Common;
using SmartHotel.Contracts.Repositories.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Agreement.DeleteAgreement
{
    public class DeleteAgreementCommandHandler 
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public DeleteAgreementCommandHandler(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }

        public async Task<Result> Handle(DeleteAgreementCommand request, CancellationToken cancellationToken)
        {
            _repositoryManager.Agreement.DeleteById(request.ID);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}
