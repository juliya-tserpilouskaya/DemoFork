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
    /// Provides a mechanism for working comment repository.
    /// </summary>
    public class CommentRepository : BaseRepository, ICommentRepository
    {

        public CommentRepository(VideoDbContext videoDbContext) : base(videoDbContext)
        {
        }

        /// <summary>
        /// Create a new comment in repository.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public void Add(CommentDb comment)
        {
            _videoDbContext.Comments.Add(comment);
            _videoDbContext.SaveChanges();

        }

        /// <summary>
        /// Create a new comment in repository.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public async Task<CommentDb> AddAsync(CommentDb comment)
        {
            _videoDbContext.Comments.Add(comment);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(comment);
        }

        /// <summary>
        /// Gets all comments in repository.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CommentDb> GetAll()
        {
            var commentList = _videoDbContext.Comments.ToList().AsReadOnly();
            return commentList;

        }

        /// <summary>
        /// Gets all comments in repository.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CommentDb>> GetAllAsync()
        {
            var commentList = await _videoDbContext.Comments.ToListAsync().ConfigureAwait(false);
            return commentList.AsReadOnly();
        }

        /// <summary>
        /// Shows comment details by id in repository.
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public CommentDb GetById(string commentId)
        {
            var comment = _videoDbContext.Comments.FirstOrDefault(b => b.CommentId.Equals(commentId));
            return comment;

        }

        /// <summary>
        /// Shows comment details by id in repository.
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public async Task<CommentDb> GetByIdAsync(string commentId)
        {
            var comment = await _videoDbContext.Comments.SingleOrDefaultAsync(b => b.CommentId.Equals(commentId)).ConfigureAwait(false);
            return comment;
        }

        /// <summary>
        /// Remove comment in repository.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public void Remove(CommentDb comment)
        {
            _videoDbContext.Comments.Remove(comment);
            _videoDbContext.SaveChanges();

        }

        /// <summary>
        /// Remove comment in repository.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public async Task RemoveAsync(CommentDb comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException("comment");
            }
            _videoDbContext.Comments.Remove(comment);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Remove comment by id in repository.
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update comment in repository.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public void Update(CommentDb comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException("comment");
            }
            _videoDbContext.Entry(comment).State = EntityState.Modified;
            _videoDbContext.SaveChanges();

        }

        /// <summary>
        /// Update comment in repository.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
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
