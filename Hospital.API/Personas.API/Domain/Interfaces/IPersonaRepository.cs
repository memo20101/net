using Personas.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.API.Domain.Interfaces
{
    public interface IPersonaRepository
    {
        IEnumerable<Persona> GetAll();
        Persona GetById(int id);
        void Add(Persona persona);
        void Update(Persona persona);
        void Delete(Persona persona);
    }
}
