using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public class FeedbackDbRepository : IRepository<FeedbackDB>
    {
        public FeedbackDbRepository(PresentationsContext context)
        {
            this._db = context;
        }

        private PresentationsContext _db;

        /// <summary>
        /// Add a FeedbackDB to the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Add(FeedbackDB item)
        {
            _db.Feedbacks.Add(item);
        }

        /// <summary>
        /// Get FirstOrDefault FeedbackDB from the database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FeedbackDB> GetByIdAsync(string id)
        {
            var query = from feedback in _db.Feedbacks select feedback;
            return await query.AsNoTracking().FirstOrDefaultAsync(_ => _.Id.Equals(id));
        }

        /// <summary>
        /// Get all FeedbackDB fron the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<FeedbackDB>> GetAllAsync()
        {
            var query = from feedback in _db.Feedbacks select feedback;
            return await query.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Update feedback in the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Update(FeedbackDB item)
        {
            item.Date = DateTime.Now;
            _db.Feedbacks.Attach(item);

            _db.Entry(item).Property(c => c.Title).IsModified = true;
            _db.Entry(item).Property(c => c.Text).IsModified = true;
            _db.Entry(item).Property(c => c.Date).IsModified = true;
        }

        /// <summary>
        /// Delete feedback from the database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteById(string id)
        {
            _db.Entry(new FeedbackDB() { Id = id }).State = EntityState.Deleted;
        }
    }
}
