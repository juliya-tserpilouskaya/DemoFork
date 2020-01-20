using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        UserDb GetById(string userId);
        IEnumerable<UserDb> GetAll();
        void Add(UserDb user);
        void Update(UserDb user);
        void Remove(UserDb user);

        Task<UserDb> GetByIdAsync(string userId);
        Task<IEnumerable<UserDb>> GetAllAsync();
        Task<UserDb> AddAsync(UserDb userDb);
        Task<UserDb> UpdateAsync(UserDb userDb);
        Task RemoveAsync(UserDb user);
        Task RemoveAsyncById(string userId);
    }
}
