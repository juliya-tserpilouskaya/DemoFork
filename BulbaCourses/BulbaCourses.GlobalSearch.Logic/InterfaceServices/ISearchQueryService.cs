using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Infrastructure.Models;
using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.Models;

namespace BulbaCourses.GlobalSearch.Logic.InterfaceServices
{
    public interface ISearchQueryService
    {
        /// <summary>
        /// Returns all search queries
        /// </summary>
        /// <returns></returns>
        IEnumerable<SearchQueryDTO> GetAll();

        /// <summary>
        /// Returns all search queries asynchronously 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SearchQueryDTO>> GetAllAsync();

        /// <summary>
        /// Returns search query by id
        /// </summary>
        /// <param name="id">search query id</param>
        /// <returns></returns>
        SearchQueryDTO GetById(string id);

        /// <summary>
        /// Returns search query by id asynchronously
        /// </summary>
        /// <param name="id">search query id</param>
        /// <returns></returns>
        Task<SearchQueryDTO> GetByIdAsync(string id);

        /// <summary>
        /// Returns search query by user id
        /// </summary>
        /// <param name="userID">User id</param>
        IEnumerable<SearchQueryDTO> GetByUserId(string userID);

        /// <summary>
        /// Asynchronously returns search query by user id
        /// </summary>
        /// <param name="userID">User id</param>
        Task<IEnumerable<SearchQueryDTO>> GetByUserIdAsync(string userID);

        /// <summary>
        /// Creates search query
        /// </summary>
        /// <param name="query">search query</param>
        /// <returns></returns>
        SearchQueryDTO Add(SearchQueryDTO query);

        /// <summary>
        /// Creates search query async
        /// </summary>
        /// <param name="query">search query</param>
        /// <returns></returns>
        Task<Result<SearchQueryDTO>> AddAsync(SearchQueryDTO course);

        /// <summary>
        /// Removes search query by id
        /// </summary>
        /// <param name="id"></param>
        void RemoveById(string id);

        /// <summary>
        /// Removes search query by id async
        /// </summary>
        /// <param name="id"></param>
        Task<Result> RemoveByIdAsync(string id);


        /// <summary>
        /// Removes search query from database
        /// </summary>
        void RemoveAll();

        Task<bool> AnyAsync(string id);
    }
}
