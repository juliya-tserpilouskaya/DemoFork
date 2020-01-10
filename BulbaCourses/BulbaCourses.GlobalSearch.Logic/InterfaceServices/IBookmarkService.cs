using BulbaCourses.GlobalSearch.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.InterfaceServices
{
    public interface IBookmarkService
    {
        IEnumerable<Bookmark> GetAll();
        Task<IEnumerable<Bookmark>> GetAllAsync();
        Bookmark GetById(string id);
        Task<Bookmark> GetByIdAsync(string id);
        IEnumerable<Bookmark> GetByUserId(string userID);
        Task<IEnumerable<Bookmark>> GetByUserIdAsync(string userID);
        Bookmark Add(Bookmark bookmark);
        void RemoveById(string id);
        void RemoveAll();
    }
}
