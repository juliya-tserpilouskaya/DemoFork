using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Interfaces
{
    /// <summary>
    /// Provides a mechanism for working Repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        T Read(Predicate<T> predicate);

        IEnumerable<T> ReadAll();               

        void Update(T item, Predicate<T> predicate);

        void Delete(Predicate<T> predicate);

        IEnumerable<T> Find(Func<T, bool> predicate);
    }
}
