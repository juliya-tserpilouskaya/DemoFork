using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fody;
using System.Threading.Tasks;

[assembly: ConfigureAwait(false)]

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public class CourseDbRepository : IRepository<CourseDB>, ICourseLoadingRepository
    {
        public CourseDbRepository(PresentationsContext context)
        {
            this._db = context;
        }

        private PresentationsContext _db;

        /// <summary>
        /// Add a CourseDB to the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Add(CourseDB item)
        {
            _db.Courses.Add(item);
        }

        /// <summary>
        /// Get FirstOrDefault CourseDB from the database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CourseDB> GetByIdAsync(string id)
        {
            var query = from course in _db.Courses select course;
            return await query.AsNoTracking().FirstOrDefaultAsync(_ => _.Id.Equals(id));
        }

        /// <summary>
        /// Get all CourseDB fron the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CourseDB>> GetAllAsync()
        {
            var query = from course in _db.Courses select course;
            return await query.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Update course in the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Update(CourseDB item)
        {
            item.Update = DateTime.Now;
            _db.Courses.Attach(item);

            _db.Entry(item).Property(c => c.Name).IsModified = true;
            _db.Entry(item).Property(c => c.Update).IsModified = true;
        }

        /// <summary>
        /// Delete course from the database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteById(string id)
        {
            _db.Entry(new CourseDB() { Id = id }).State = EntityState.Deleted;
        }

        public async Task<CourseDB> GetAllPresentationsFromCourseAsync(string id)
        {
            var query = from course in _db.Courses select course;
            return await query.AsNoTracking().Include(_=>_.CoursePresentations).FirstOrDefaultAsync(_ => _.Id.Equals(id));
        }
    }
}
