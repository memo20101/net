using Citas.API.Commands;
using Citas.API.Domain.Entities;
using Citas.API.Domain.Interfaces;
using Citas.API.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citas.API.Infrastructure.Repositories
{
    public class CitaRepository : ICitaRepository
    {
        private readonly CitasContext _context;

        public CitaRepository(CitasContext context)
        {
            _context = context;
        }

        public IEnumerable<Cita> GetAll()
        {
            return _context.Citas.ToList();
        }

        public Cita GetById(int id)
        {
            return _context.Citas.Find(id);
        }

        public void Add(Cita cita)
        {
            _context.Citas.Add(cita);
            _context.SaveChanges();
        }

        public void Update(Cita cita)
        {
            var citaExistente = _context.Citas.Find(cita.Id);
            if (citaExistente != null)
            {
                _context.Entry(citaExistente).CurrentValues.SetValues(cita);
                _context.SaveChanges();
            }
        }

        public void Delete(Cita cita)
        {
            _context.Citas.Remove(cita);
            _context.SaveChanges();
        }
    }
}