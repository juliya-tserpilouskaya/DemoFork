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

        public IEnumerable<TagDb> GetAll()
        {
            var tagList = _videoDbContext.Tags.ToList().AsReadOnly();
            return tagList;

        }

        public TagDb GetById(string tagId)
        {
            var tag = _videoDbContext.Tags.FirstOrDefault(b => b.TagId.Equals(tagId));
            return tag;

        }

        public void Remove(TagDb tag)
        {
            _videoDbContext.Tags.Remove(tag);
            _videoDbContext.SaveChanges();

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
    }
}
