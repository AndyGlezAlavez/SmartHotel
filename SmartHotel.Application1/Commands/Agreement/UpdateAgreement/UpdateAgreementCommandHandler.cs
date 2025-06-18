using FluentResults;
using SmartHotel.Application.Common;
using SmartHotel.Contracts.Repositories.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Agreement.UpdateAgreement
{
    public class UpdateAgreementCommandHandler : ICommandHandler<UpdateAgreementCommand>
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public UpdateAgreementCommandHandler(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }

        public async Task<Result> Handle(UpdateAgreementCommand request, CancellationToken cancellationToken)
        {
            _repositoryManager.Agreement.Update(request.Agreement);
            SmartHotel.Domain.Entities.Agreement Agreement = request.Agreement;

            if (Agreement == null) return Result.Fail("Update operation Fail");
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}
