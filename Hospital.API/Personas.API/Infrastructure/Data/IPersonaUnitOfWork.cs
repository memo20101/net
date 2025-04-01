using Personas.API.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.API.Infrastructure.Data
{
    public interface IPersonaUnitOfWork : IDisposable
    {
        IPersonaRepository Personas { get; }
        int Complete();
    }
}
