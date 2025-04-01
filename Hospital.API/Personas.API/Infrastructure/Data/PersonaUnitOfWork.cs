using Personas.API.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.API.Infrastructure.Data
{
    public class PersonaUnitOfWork : IPersonaUnitOfWork
    {
        private readonly PersonasContext _context;
        public IPersonaRepository Personas { get; private set; }

        public PersonaUnitOfWork(PersonasContext context, IPersonaRepository personaRepository)
        {
            _context = context;
            Personas = personaRepository;
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