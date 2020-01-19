using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using BulbaCourses.Podcasts.Data;

namespace BulbaComments.Podcasts.Data.Managers
{
    class CommentManager : BaseManager, IManager<CommentDb>
    {
        public CommentManager(PodcastsContext dbContext) : base(dbContext)
        {
        }

        public async Task<CommentDb> Add(CommentDb commentDb)
        {
            dbContext.Comments.Add(commentDb);
            await dbContext.SaveChangesAsync().ConfigureAwait(false); ;
            return await Task.FromResult(commentDb).ConfigureAwait(false);
        }
        public async Task<IEnumerable<CommentDb>> GetAll()
        {
            var courseList = await dbContext.Comments.ToListAsync().ConfigureAwait(false);
            return courseList.AsReadOnly();
        }
        public async Task<CommentDb> GetById(string id)
        {
            return await dbContext.Comments.SingleOrDefaultAsync(b => b.Id.Equals(id)).ConfigureAwait(false);
        }
        public async Task<CommentDb> Remove(CommentDb commentDb)
        {
            if (commentDb == null)
            {
                throw new ArgumentNullException();
            }
            dbContext.Comments.Remove(commentDb);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
            return null;
        }
        public async Task<CommentDb> Update(CommentDb commentDb)
        {
            if (commentDb == null)
            {
                throw new ArgumentNullException();
            }
            dbContext.Entry(commentDb).State = EntityState.Modified;
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(commentDb);
        }
    }
}
