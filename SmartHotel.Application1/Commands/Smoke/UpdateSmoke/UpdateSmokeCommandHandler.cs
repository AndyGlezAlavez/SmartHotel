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


namespace SmartHotel.Application.Commands.Smoke.UpdateSmoke
{
   public class UpdateSmokeCommandHandler
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public UpdateSmokeCommandHandler(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }
        public async Task<Result> Handle(UpdateSmokeCommand request, CancellationToken cancellationToken)
        {
            //Si se puede actualizar una room y hacerla no apta a la renta, no agregar la relga de negocio
            _repositoryManager.Smoke.Update(request.Smoke);
            SmartHotel.Domain.Entities.Smoke smoke = request.Smoke;
            if (smoke == null) return Result.Fail("Update operation Fail");
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}
