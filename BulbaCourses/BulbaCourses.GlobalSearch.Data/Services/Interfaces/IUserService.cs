using BulbaCourses.GlobalSearch.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Services.Interfaces
{
    interface IUserService
    {
        IEnumerable<UserDB> GetAll();
        Task<IEnumerable<UserDB>> GetAllAsync();
        UserDB GetById(string id);
        Task<UserDB> GetByIdAsync(string id);
        UserDB Add(UserDB user);
        IEnumerable<BookmarkDB> GetBookmarksByUserId(string id);
        Task<IEnumerable<BookmarkDB>> GetBookmarksByUserIdAsync(string id);
        IEnumerable<BookmarkDB> GetBookmarksByUserId(string id);
        Task<IEnumerable<BookmarkDB>> GetBookmarksByUserIdAsync(string id);
        void RemoveById(string id);
        void RemoveAll();
    }
}
