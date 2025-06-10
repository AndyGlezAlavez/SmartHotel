using FluentResults;
using SmartHotel.Application.Commands.Agreement.CreateAgreement;
using SmartHotel.Application.Common;
using SmartHotel.Contracts.Repositories.Managers;
using SmartHotel.Domain.Rules;
using SmartHotel.GrpcProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Agreement.CreateAgreement
{
    public class CreateAgreementCommandHandler : ICommandHandler<CreateAgreementCommand>
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public CreateAgreementCommandHandler(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }

        public async Task<Result> Handle(CreateAgreementCommand request, CancellationToken cancellationToken)
        {
            Result<ComparationPrice> codeResult = ComparationPrice.Create(request.StartDate, request.FinalDate, request.Price, request.Room);
            if (codeResult.IsFailed)
            return codeResult.ToResult();
            Result<DateMustBeFree> codeResulted = DateMustBeFree.Create(request.StartDate, request.FinalDate, request.Room.Agreements);
            if (codeResulted.IsFailed)
                return codeResulted.ToResult();
            Result<EmailMustBeGmail> codeResultado = EmailMustBeGmail.Create(request.Clientemail);
            if (codeResultado.IsFailed)
                return codeResultado.ToResult();
            var Agreement = new Domain.Entities.Agreement(request.Clientname, request.Clientemail, request.StartDate, request.FinalDate, request.Room, Guid.NewGuid());

            await _repositoryManager.Agreement.AddAsync(Agreement);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
