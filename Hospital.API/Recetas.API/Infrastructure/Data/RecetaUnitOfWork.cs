using Recetas.API.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recetas.API.Infrastructure.Data
{
    public class RecetaUnitOfWork : IRecetaUnitOfWork
    {
        private readonly RecetasContext _context;

        public IRecetaRepository Recetas { get; private set; }

        public RecetaUnitOfWork(RecetasContext context, IRecetaRepository recetaRepository)
        {
            _context = context;
            Recetas = recetaRepository;
        }

        public int Complete() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}