using Citas.API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citas.API.Domain.Interfaces
{
    public class CitaUnitOfWork : ICitaUnitOfWork
    {
        private readonly CitasContext _context;
        public ICitaRepository Citas { get; private set; }

        public CitaUnitOfWork(CitasContext context, ICitaRepository citaRepository)
        {
            _context = context;
            Citas = citaRepository;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}