using FluentResults;
using SmartHotel.Application.Common;
using SmartHotel.Contracts.Repositories.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Queries.Light.GetLight
{
    public class GetLightQueryHandler
        : IQueryHandler<GetLightQuery, SmartHotel.Domain.Entities.Light>
    {
        private readonly IAppRepositoryManager _repositoryManager;

        public GetLightQueryHandler(
            IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Result<SmartHotel.Domain.Entities.Light>> Handle(GetLightQuery request, CancellationToken cancellationToken)
        {
            return (Result.Ok(await _repositoryManager.Light.GetByIdAsync(request.Id)))!;
        }
    }
}
