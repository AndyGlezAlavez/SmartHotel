using FluentResults;
using SmartHotel.Application.Common;
using SmartHotel.Contracts.Repositories.Managers;
using SmartHotel.Domain.Entities;


namespace SmartHotel.Application.Queries.Room.GetAllRoom
{
    public class GetAllRoomQueryHandler
        : IQueryHandler<GetAllRoomQuery, IEnumerable<SmartHotel.Domain.Entities.Room>>
    {
        private readonly IAppRepositoryManager _repositoryManager;

        public GetAllRoomQueryHandler(
            IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Result<IEnumerable<Domain.Entities.Room>>> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
        {
            return Result.Ok(await _repositoryManager.Room.GetRoomsAsync());
        }
    }
}