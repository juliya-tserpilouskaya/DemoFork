using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalSearch.Logic.Models
{
    public static class BookmarkStorage
    {
        private static List<Bookmark> _bookmarks = new List<Bookmark>() {
        new Bookmark()
        {
            UserId = Guid.NewGuid().ToString(),
            BookmarkDescription = "My new Bookmark 1"
        },
        new Bookmark()
        {
            UserId = Guid.NewGuid().ToString(),
            BookmarkDescription = "My new Bookmark 2"
        }
        };

        /// <summary>
        /// Get all users bookmarks from list (BD). Modification prohibited.
        /// </summary>
        /// <returns>Readonly list of bookmarks</returns>
        public static IEnumerable<Bookmark> GetAll()
        {
            return _bookmarks.AsReadOnly();
        }

        /// <summary>
        /// Get one bookmark from list (BD) by ID.
        /// </summary>
        /// <param name="id">Guid bookmark number</param>
        /// <returns>ID bookmark</returns>
        public static Bookmark GetById(string id)
        {
            return _bookmarks.SingleOrDefault(bookmark => bookmark.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Get bookmarks from list (BD) by UserId. Modification prohibited.
        /// </summary>
        /// <param name="userID">Guid UserId number</param>
        /// <returns>Readonly list of bookmarks for one user (by UserID)</returns>
        public static IEnumerable<Bookmark> GetByUserId(string userID)
        {
            return _bookmarks.AsReadOnly().Where(bookmark => bookmark.UserId.Contains(userID));
        }

        /// <summary>
        /// Add one new bookmark into list with ID (Generated on server).
        /// </summary>
        /// <param name="bookmark">Enter bookmark properties to add</param>
        /// <returns>Added bookmark</returns>
        public static Bookmark Add(Bookmark bookmark)
        {
            bookmark.Id = Guid.NewGuid().ToString();
            _bookmarks.Add(bookmark);
            return bookmark;
        }

        /// <summary>
        /// Remove one bookmark from list (BD) by ID.
        /// </summary>
        /// <param name="id">Guid bookmark number</param>
        public static void RemoveById(string id)
        {
            var bookmark = _bookmarks.SingleOrDefault(b => b.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            _bookmarks.Remove(bookmark);
        }

        /// <summary>
        /// Remove all bookmarks from list (BD).
        /// </summary>
        public static void RemoveAll()
        {
            _bookmarks.Clear();
        }
    }
}