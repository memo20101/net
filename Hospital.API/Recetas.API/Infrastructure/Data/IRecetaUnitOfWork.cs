using Recetas.API.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recetas.API.Infrastructure.Data
{
    public interface IRecetaUnitOfWork : IDisposable
    {
        IRecetaRepository Recetas { get; }
        int Complete();
    }
}
