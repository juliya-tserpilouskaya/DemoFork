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
    public class CommentRepository : BaseRepository, ICommentRepository
    {

        public CommentRepository(VideoDbContext videoDbContext) : base(videoDbContext)
        {
        }

        public void Add(CommentDb comment)
        {
            _videoDbContext.Comments.Add(comment);
            _videoDbContext.SaveChanges();

        }

        public async Task<CommentDb> AddAsync(CommentDb comment)
        {
            _videoDbContext.Comments.Add(comment);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(comment);
        }

        public IEnumerable<CommentDb> GetAll()
        {
            var commentList = _videoDbContext.Comments.ToList().AsReadOnly();
            return commentList;

        }

        public async Task<IEnumerable<CommentDb>> GetAllAsync()
        {
            var commentList = await _videoDbContext.Comments.ToListAsync().ConfigureAwait(false);
            return commentList.AsReadOnly();
        }

        public CommentDb GetById(string commentId)
        {
            var comment = _videoDbContext.Comments.FirstOrDefault(b => b.CommentId.Equals(commentId));
            return comment;

        }

        public async Task<CommentDb> GetByIdAsync(string commentId)
        {
            var comment = await _videoDbContext.Comments.SingleOrDefaultAsync(b => b.CommentId.Equals(commentId)).ConfigureAwait(false);
            return comment;
        }

        public void Remove(CommentDb comment)
        {
            _videoDbContext.Comments.Remove(comment);
            _videoDbContext.SaveChanges();

        }

        public async Task RemoveAsync(CommentDb comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException("comment");
            }
            _videoDbContext.Comments.Remove(comment);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task RemoveAsyncById(string commentId)
        {
            var comment = _videoDbContext.Comments.SingleOrDefault(b => b.CommentId.Equals(commentId));
            if (comment == null)
            {
                throw new ArgumentNullException("comment");
            }
            _videoDbContext.Comments.Remove(comment);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Update(CommentDb comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException("comment");
            }
            _videoDbContext.Entry(comment).State = EntityState.Modified;
            _videoDbContext.SaveChanges();

        }

        public async Task<CommentDb> UpdateAsync(CommentDb comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException("comment");
            }
            _videoDbContext.Entry(comment).State = EntityState.Modified;
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(comment);
        }
    }
}
