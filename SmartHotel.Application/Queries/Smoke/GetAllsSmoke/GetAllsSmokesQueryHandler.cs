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
/*
namespace SmartHotel.Application.Queries.Smoke.GetAllsSmoke
{
    public class GetAllsSmokesQueryHandler
        :IQueryHandler<GetAllsSmokesQuery, IEnumerable<SmartHotel.Domain.Entities.Smoke>>
        {
           private readonly IAppRepositoryManager _repositoryManager;

            public GetAllsSmokesQueryHandler(
                IAppRepositoryManager repositoryManager)
            {
                _repositoryManager = repositoryManager;
            }

            public async Task<Result<IEnumerable<SmartHotel.Domain.Entities.Smoke>>> Handle(GetAllsSmokesQuery request, CancellationToken cancellationToken)
            {
                return Result.Ok(await _repositoryManager.Variable.GetVariablesAsync());
            }
        }
    }
*/