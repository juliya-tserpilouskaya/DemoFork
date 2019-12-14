using BulbaCourses.Analytics.DAL.Interfaces;
using BulbaCourses.Analytics.Infrastructure.DAL;
using BulbaCourses.Analytics.Infrastructure.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Analytics.DAL.Repositories
{
    public class DashboardRepository: IDashboardRepository
    {         
        private readonly List<IDashboardDb> _context;

        public DashboardRepository(IDashboardStorage context)
        {
            _context = context.Storage;
        }

        public void Create(IDashboardDb item)
        {
            _context.Add(item);
        }

        public void Delete(IDashboardDb item)
        {
            _context.Remove(item);
        }

        public IEnumerable<IDashboardDb> Find(Func<IDashboardDb, bool> predicate)
        {
            return _context.Where(predicate).ToList().AsReadOnly();
        }

        public void Update(IDashboardDb item)
        {
            Delete(item);
            Create(item);
        }
    }
}
