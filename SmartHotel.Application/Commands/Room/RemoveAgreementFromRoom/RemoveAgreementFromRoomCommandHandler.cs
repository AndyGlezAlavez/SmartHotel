using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartHotel.Application.Commands.Room.DeleteRoom;
using SmartHotel.Contracts.Repositories.Managers;
using SmartHotel.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Room.RemoveAgreementFromRoom
{
    public class RemoveAgreementFromRoomHandler {
        private readonly AppDbContext _context;

        public RemoveAgreementFromRoomHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(RemoveAgreementFromRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _context.Rooms
                .Include(r => r.Agreements) // Cargar acuerdos existentes
                .FirstOrDefaultAsync(r => r.Id == request.Room.Id, cancellationToken);

            if (room == null) return Result.Fail("Remove Agreement Operation failed");

            var agreement = room.Agreements.FirstOrDefault(a => a.Id == request.Agreement.Id);
            if (agreement == null) return Result.Fail("Remove Agreement Operation failed");

            room.Agreements.Remove(agreement); // Eliminar de la lista
            await _context.SaveChangesAsync(cancellationToken); // Guardar cambios en BD

            return Result.Ok();
        }
    }
}
