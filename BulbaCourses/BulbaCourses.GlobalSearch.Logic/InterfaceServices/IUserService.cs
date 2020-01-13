using BulbaCourses.GlobalSearch.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.InterfaceServices
{
    public interface IUserService
    {
        /// <summary>
        /// Returns all users
        /// </summary>
        IEnumerable<UserDTO> GetAll();

        /// <summary>
        /// Asynchronously returns all users
        /// </summary>
        Task<IEnumerable<UserDTO>> GetAllAsync();

        /// <summary>
        /// Returns user by id
        /// </summary>
        /// <param name="id">User id</param>
        UserDTO GetById(string id);

        /// <summary>
        /// Asynchronously returns user by id
        /// </summary>
        /// <param name="id">User id</param>
        Task<UserDTO> GetByIdAsync(string id);

        /// <summary>
        /// Creates new user
        /// </summary>
        /// <param name="user">New user</param>
        UserDTO Add(UserDTO user);

        /// <summary>
        /// Returns bookmarks by user id
        /// </summary>
        /// <param name="id">User id</param>
        IEnumerable<BookmarkDTO> GetBookmarksByUserId(string id);

        /// <summary>
        /// Asynchronously returns bookmarks by user id
        /// </summary>
        /// <param name="id">User id</param>
        Task<IEnumerable<BookmarkDTO>> GetBookmarksByUserIdAsync(string id);

        /// <summary>
        /// Returns search queries by user id
        /// </summary>
        /// <param name="id">User id</param>
        IEnumerable<SearchQueryDTO> GetSearchQueriesByUserId(string id);

        /// <summary>
        /// Asynchronously returns search queries by user id
        /// </summary>
        /// <param name="id">User id</param>
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
