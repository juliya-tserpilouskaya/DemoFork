using BulbaCourses.TextMaterials_Presentations.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public class PresentationDbRepository : IRepository<PresentationDB>, IPresentationsLoadingRepository
    {
        public PresentationDbRepository(PresentationsContext context)
        {
            this._db = context;
        }

        private PresentationsContext _db;

        /// <summary>
        /// Add a PresentationDB to the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Add(PresentationDB item)
        {
            _db.Presentations.Add(item);
        }

        /// <summary>
        /// Get FirstOrDefault PresentationDB from the database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PresentationDB> GetByIdAsync(string id)
        {
            var query = from presentation in _db.Presentations select presentation;
            return await query.AsNoTracking().FirstOrDefaultAsync(_ => _.Id.Equals(id));
        }

        /// <summary>
        /// Get all PresentationDB fron the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PresentationDB>> GetAllAsync()
        {
            var query = from presentation in _db.Presentations select presentation;
            return await query.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Update presentation in the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Update(PresentationDB item)
        {
            item.DateUpdate = DateTime.Now;
            _db.Presentations.Attach(item);

            _db.Entry(item).Property(c => c.Title).IsModified = true;
            _db.Entry(item).Property(c => c.IsAccessible).IsModified = true;
            _db.Entry(item).Property(c => c.DateUpdate).IsModified = true;
            _db.Entry(item).Property(c => c.TeacherDBId).IsModified = true;
            _db.Entry(item).Property(c => c.CourseDBId).IsModified = true;
        }

        /// <summary>
        /// Delete presentation from the database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteById(string id)
        {
            _db.Entry(new PresentationDB() { Id = id }).State = EntityState.Deleted;
        }

        public async Task<PresentationDB> GetAllWhoWatchedThisPresentationAsync(string id)
        {
            var query = from presentation in _db.Presentations select presentation;
            return await query.AsNoTracking().Include(_=>_.ViewedByStudents).FirstOrDefaultAsync(_ => _.Id.Equals(id));
        }

        public async Task<PresentationDB> GetAllWhoLikeThisPresentationAsync(string id)
        {
            var query = from presentation in _db.Presentations select presentation;
            return await query.AsNoTracking().Include(_=>_.Students).FirstOrDefaultAsync(_ => _.Id.Equals(id));
        }

        public async Task<PresentationDB> GetAllFeedbacksPresentationAsync(string id)
        {
            var query = from presentation in _db.Presentations select presentation;
            return await query.AsNoTracking().Include(_ => _.Feedbacks).FirstOrDefaultAsync(_ => _.Id.Equals(id));
        }
    }
}
