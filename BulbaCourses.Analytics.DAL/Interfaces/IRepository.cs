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
        /// <summary>
        /// Creates an item in repository
        /// </summary>
        /// <param name="item"></param>
        void Create(T item);

        /// <summary>
        /// Findes items in storage
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<T> Find(Func<T, bool> predicate);

        /// <summary>
        /// Updates an item in storage
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);

        /// <summary>
        /// Deletes an item in storage
        /// </summary>
        /// <param name="item"></param>
        void Delete(T item); 
    }
}
