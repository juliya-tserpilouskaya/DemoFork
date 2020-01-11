using AutoMapper;
using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Services.Interfaces;
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

        public SearchQueryService(ISearchQueryDbService searchQueryDb)
        {
            _searchQueryDb = searchQueryDb;
        }

        /// <summary>
        /// Returns all search queries
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SearchQueryDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<SearchQueryDB, SearchQueryDTO>();
            }).CreateMapper();
            return mapper.Map<IEnumerable<SearchQueryDB>, List<SearchQueryDTO>>(_searchQueryDb.GetAll());
        }

        /// <summary>
        /// Returns all search queries asynchronously 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SearchQueryDTO>> GetAllAsync()
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<SearchQueryDB, SearchQueryDTO>();
            }).CreateMapper();
            var data = await _searchQueryDb.GetAllAsync();
            return mapper.Map<IEnumerable<SearchQueryDB>, List<SearchQueryDTO>>(data);
        }

        /// <summary>
        /// Returns search query by id
        /// </summary>
        /// <param name="id">search query id</param>
        /// <returns></returns>
        public SearchQueryDTO GetById(string id)
        {
            var query = _searchQueryDb.GetById(id);
            return new SearchQueryDTO { Id = query.Id, Query = query.Query, Date = query.Created };
        }

        /// <summary>
        /// Returns search query by id asynchronously
        /// </summary>
        /// <param name="id">search query id</param>
        /// <returns></returns>
        public async Task<SearchQueryDTO> GetByIdAsync(string id)
        {
            var query = await _searchQueryDb.GetByIdAsync(id);
            return new SearchQueryDTO { Id = query.Id, Query = query.Query, Date = query.Created };
        }

        /// <summary>
        /// Creates search query
        /// </summary>
        /// <param name="query">search query</param>
        /// <returns></returns>
        public SearchQueryDTO Add(SearchQueryDTO query)
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<SearchQueryDB, SearchQueryDTO>();
            }).CreateMapper();
            SearchQueryDB queryDb = new SearchQueryDB() { Id = query.Id, Created = query.Date, Query = query.Query };
            return mapper.Map<SearchQueryDB, SearchQueryDTO>(_searchQueryDb.Add(queryDb));
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

        //useless method for test only
        public async Task<bool> AnyAsync(string id)
        {
            return await _searchQueryDb.AnyAsync(id);
        }
    }
}
