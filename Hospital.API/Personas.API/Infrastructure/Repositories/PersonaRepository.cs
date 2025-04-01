using Personas.API.Domain.Entities;
using Personas.API.Domain.Interfaces;
using Personas.API.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.API.Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonasContext _context;

        public PersonaRepository(PersonasContext context)
        {
            _context = context;
        }

        public IEnumerable<Persona> GetAll()
        {
            return _context.Personas.ToList();
        }

        public Persona GetById(int id)
        {
            return _context.Personas.Find(id);
        }

        public void Add(Persona persona)
        {
            _context.Personas.Add(persona);
        }

        public void Update(Persona persona)
        {
            _context.Entry(persona).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Persona persona)
        {
            _context.Personas.Remove(persona);
        }
    }
}