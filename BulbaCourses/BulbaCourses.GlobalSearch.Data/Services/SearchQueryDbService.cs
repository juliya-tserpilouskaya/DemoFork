using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Services
{
    public class SearchQueryDbService : ISearchQueryDbService
    {
        private GlobalSearchContext _context = new GlobalSearchContext();

        private bool _isDisposed;

        /// <summary>
        /// Returns all search queries
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SearchQueryDB> GetAll()
        {
            return _context.SearchQueries;
        }

        /// <summary>
        /// Returns all search queries asynchronously 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SearchQueryDB>> GetAllAsync()
        {
            return await _context.SearchQueries.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns search query by id
        /// </summary>
        /// <param name="id">search query id</param>
        /// <returns></returns>
        public SearchQueryDB GetById(string id)
        {
            return _context.SearchQueries.SingleOrDefault(q => q.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Returns search query by id asynchronously
        /// </summary>
        /// <param name="id">search query id</param>
        /// <returns></returns>
        public async Task<SearchQueryDB> GetByIdAsync(string id)
        {
            return await _context.SearchQueries.SingleOrDefaultAsync(q => q.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase)).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates search query
        /// </summary>
        /// <param name="query">search query</param>
        /// <returns></returns>
        public SearchQueryDB Add(SearchQueryDB query)
        {
            query.Id = Guid.NewGuid().ToString();
            _context.SearchQueries.Add(query);
            _context.SaveChanges();
            return query;
        }

        /// <summary>
        /// Removes search query by id
        /// </summary>
        /// <param name="id"></param>
        public void RemoveById(string id)
        {
            var query = _context.SearchQueries.SingleOrDefault(c => c.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            _context.SearchQueries.Remove(query);
            _context.SaveChanges();
        }

        /// <summary>
        /// Removes search query from database
        /// </summary>
        public void RemoveAll()
        {
            _context.SearchQueries.RemoveRange(_context.SearchQueries);
            _context.SaveChanges();
        }

        public async Task<bool> AnyAsync(string id)
        {
            return await _context.SearchQueries.AnyAsync(c => c.Id == id)
                .ConfigureAwait(false);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~SearchQueryDbService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool flag)
        {
            if (_isDisposed)
            {
                return;
            }

            _context.Dispose();
            _isDisposed = true;

            if (flag)
            {
                GC.SuppressFinalize(this);
            }
        }


    }
}
