using BulbaCourses.GlobalSearch.Infrastructure.Models;
using BulbaCourses.GlobalSearch.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.InterfaceServices
{
    public interface IBookmarkService
    {
        /// <summary>
        /// Returns all bookmarks
        /// </summary>
        /// <returns></returns>
        IEnumerable<BookmarkDTO> GetAll();

        /// <summary>
        /// Asynchronously returns all bookmarks
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<BookmarkDTO>> GetAllAsync();

        /// <summary>
        /// Returns bookmark by id
        /// </summary>
        /// <param name="id">search query id</param>
        /// <returns></returns>
        BookmarkDTO GetById(string id);

        /// <summary>
        /// Asynchronously returns bookmark by id
        /// </summary>
        /// <param name="id">search query id</param>
        /// <returns></returns>
        Task<BookmarkDTO> GetByIdAsync(string id);

        /// <summary>
        /// Returns bookmark by user id
        /// </summary>
        /// <param name="userID">User id</param>
        /// <returns></returns>
        IEnumerable<BookmarkDTO> GetByUserId(string userID);

        /// <summary>
        /// Asynchronously returns bookmark by user id
        /// </summary>
        /// <param name="userID">User id</param>
        /// <returns></returns>
        Task<IEnumerable<BookmarkDTO>> GetByUserIdAsync(string userID);

        /// <summary>
        /// Creates bookmark
        /// </summary>
        /// <param name="bookmark">search query</param>
        /// <returns></returns>
        BookmarkDTO Add(BookmarkDTO bookmark);

        /// <summary>
        /// Creates bookmark
        /// </summary>
        /// <param name="bookmark">search query</param>
        /// <returns></returns>
        Task<Result<BookmarkDTO>> AddAsync(BookmarkDTO bookmark);

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
        Task<Result> RemoveByIdAsync(string id);


        /// <summary>
        /// Removes all bookmarks from database
        /// </summary>
        void RemoveAll();
    }
}
