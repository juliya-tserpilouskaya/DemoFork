using AutoMapper;
using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Services.Interfaces;
using BulbaCourses.GlobalSearch.Infrastructure.Models;
using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using BulbaCourses.GlobalSearch.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Services
{
    public class SearchQueryService : ISearchQueryService
    {
        ISearchQueryDbService _searchQueryDb;
        IMapper _mapper;

        public SearchQueryService(IMapper mapper, ISearchQueryDbService searchQueryDb)
        {
            _searchQueryDb = searchQueryDb;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all search queries
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SearchQueryDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<SearchQueryDB>, List<SearchQueryDTO>>(_searchQueryDb.GetAll());
        }

        /// <summary>
        /// Returns all search queries asynchronously 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SearchQueryDTO>> GetAllAsync()
        {
            var data = await _searchQueryDb.GetAllAsync();
            return _mapper.Map<IEnumerable<SearchQueryDB>, List<SearchQueryDTO>>(data);
        }

        /// <summary>
        /// Returns search query by id
        /// </summary>
        /// <param name="id">search query id</param>
        /// <returns></returns>
        public SearchQueryDTO GetById(string id)
        {
            var query = _searchQueryDb.GetById(id);
            return new SearchQueryDTO { Id = query.Id, Query = query.Query, Date = query.Created, UserId = query.UserId };
        }

        /// <summary>
        /// Returns search query by id asynchronously
        /// </summary>
        /// <param name="id">search query id</param>
        /// <returns></returns>
        public async Task<SearchQueryDTO> GetByIdAsync(string id)
        {
            var query = await _searchQueryDb.GetByIdAsync(id);
            return new SearchQueryDTO { Id = query.Id, Query = query.Query, Date = query.Created, UserId = query.UserId };
        }

        /// <summary>
        /// Returns search query by user id
        /// </summary>
        /// <param name="userID">User id</param>
        public IEnumerable<SearchQueryDTO> GetByUserId(string userID)
        {
            return _mapper.Map<IEnumerable<SearchQueryDB>, List<SearchQueryDTO>>(_searchQueryDb.GetByUserId(userID));
        }

        /// <summary>
        /// Asynchronously returns search query by user id
        /// </summary>
        /// <param name="userID">User id</param>
        public async Task<IEnumerable<SearchQueryDTO>> GetByUserIdAsync(string userID)
        {
            var data = await _searchQueryDb.GetByUserIdAsync(userID);
            return _mapper.Map<IEnumerable<SearchQueryDB>, List<SearchQueryDTO>>(data);
        }

        /// <summary>
        /// Creates search query
        /// </summary>
        /// <param name="query">search query</param>
        /// <returns></returns>
        public SearchQueryDTO Add(SearchQueryDTO query)
        {
            SearchQueryDB queryDb = new SearchQueryDB() { Id = query.Id, Created = query.Date, Query = query.Query, UserId = query.UserId };
            return _mapper.Map<SearchQueryDB, SearchQueryDTO>(_searchQueryDb.Add(queryDb));
        }

        /// <summary>
        /// Creates search query async
        /// </summary>
        /// <param name="query">search query</param>
        /// <returns></returns>
        public async Task<Result<SearchQueryDTO>> AddAsync(SearchQueryDTO query)
        {
            SearchQueryDB queryDb = new SearchQueryDB() { Id = query.Id, Created = query.Date, Query = query.Query, UserId = query.UserId };
            var result = await _searchQueryDb.AddAsync(queryDb);
            return result.IsSuccess ? Result<SearchQueryDTO>.Ok(_mapper.Map<SearchQueryDTO>(result.Data))
                : Result<SearchQueryDTO>.Fail<SearchQueryDTO>(result.Message);
        }

        /// <summary>
        /// Removes search query by id
        /// </summary>
        /// <param name="id"></param>
        public void RemoveById(string id)
        {
            _searchQueryDb.RemoveById(id);
        }

        /// <summary>
        /// Removes search query from database
        /// </summary>
        public void RemoveAll()
        {
            _searchQueryDb.RemoveAll();
        }

        public Task<Result> RemoveByIdAsync(string id)
        {
            _searchQueryDb.RemoveByIdAsync(id);
            return Task.FromResult(Result.Ok());
        }

        //useless method for test only
        public async Task<bool> AnyAsync(string id)
        {
            return await _searchQueryDb.AnyAsync(id);
        }
    }
}
