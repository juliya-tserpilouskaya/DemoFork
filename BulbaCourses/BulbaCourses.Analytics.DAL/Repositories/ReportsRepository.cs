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
    public class ReportsRepository : BaseRepository, IRepository<ReportDb>
    {
        public async Task<ReportDb> CreateAsync(ReportDb item)
        {            
            var addedItem = _context.Reports.Add(item);
            await _context.SaveChangesAsync();
            return addedItem;
        }

        public async Task<bool> DeleteAsync(
            Expression<Func<ReportDb, object>> includeCondition, 
            Expression<Func<ReportDb, bool>> firstOrDefaultAsyncCondition)
        {
            var reportDb = await _context.Reports
                .Include(includeCondition)
                .FirstOrDefaultAsync(firstOrDefaultAsyncCondition).ConfigureAwait(false);
            return await DeleteAsync(reportDb);
        }

        public async Task<bool> DeleteAsync(
            Expression<Func<ReportDb, bool>> firstOrDefaultAsyncCondition)
        {
            var reportDb = await _context.Reports
                .FirstOrDefaultAsync(firstOrDefaultAsyncCondition).ConfigureAwait(false);
            return await DeleteAsync(reportDb);
        }        

        public async Task<bool> ExistsAsync(Expression<Func<ReportDb, bool>> anyAsyncCondition)
        {
            return await _context.Reports.AnyAsync(anyAsyncCondition).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ReportDb>> ReadAllAsync(
            Expression<Func<ReportDb, bool>> whereCondition,
            Expression<Func<ReportDb, object>> orderByCondition)
        {
            return await _context.Reports
                .Where(whereCondition)
                .OrderBy(orderByCondition)
                .ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<ReportDb>> ReadAllAsync(
            Expression<Func<ReportDb, object>> orderByCondition)
        {
            return await _context.Reports
                .OrderBy(orderByCondition)
                .ToListAsync().ConfigureAwait(false);
        }

        public async Task<ReportDb> ReadAsync(
            Expression<Func<ReportDb, bool>> firstOrDefaultAsyncCondition)
        {
            return await _context.Reports.FirstOrDefaultAsync(firstOrDefaultAsyncCondition).ConfigureAwait(false);
        }

        public async Task<ReportDb> UpdateAsync(ReportDb item)
        {
            _context.Reports.Attach(item);
            var entry = _context.Entry(item);

            entry.State = EntityState.Modified;
            entry.Property(_ => _.Name).IsModified = true;
            entry.Property(_ => _.Description).IsModified = true;
            entry.Property(_ => _.Modified).IsModified = true;
            entry.Property(_ => _.Modifier).IsModified = true;

            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(ReportDb reportDb)
        {
            if (reportDb == null)
            {
                return false;
            }
            else
            {
                _context.Reports.Remove(reportDb);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
