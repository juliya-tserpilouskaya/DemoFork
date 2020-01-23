using BulbaCourses.Analytics.DAL.Interface;
using BulbaCourses.Analytics.DAL.Models;
using BulbaCourses.Analytics.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Repositories
{
    public class DashboardsRepository : BaseRepository, IDashboardsRepository
    {
        public async Task<DashboardDb> CreateAsync(DashboardDb item)
        {            
            var addedItem = _context.Dashboards.Add(item);
            await _context.SaveChangesAsync();
            return addedItem;
        }

        public async Task<bool> DeleteAsync(
            Expression<Func<DashboardDb, object>> includeCondition, 
            Expression<Func<DashboardDb, bool>> firstOrDefaultAsyncCondition)
        {
            var DashboardDb = await _context.Dashboards
                .Include(includeCondition)
                .FirstOrDefaultAsync(firstOrDefaultAsyncCondition).ConfigureAwait(false);
            return await DeleteAsync(DashboardDb);
        }

        public async Task<bool> DeleteAsync(
            Expression<Func<DashboardDb, bool>> firstOrDefaultAsyncCondition)
        {
            var DashboardDb = await _context.Dashboards
                .FirstOrDefaultAsync(firstOrDefaultAsyncCondition).ConfigureAwait(false);
            return await DeleteAsync(DashboardDb);
        }        

        public async Task<bool> ExistsAsync(Expression<Func<DashboardDb, bool>> anyAsyncCondition)
        {
            return await _context.Dashboards.AnyAsync(anyAsyncCondition).ConfigureAwait(false);
        }

        public async Task<bool> ExistsChartAsync(Expression<Func<ChartDb, bool>> anyAsyncCondition)
        {
            return await _context.Charts.AnyAsync(anyAsyncCondition).ConfigureAwait(false);
        }

        public async Task<bool> ExistsReportAsync(Expression<Func<ReportDb, bool>> anyAsyncCondition)
        {
            return await _context.Reports.AnyAsync(anyAsyncCondition).ConfigureAwait(false);
        }

        public async Task<IEnumerable<DashboardDb>> ReadAllAsync(
            Expression<Func<DashboardDb, bool>> whereCondition,
            Expression<Func<DashboardDb, object>> orderByCondition)
        {
            return await _context.Dashboards
                .Where(whereCondition)
                .OrderBy(orderByCondition)
                .ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<DashboardDb>> ReadAllAsync(
            Expression<Func<DashboardDb, object>> orderByCondition)
        {
            return await _context.Dashboards
                .OrderBy(orderByCondition)
                .ToListAsync().ConfigureAwait(false);
        }

        public async Task<DashboardDb> ReadAsync(
            Expression<Func<DashboardDb, bool>> firstOrDefaultAsyncCondition)
        {
            return await _context.Dashboards.FirstOrDefaultAsync(firstOrDefaultAsyncCondition).ConfigureAwait(false);
        }

        public async Task<DashboardDb> UpdateAsync(DashboardDb item)
        {
            _context.Dashboards.Attach(item);
            var entry = _context.Entry(item);

            entry.State = EntityState.Modified;
            entry.Property(_ => _.Name).IsModified = true;
            entry.Property(_ => _.Modified).IsModified = true;
            entry.Property(_ => _.Modifier).IsModified = true;

            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(DashboardDb DashboardDb)
        {
            if (DashboardDb == null)
            {
                return false;
            }

            _context.Dashboards.Remove(DashboardDb);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
