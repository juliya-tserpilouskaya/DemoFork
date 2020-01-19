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
        Task<T> GetById(string id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T db);
        Task<T> Remove(T db);
        Task<T> Update(T db);
    }
}
