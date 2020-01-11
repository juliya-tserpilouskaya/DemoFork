using BulbaCourses.GlobalSearch.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.InterfaceServices
{
    interface IUserService
    {
        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserDTO> GetAll();

        /// <summary>
        /// Asynchronously returns all users
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserDTO>> GetAllAsync();

        /// <summary>
        /// Returns user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        UserDTO GetById(string id);

        /// <summary>
        /// Asynchronously returns user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        Task<UserDTO> GetByIdAsync(string id);

        /// <summary>
        /// Creates new user
        /// </summary>
        /// <param name="user">New user</param>
        /// <returns></returns>
        UserDTO Add(UserDTO user);

        /// <summary>
        /// Returns bookmarks by user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        IEnumerable<BookmarkDTO> GetBookmarksByUserId(string id);

        /// <summary>
        /// Asynchronously returns bookmarks by user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        Task<IEnumerable<BookmarkDTO>> GetBookmarksByUserIdAsync(string id);

        /// <summary>
        /// Returns search queries by user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        IEnumerable<SearchQueryDTO> GetSearchQueriesByUserId(string id);

        /// <summary>
        /// Asynchronously returns search queries by user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        Task<IEnumerable<SearchQueryDTO>> GetSearchQueriesByUserIdAsync(string id);

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
