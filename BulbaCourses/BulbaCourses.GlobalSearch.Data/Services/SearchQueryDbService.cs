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

        public IEnumerable<SearchQueryDB> GetAll()
        {
            return _context.SearchQueries;
        }

        public async Task<IEnumerable<SearchQueryDB>> GetAllAsync()
        {
            return await _context.SearchQueries.ToListAsync().ConfigureAwait(false);
        }

        public SearchQueryDB GetById(string id)
        {
            return _context.SearchQueries.SingleOrDefault(q => q.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public async Task<SearchQueryDB> GetByIdAsync(string id)
        {
            return await _context.SearchQueries.SingleOrDefaultAsync(q => q.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase)).ConfigureAwait(false);
        }

        public SearchQueryDB Add(SearchQueryDB query)
        {
            query.Id = Guid.NewGuid().ToString();
            _context.SearchQueries.Add(query);
            _context.SaveChanges();
            return query;
        }

        public void RemoveById(string id)
        {
            var query = _context.SearchQueries.SingleOrDefault(c => c.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            _context.SearchQueries.Remove(query);
            _context.SaveChanges();
        }

        public void RemoveAll()
        {
            _context.SearchQueries.RemoveRange(_context.SearchQueries);
            _context.SaveChanges();
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
