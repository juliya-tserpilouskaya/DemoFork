using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Interfaces
{
    public interface IAuthorRepository : IDisposable
    {
        Task<AuthorDb> GetByIdAsync(string id);
        Task<IEnumerable<AuthorDb>> GetAllAsync();
        Task<AuthorDb> AddAsync(AuthorDb author);
        Task<AuthorDb> UpdateAsync(AuthorDb author);
        Task RemoveAsync(AuthorDb author);
        Task RemoveAsyncById(string id);
    }
}
