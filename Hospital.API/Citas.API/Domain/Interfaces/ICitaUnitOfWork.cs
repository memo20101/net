using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citas.API.Domain.Interfaces
{
    public interface ICitaUnitOfWork : IDisposable
    {
        ICitaRepository Citas { get; }

        int Complete();
    }
}
