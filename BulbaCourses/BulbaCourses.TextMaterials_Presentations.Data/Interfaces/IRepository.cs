using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Add a T item to the database
        /// </summary>
        /// <param name="item"></param>
        void Add(T item);

        /// <summary>
        /// Get FirstOrDefault T-DB item from the database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(string id);

        /// <summary>
        /// Get all T-DB items fron the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Update T item in the database
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);

        /// <summary>
        /// Delete item from the database by id
        /// </summary>
        /// <param name="id"></param>
        void DeleteById(string id);
    }
}
