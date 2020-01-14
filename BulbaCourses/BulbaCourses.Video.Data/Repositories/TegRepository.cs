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
    public class TegRepository : BaseRepository, ITegRepository
    {

        public TegRepository(VideoDbContext videoDbContext) : base(videoDbContext)
        {
        }

        public void Add(TagDb tag)
        {
            _videoDbContext.Tags.Add(tag);
            _videoDbContext.SaveChanges();

        }

        public async Task<TagDb> AddAsync(TagDb tag)
        {
            _videoDbContext.Tags.Add(tag);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(tag);
        }

        public IEnumerable<TagDb> GetAll()
        {
            var tagList = _videoDbContext.Tags.ToList().AsReadOnly();
            return tagList;

        }

        public async Task<IEnumerable<TagDb>> GetAllAsync()
        {
            var tagList = await _videoDbContext.Tags.ToListAsync().ConfigureAwait(false);
            return tagList.AsReadOnly();
        }

        public TagDb GetById(string tagId)
        {
            var tag = _videoDbContext.Tags.FirstOrDefault(b => b.TagId.Equals(tagId));
            return tag;

        }

        public async Task<TagDb> GetByIdAsync(string tagId)
        {
            var tag = await _videoDbContext.Tags.SingleOrDefaultAsync(b => b.TagId.Equals(tagId)).ConfigureAwait(false);
            return tag;
        }

        public void Remove(TagDb tag)
        {
            _videoDbContext.Tags.Remove(tag);
            _videoDbContext.SaveChanges();

        }

        public async Task RemoveAsync(TagDb tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException("user");
            }
            _videoDbContext.Tags.Remove(tag);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

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

        public void Update(TagDb tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException("tag");
            }
            _videoDbContext.Entry(tag).State = EntityState.Modified;
            _videoDbContext.SaveChanges();

        }

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
