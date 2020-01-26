using BulbaCourses.TextMaterials_Presentations.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public class TeacherDbRepository : IRepository<TeacherDB>, ITeacherLoadingRepository
    {
        public TeacherDbRepository(PresentationsContext context)
        {
            this._db = context;
        }

        private PresentationsContext _db;

        /// <summary>
        /// Add a TeacherDB to the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Add(TeacherDB item)
        {
            item.Created = DateTime.Now;
            _db.Teachers.Add(item);
        }

        /// <summary>
        /// Get FirstOrDefault TeacherDB from the database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TeacherDB> GetByIdAsync(string id)
        {
            var query = from teacher in _db.Teachers select teacher;
            return await query.AsNoTracking().FirstOrDefaultAsync(_ => _.Id.Equals(id));
        }

        /// <summary>
        /// Get all TeacherDB fron the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TeacherDB>> GetAllAsync()
        {
            var query = from teacher in _db.Teachers select teacher;
            return await query.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Update teacher in the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Update(TeacherDB item)
        {
            item.Modified = DateTime.Now;
            _db.Teachers.Attach(item);

            _db.Entry(item).Property(c => c.PhoneNumber).IsModified = true;
            _db.Entry(item).Property(c => c.Position).IsModified = true;
            _db.Entry(item).Property(c => c.Modified).IsModified = true;
        }

        /// <summary>
        /// Delete teacher from the database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteById(string id)
        {
            _db.Entry(new TeacherDB() { Id = id }).State = EntityState.Deleted;
        }

        public async Task<TeacherDB> GetAllFeedbacksFromTeacherAsync(string id)
        {
            var query = from teacher in _db.Teachers select teacher;
            return await query.AsNoTracking().Include(_ => _.Feedbacks).FirstOrDefaultAsync(_ => _.Id.Equals(id));
        }

        public async Task<TeacherDB> GetAllChangedPresentationsAsync(string id)
        {
            var query = from teacher in _db.Teachers select teacher;
            return await query.AsNoTracking().Include(_ => _.ChangedPresentatons).FirstOrDefaultAsync(_ => _.Id.Equals(id));
        }
    }
}
