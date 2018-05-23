using StoreOfBuild.Domain;
using System.Linq;

namespace StoreOfBuild.Data
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationDbContext _context { get; }

        public T GetId(int id)
        {
            return _context.Set<T>().SingleOrDefault( e => e.Id ==  id);
        }

        public void Save(T entity)
        {
            _context.Set<T>().Add(entity);
        }
    }
}