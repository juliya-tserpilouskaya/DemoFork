using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using BulbaCourses.GlobalSearch.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Services
{
    class BookmarkService : IBookmarkService
    {
        public Bookmark Add(Bookmark bookmark)
        {
            return BookmarkStorage.Add(bookmark);
        }

        public IEnumerable<Bookmark> GetAll()
        {
            return BookmarkStorage.GetAll();
        }

        public Bookmark GetById(string id)
        {
            return BookmarkStorage.GetById(id);
        }

        public IEnumerable<Bookmark> GetByUserId(string userID)
        {
            return BookmarkStorage.GetByUserId(userID);
        }

        public void RemoveAll()
        {
            BookmarkStorage.RemoveAll();
        }

        public void RemoveById(string id)
        {
            BookmarkStorage.RemoveById(id);
        }
    }
}
