using FluentResults;
using SmartHotel.Application.Common;
using SmartHotel.Contracts.Repositories.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using SmartHotel.Application.Queries.Agreement.GetAgreement;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Queries.Agreement.GetAgreement
{
    public class GetAgreementQueryHandler
    : IQueryHandler<GetAgreementQuery, SmartHotel.Domain.Entities.Agreement>
    {
        private readonly IAppRepositoryManager _repositoryManager;

        public GetAgreementQueryHandler(
            IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Result<SmartHotel.Domain.Entities.Agreement>> Handle(GetAgreementQuery request, CancellationToken cancellationToken)
        {
            return (Result.Ok(await _repositoryManager.Agreement.GetAgreementsByIdAsync(request.Id)))!;
        }
    }
}
