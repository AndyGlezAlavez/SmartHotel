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
using Microsoft.AspNetCore.Http.Features;
using Google.Protobuf.WellKnownTypes;
using SmartHotel.Application.Queries.Room.GetRoom;
using FluentResults;

namespace SmartHotel.Application.Queries.Room.GetRoom
{
    public class GetRoomQueryHandler
        : IQueryHandler<GetRoomQuery, SmartHotel.Domain.Entities.Room>
    {
        private readonly IAppRepositoryManager _repositoryManager;

        public GetRoomQueryHandler(
            IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Result<SmartHotel.Domain.Entities.Room>> Handle(GetRoomQuery request, CancellationToken cancellationToken)
        {
            return Result.Ok(await _repositoryManager.Room.GetByIdAsync(request.Id));
        }
    }
}
