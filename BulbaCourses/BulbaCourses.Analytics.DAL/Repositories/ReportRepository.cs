using BulbaCourses.Analytics.DAL.Interfaces;
using BulbaCourses.Analytics.Infrastructure.DAL;
using BulbaCourses.Analytics.Infrastructure.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Analytics.DAL.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly List<IReportDb> _context;

        public ReportRepository(IReportStorage context)
        {
            _context = context.Storage;
        }

        public void Create(IReportDb item)
        {
            _context.Add(item);
        }

        public void Delete(IReportDb item)
        {
            _context.Remove(item);
        }

        public IEnumerable<IReportDb> Find(Func<IReportDb, bool> predicate)
        {
            return _context.Where(predicate).ToList().AsReadOnly();
        }

        public void Update(IReportDb item)
        {
            Delete(item);
            Create(item);
        }
    }
}
