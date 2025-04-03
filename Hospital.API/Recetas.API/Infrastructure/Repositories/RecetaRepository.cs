using Recetas.API.Domain.Entities;
using Recetas.API.Domain.Interfaces;
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

        public IEnumerable<Receta> GetAll()
        {
            return _context.Recetas.ToList();
        }

        public Receta GetById(int id)
        {
            return _context.Recetas.Find(id);
        }

        public void Add(Receta receta)
        {
            _context.Recetas.Add(receta);
            _context.SaveChanges();
        }

        public void Update(Receta receta)
        {
            var existente = _context.Recetas.Find(receta.Id);
            if (existente != null)
            {
                _context.Entry(existente).CurrentValues.SetValues(receta);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Receta> GetByPacienteId(int pacienteId)
        {
            return _context.Recetas.Where(r => r.PacienteId == pacienteId).ToList();
        }

        public IEnumerable<Receta> GetByMedicoId(int medicoId)
        {
            return _context.Recetas.Where(r => r.MedicoId == medicoId).ToList();
        }
    }
}