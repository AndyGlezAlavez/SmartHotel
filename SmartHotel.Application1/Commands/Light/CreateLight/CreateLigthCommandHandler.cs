using FluentResults;
using SmartHotel.Application.Commands.Light.CreateLight;
using SmartHotel.Application.Common;
using SmartHotel.Contracts.Repositories.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Light.CreateLight
{
    public class CreateLigthCommandHandler : ICommandHandler<CreateLightCommand>
    {
    private readonly IAppRepositoryManager _repositoryManager;
    public CreateLigthCommandHandler(IAppRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<Result> Handle(CreateLightCommand request, CancellationToken cancellationToken)
    {
        var light = new Domain.Entities.Light(request.LightUnit,Guid.NewGuid(), request.Value, request.Reference,  request.Room);

        await _repositoryManager.Light.AddAsync(light);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
}
