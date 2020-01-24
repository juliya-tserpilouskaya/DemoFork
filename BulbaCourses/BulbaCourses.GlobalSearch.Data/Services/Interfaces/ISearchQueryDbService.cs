using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Services.Interfaces
{
    public interface ISearchQueryDbService
    {
        /// <summary>
        /// Returns all search queries
        /// </summary>
        /// <returns></returns>
        IEnumerable<SearchQueryDB> GetAll();

        /// <summary>
        /// Returns all search queries asynchronously 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SearchQueryDB>> GetAllAsync();

        /// <summary>
        /// Returns search query by id
        /// </summary>
        /// <param name="id">search query id</param>
        /// <returns></returns>
        SearchQueryDB GetById(string id);

        /// <summary>
        /// Returns search query by id asynchronously
        /// </summary>
        /// <param name="id">search query id</param>
        /// <returns></returns>
        Task<SearchQueryDB> GetByIdAsync(string id);

        /// <summary>
        /// Returns search query by user id
        /// </summary>
        /// <param name="userID">User id</param>
        /// <returns></returns>
        IEnumerable<SearchQueryDB> GetByUserId(string userID);

        /// <summary>
        /// Asynchronously returns search query by user id
        /// </summary>
        /// <param name="userID">User id</param>
        Task<IEnumerable<SearchQueryDB>> GetByUserIdAsync(string userID);

        /// <summary>
        /// Creates search query
        /// </summary>
        /// <param name="query">search query</param>
        SearchQueryDB Add(SearchQueryDB query);

        /// <summary>
        /// Creates search query async
        /// </summary>
        /// <param name="query">search query</param>
        Task<Result<SearchQueryDB>> AddAsync(SearchQueryDB query);

        /// <summary>
        /// Removes search query by id
        /// </summary>
        /// <param name="id"></param>
        void RemoveById(string id);

        /// <summary>
        /// Removes search query by id async
        /// </summary>
        /// <param name="id"></param>
        Task<Result<SearchQueryDB>> RemoveByIdAsync(string id);


        /// <summary>
        /// Removes search query from database
        /// </summary>
        void RemoveAll();

        Task<bool> AnyAsync(string id);
    }
}
