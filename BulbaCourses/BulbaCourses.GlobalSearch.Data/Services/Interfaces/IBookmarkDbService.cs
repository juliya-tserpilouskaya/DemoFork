using BulbaCourses.GlobalSearch.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Services.Interfaces
{
    interface IBookmarkDbService
    {
        IEnumerable<BookmarkDB> GetAll();
        Task<IEnumerable<BookmarkDB>> GetAllAsync();
        BookmarkDB GetById(string id);
        Task<BookmarkDB> GetByIdAsync(string id);
        IEnumerable<BookmarkDB> GetByUserId(string userID);
        Task<IEnumerable<BookmarkDB>> GetByUserIdAsync(string userID);
        BookmarkDB Add(BookmarkDB bookmark);
        void RemoveById(string id);
        void RemoveAll();
    }
}
