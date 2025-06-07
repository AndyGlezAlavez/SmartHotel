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

namespace SmartHotel.Application.Commands.Smoke.DeleteSmoke
{
    public class DeleteSmokeCommandHandler
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public DeleteSmokeCommandHandler(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }
        public async Task<Result> Handle(DeleteSmokeCommand request, CancellationToken cancellationToken)
        {
            _repositoryManager.Variable.DeleteById(request.ID);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok(); 
        }
    }
}
