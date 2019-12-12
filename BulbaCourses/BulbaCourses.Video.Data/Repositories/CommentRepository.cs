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
    public class CommentRepository : ICommentRepository
    {
        private readonly VideoDbContext videoDbContext;

        public CommentRepository(VideoDbContext videoDbContext)
        {
            this.videoDbContext = videoDbContext;
        }

        public void Add(CommentDb comment)
        {
            videoDbContext.Comments.Add(comment);
            videoDbContext.SaveChanges();

        }

        public IEnumerable<CommentDb> GetAll()
        {
            var commentList = videoDbContext.Comments.ToList().AsReadOnly();
            return commentList;

        }

        public CommentDb GetById(string commentId)
        {
            var comment = videoDbContext.Comments.FirstOrDefault(b => b.CommentId.Equals(commentId));
            return comment;

        }

        public void Remove(CommentDb comment)
        {
            videoDbContext.Comments.Remove(comment);
            videoDbContext.SaveChanges();

        }

        public void Update(CommentDb comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException("comment");
            }
            videoDbContext.Entry(comment).State = EntityState.Modified;
            videoDbContext.SaveChanges();

        }
    }
}
