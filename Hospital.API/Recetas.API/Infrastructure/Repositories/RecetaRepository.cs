using Recetas.API.Domain.Entities;
using Recetas.API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recetas.API.Infrastructure.Repositories
{
    public class RecetaRepository : IRecetaRepository
    {
        private readonly RecetasContext _context;

        public RecetaRepository(RecetasContext context)
        {
            _context = context;
        }

        public IEnumerable<Receta> GetAll() => _context.Recetas.ToList();

        public Receta GetById(int id) => _context.Recetas.Find(id);

        public void Add(Receta receta) => _context.Recetas.Add(receta);

        public void Update(Receta receta) => _context.Entry(receta).State = System.Data.Entity.EntityState.Modified;

        public void Delete(Receta receta) => _context.Recetas.Remove(receta);
    }
}