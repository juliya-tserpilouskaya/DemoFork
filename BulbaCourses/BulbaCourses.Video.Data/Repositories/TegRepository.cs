using BulbaCourses.Video.Data.DatabaseContext;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Repositories
{
    /// <summary>
    /// Provides a mechanism for working tag repository.
    /// </summary>
    public class TegRepository : BaseRepository, ITegRepository
    {

        public TegRepository(VideoDbContext videoDbContext) : base(videoDbContext)
        {
        }

        /// <summary>
        /// Create a new tag in repository.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public void Add(TagDb tag)
        {
            _videoDbContext.Tags.Add(tag);
            _videoDbContext.SaveChanges();

        }

        /// <summary>
        /// Create a new tag in repository.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task<TagDb> AddAsync(TagDb tag)
        {
            _videoDbContext.Tags.Add(tag);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(tag);
        }

        /// <summary>
        /// Gets all tags in repository.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TagDb> GetAll()
        {
            var tagList = _videoDbContext.Tags.ToList().AsReadOnly();
            return tagList;

        }

        /// <summary>
        /// Gets all courses by tag in repository.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CourseDb>> GetCoursesAsync(TagDb tag)
        {
            var courses = await _videoDbContext.Tags.Where(c => c.TagId == tag.TagId)?.SelectMany(c => c.Courses).ToListAsync();
            return courses.AsReadOnly(); ;
        }

        /// <summary>
        /// Gets all tags in repository.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TagDb>> GetAllAsync()
        {
            var tagList = await _videoDbContext.Tags.ToListAsync().ConfigureAwait(false);
            return tagList.AsReadOnly();
        }

        /// <summary>
        /// Shows tag details by id in repository.
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public TagDb GetById(string tagId)
        {
            var tag = _videoDbContext.Tags.FirstOrDefault(b => b.TagId.Equals(tagId));
            return tag;

        }

        /// <summary>
        /// Shows tag details by id in repository.
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public async Task<TagDb> GetByIdAsync(string tagId)
        {
            var tag = await _videoDbContext.Tags.SingleOrDefaultAsync(b => b.TagId.Equals(tagId)).ConfigureAwait(false);
            return tag;
        }

        /// <summary>
        /// Remove tag in repository.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public void Remove(TagDb tag)
        {
            _videoDbContext.Tags.Remove(tag);
            _videoDbContext.SaveChanges();

        }

        /// <summary>
        /// Remove tag in repository.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task RemoveAsync(TagDb tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException("user");
            }
            _videoDbContext.Tags.Remove(tag);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Remove tag by id in repository.
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public async Task RemoveAsyncById(string tagId)
        {
            var tag = _videoDbContext.Tags.SingleOrDefault(b => b.TagId.Equals(tagId));
            if (tag == null)
            {
                throw new ArgumentNullException("user");
            }
            _videoDbContext.Tags.Remove(tag);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Update tag in repository.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public void Update(TagDb tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException("tag");
            }
            _videoDbContext.Entry(tag).State = EntityState.Modified;
            _videoDbContext.SaveChanges();

        }

        /// <summary>
        /// Update tag in repository.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task<TagDb> UpdateAsync(TagDb tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException("tag");
            }
            _videoDbContext.Entry(tag).State = EntityState.Modified;
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(tag);
        }
    }
}
