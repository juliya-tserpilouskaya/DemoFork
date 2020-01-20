using BulbaCourses.Podcasts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Data.Interfaces
{
    public interface IManager<T>
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T db);
        Task<T> RemoveAsync(T db);
        Task<T> UpdateAsync(T db);
        Task<bool> ExistAsync(string name);
    }
}
