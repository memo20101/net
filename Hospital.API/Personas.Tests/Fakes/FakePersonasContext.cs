using Personas.API.Domain.Entities;
using Personas.API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Tests.Fakes
{
    public class FakePersonasContext : PersonasContext
    {
        public FakePersonasContext()
        {
            Personas = new FakeDbSet<Persona>();
        }

        public override DbSet<Persona> Personas { get; set; }
    }

    // Clase base para FakeDbSet
    public class FakeDbSet<T> : DbSet<T>, IQueryable, IEnumerable<T> where T : class
    {
        private readonly List<T> _data;

        public FakeDbSet()
        {
            _data = new List<T>();
        }

        public override T Add(T entity)
        {
            _data.Add(entity);
            return entity;
        }

        public override T Remove(T entity)
        {
            _data.Remove(entity);
            return entity;
        }

        public override IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _data.AddRange(entities);
            return entities;
        }

        public override T Find(params object[] keyValues)
        {
            // Aquí puedes implementar lógica de búsqueda si lo deseas
            return _data.FirstOrDefault();
        }

        public IEnumerator<T> GetEnumerator() => _data.GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

        public Type ElementType => typeof(T);

        public System.Linq.Expressions.Expression Expression => _data.AsQueryable().Expression;

        public IQueryProvider Provider => _data.AsQueryable().Provider;
    }
}
