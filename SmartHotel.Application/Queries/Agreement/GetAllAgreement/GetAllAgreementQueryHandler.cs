using FluentResults;
using SmartHotel.Application.Common;
using SmartHotel.Application.Queries.Agreement.GetAllAgreement;
using SmartHotel.Application.Queries.Light.GetAllLight;
using SmartHotel.Contracts.Repositories.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Queries.Agreement.GetAllAgreement
{
    public class GetAllAgreementQueryHandler
     : IQueryHandler<GetAllAgreementQuery, IEnumerable<Domain.Entities.Agreement>>
    {
        private readonly IAppRepositoryManager _repositoryManager;

        public GetAllAgreementQueryHandler(
            IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Result<IEnumerable<Domain.Entities.Agreement>>> Handle(GetAllAgreementQuery request, CancellationToken cancellationToken)
        {
            return Result.Ok(await _repositoryManager.Agreement.GetAgreementsAsync());
        }
    }
}
