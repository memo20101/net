using Recetas.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recetas.API.Infrastructure.Repositories
{
    public interface IRecetaRepository
    {
        IEnumerable<Receta> GetAll();
        Receta GetById(int id);
        void Add(Receta receta);
        void Update(Receta receta);
        void Delete(Receta receta);
    }
}
