using BulbaCourses.GlobalSearch.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Services.Interfaces
{
    public interface IUserDbService
    {
        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserDB> GetAll();

        /// <summary>
        /// Asynchronously returns all users
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserDB>> GetAllAsync();

        /// <summary>
        /// Returns user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        UserDB GetById(string id);

        /// <summary>
        /// Asynchronously returns user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        Task<UserDB> GetByIdAsync(string id);

        /// <summary>
        /// Creates new user
        /// </summary>
        /// <param name="user">New user</param>
        /// <returns></returns>
        UserDB Add(UserDB user);

        /// <summary>
        /// Returns bookmarks by user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        IEnumerable<BookmarkDB> GetBookmarksByUserId(string id);

        /// <summary>
        /// Asynchronously returns bookmarks by user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        Task<IEnumerable<BookmarkDB>> GetBookmarksByUserIdAsync(string id);

        /// <summary>
        /// Returns search queries by user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        IEnumerable<SearchQueryDB> GetSearchQueriesByUserId(string id);

        /// <summary>
        /// Asynchronously returns search queries by user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        Task<IEnumerable<SearchQueryDB>> GetSearchQueriesByUserIdAsync(string id);

        /// <summary>
        /// Removes user by id
        /// </summary>
        /// <param name="id">User id</param>
        void RemoveById(string id);

        /// <summary>
        /// Removes all users from database
        /// </summary>
        void RemoveAll();
    }
}
