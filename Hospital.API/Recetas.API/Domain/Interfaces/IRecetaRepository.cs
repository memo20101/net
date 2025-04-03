using Recetas.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recetas.API.Domain.Interfaces
{
    public interface IRecetaRepository
    {
        IEnumerable<Receta> GetAll();
        Receta GetById(int id);
        void Add(Receta receta);
        void Update(Receta receta);
        IEnumerable<Receta> GetByPacienteId(int pacienteId);
        IEnumerable<Receta> GetByMedicoId(int medicoId);
    }
}
