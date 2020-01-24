using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Services.Interfaces
{
    public interface IBookmarkDbService
    {
        /// <summary>
        /// Returns all bookmarks
        /// </summary>
        /// <returns></returns>
        IEnumerable<BookmarkDB> GetAll();

        /// <summary>
        /// Asynchronously returns all bookmarks
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<BookmarkDB>> GetAllAsync();

        /// <summary>
        /// Returns bookmark by id
        /// </summary>
        /// <param name="id">Bookmark id</param>
        /// <returns></returns>
        BookmarkDB GetById(string id);

        /// <summary>
        /// Asynchronously returns bookmark by id
        /// </summary>
        /// <param name="id">Bookmark id</param>
        /// <returns></returns>
        Task<BookmarkDB> GetByIdAsync(string id);

        /// <summary>
        /// Returns bookmark by user id
        /// </summary>
        /// <param name="userID">User id</param>
        /// <returns></returns>
        IEnumerable<BookmarkDB> GetByUserId(string userID);

        /// <summary>
        /// Asynchronously returns bookmark by user id
        /// </summary>
        /// <param name="userID">User id</param>
        /// <returns></returns>
        Task<IEnumerable<BookmarkDB>> GetByUserIdAsync(string userID);

        /// <summary>
        /// Creates new bookmark
        /// </summary>
        /// <param name="bookmark">New user</param>
        /// <returns></returns>
        BookmarkDB Add(BookmarkDB bookmark);


        /// <summary>
        /// Creates new bookmark async
        /// </summary>
        /// <param name="bookmark">New user</param>
        /// <returns></returns>
        Task<Result<BookmarkDB>> AddAsync(BookmarkDB bookmark);


        /// <summary>
        /// Removes bookmarks by id
        /// </summary>
        /// <param name="id">Bookmark id</param>
        /// <returns></returns>
        void RemoveById(string id);

        /// <summary>
        /// Removes bookmarks by id async
        /// </summary>
        /// <param name="id">Bookmark id</param>
        /// <returns></returns>
        Task<Result<BookmarkDB>> RemoveByIdAsync(string id);

        /// <summary>
        /// Removes all bookmarks from database
        /// </summary>
        void RemoveAll();
    }
}
