using BulbaCourses.Analytics.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Repositories
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly List<T> _context;

        protected AbstractRepository(List<T> context)
        {
            _context = context;
        }

        public void Create(T item)
        {            
            _context.Add(item);
        }

        public void Delete(Predicate<T> predicate)
        {
            T item = _context.Find(predicate);

            if (item != null)
                _context.Remove(item);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Where(predicate).ToList();
        }

        public T Read(Predicate<T> predicate)
        {
            return _context.Find(predicate);
        }

        public IEnumerable<T> ReadAll()
        {
            return _context.AsReadOnly();
        }

        public void Update(T item, Predicate<T> predicate)
        {
            Delete(predicate);
            Create(item);
        }
    }
}
