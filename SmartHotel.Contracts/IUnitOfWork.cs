using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Contracts
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken) ;
    }
}
