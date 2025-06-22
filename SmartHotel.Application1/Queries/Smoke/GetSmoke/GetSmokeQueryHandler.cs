using FluentResults;
using MediatR;
using SmartHotel.Application.Common;
using SmartHotel.Application.Commands;
using SmartHotel.Contracts.Repositories.Managers;
using SmartHotel.Domain.Entities;
using SmartHotel.GrpcProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHotel.Application.Queries.Smoke.GetAllsSmoke;
using Microsoft.AspNetCore.Http.Features;
using Google.Protobuf.WellKnownTypes;

namespace SmartHotel.Application.Queries.Smoke.GetSmoke
{
    public class GetSmokeQueryHandler
        : IQueryHandler<GetSmokeQuery, SmartHotel.Domain.Entities.Smoke>
    {
        private readonly IAppRepositoryManager _repositoryManager;

        public GetSmokeQueryHandler(
            IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Result<SmartHotel.Domain.Entities.Smoke>> Handle(GetSmokeQuery request, CancellationToken cancellationToken)
        {
            return Result.Ok(await _repositoryManager.Smoke.GetByIdAsync(request.Id));
        }
    }
}
