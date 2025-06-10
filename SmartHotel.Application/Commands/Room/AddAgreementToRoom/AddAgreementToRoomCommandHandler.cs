using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartHotel.Application.Commands.Room.RemoveAgreementFromRoom;
using SmartHotel.Contracts.Repositories.Managers;
using SmartHotel.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Application.Commands.Room.AddAgreementToRoom
{

    public class AddAgreementToRoomHandler 
    {
        private readonly AppDbContext _context;

        public AddAgreementToRoomHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(AddAgreementToRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _context.Rooms
                .Include(r => r.Agreements) // Cargar acuerdos existentes
                .FirstOrDefaultAsync(r => r.Id == request.Room.Id, cancellationToken);

            if (room == null) return Result.Fail("Agreement addition operation failed");

            var agreement = await _context.Agreements
                .FirstOrDefaultAsync(a => a.Id == request.Agreement.Id, cancellationToken);

            if (agreement == null) return Result.Fail("Agreement addition operation failed");

            room.Agreements.Add(agreement); // Agregar a la lista
            await _context.SaveChangesAsync(cancellationToken); // Guardar cambios en BD

            return Result.Ok();
        }
    }
}