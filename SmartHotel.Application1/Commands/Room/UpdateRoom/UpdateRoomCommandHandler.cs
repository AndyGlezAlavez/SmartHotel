using SmartHotel.Contracts.Repositories.Managers;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHotel.Domain;
using SmartHotel.Persistence;
using SmartHotel.Domain.Entities;
using SmartHotel.GrpcProtos;
using SmartHotel.Domain.Rules;

namespace SmartHotel.Application.Commands.Room.UpdateRoom
{
    public class UpdateRoomCommandHandler
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public UpdateRoomCommandHandler(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }
        public async Task<Result> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            
            _repositoryManager.Room.Update(request.Room);
            SmartHotel.Domain.Entities.Room Room  = request.Room;
            if (Room == null) return Result.Fail("Update operation Fail");
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}