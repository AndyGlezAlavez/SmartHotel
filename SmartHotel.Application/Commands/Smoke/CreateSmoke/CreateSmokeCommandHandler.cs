using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHotel.Domain;
using SmartHotel.Persistence;
using SmartHotel.Contracts.Repositories.Managers;
using SmartHotel.Domain.Entities;
using SmartHotel.GrpcProtos;
using SmartHotel.Domain.Rules;

namespace SmartHotel.Application.Commands.Smoke.CreateSmoke
{
    public class CreateSmokeCommandHandler
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public CreateSmokeCommandHandler(IAppRepositoryManager repositoryManager) {
            _repositoryManager = repositoryManager;
                
        }
        
        public async Task<Result> Handle(CreateSmokeCommand request, CancellationToken cancellationToken ) {
            Result<RoomMustBeSave> codeResult = RoomMustBeSave.Create(request.SmokeUnit, request.Reference, request.Value);
            if (codeResult.IsFailed)
                return codeResult.ToResult();
            var smoke = new Domain.Entities.Smoke(request.SmokeUnit, Guid.NewGuid(), request.Value, request.Reference, request.Room);

            await _repositoryManager.Smoke.AddAsync(smoke);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            
            return Result.Ok(); 
        }  
    }
}
