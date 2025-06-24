using SmartHotel.Contracts;
using SmartHotel.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

            public UnitOfWork(AppDbContext context)
            {
                _context = context;

                // Opcional: lanzar excepción si no se puede conectar
                if (!_context.Database.CanConnect())
                    throw new InvalidOperationException("No se pudo conectar a la base de datos.");
            }

            public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

    }
}
