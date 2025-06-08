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
using SmartHotel.Application.Queries.Room.GetAllsRoom;

namespace SmartHotel.Application.Queries.Room.GetAllsRoom
{
    public class GetAllRoomQueryHandler
        : IQueryHandler<SmartHotel.Application.Queries.Room.GetAllsRoom.GetAllRoomQuery, IEnumerable<Domain.Entities.Room>>
    {
        private readonly IAppRepositoryManager _repositoryManager;

        public GetAllRoomQueryHandler(
            IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Result<IEnumerable<Domain.Entities.Room>>> Handle(SmartHotel.Application.Queries.Room.GetAllsRoom.GetAllRoomQuery request, CancellationToken cancellationToken)
        {
            return Result.Ok(await _repositoryManager.Room.GetRoomsAsync());
        }
    }
}