using FluentResults;
using SmartHotel.Application.Commands.Room.CreateRoom;
using SmartHotel.Application.Common;
using SmartHotel.Contracts.Repositories.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Room.CreateRoom
{
    public class CreateRoomCommandHandler
        : ICommandHandler<CreateRoomCommand>
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public CreateRoomCommandHandler(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }

        public async Task<Result> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Domain.Entities.Room(Guid.NewGuid(), request.Number, request.RentalPrice, request.RoomType, request.Temperature,  request.Smoke, request.Light);

            await _repositoryManager.Room.AddAsync(room);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
