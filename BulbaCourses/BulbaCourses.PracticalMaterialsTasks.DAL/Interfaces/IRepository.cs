using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTasks.DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        
        Task<IEnumerable<T>> GetAll();
        T Get(string id);
        Task<T> GetTaskAsync(string id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        Task<T> Create(T item);
        Task<T> Update(T item);
        Task<T> Delete(string id);
    }
}
