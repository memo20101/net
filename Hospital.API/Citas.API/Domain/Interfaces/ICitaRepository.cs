using Citas.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citas.API.Domain.Interfaces
{
    public interface ICitaRepository
    {
        IEnumerable<Cita> GetAll();
        Cita GetById(int id);
        void Add(Cita cita);
        void Update(Cita cita);
        void Delete(Cita cita);
  
    }
}
