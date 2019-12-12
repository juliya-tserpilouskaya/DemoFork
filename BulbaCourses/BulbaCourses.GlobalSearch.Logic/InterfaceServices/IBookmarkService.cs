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
        Bookmark GetById(string id);
        IEnumerable<Bookmark> GetByUserId(string userID);
        Bookmark Add(Bookmark bookmark);
        void RemoveById(string id);
        void RemoveAll();
    }
}
