using FluentResults;
using SmartHotel.Application.Common;
using SmartHotel.Contracts.Repositories.Managers;
using SmartHotel.Application.Queries.Light.GetAllLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartHotel.Domain.Entities;
using System.Threading.Tasks;

namespace SmartHotel.Application.Queries.Light.GetAllLight;

public class GetAllLightQueryHandler
     : IQueryHandler<GetAllLightQuery, IEnumerable<Domain.Entities.Light>>
{
    private readonly IAppRepositoryManager _repositoryManager;

    public GetAllLightQueryHandler(
        IAppRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<Result<IEnumerable<Domain.Entities.Light>>> Handle(GetAllLightQuery request, CancellationToken cancellationToken)
    {
        return Result.Ok(await _repositoryManager.Light.GetLightsAsync());
    }
}
