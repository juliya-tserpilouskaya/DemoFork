using BulbaCourse.Video.Data.DatabaseContex;
using BulbaCourse.Video.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly VideoDbContext videoDbContext;

        public CommentRepository(VideoDbContext videoDbContext)
        {
            this.videoDbContext = videoDbContext;
        }

        public CommentDb GetById(string commentId)
        {
            var comment = videoDbContext.Comments.FirstOrDefault(b => b.CommentId.Equals(commentId));
            return comment;
        }
        public IEnumerable<CommentDb> GetAll()
        {
            var commentList = videoDbContext.Comments.ToList().AsReadOnly();
            return commentList;
        }

        public void Add(CommentDb comment)
        {
            videoDbContext.Comments.Add(comment);
            videoDbContext.SaveChanges();
        }

        public IEnumerable<CommentDb> GetCourseComments(int courseId)
        {
            var course = videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            var comments = course.Comments.ToList().AsReadOnly();
            return comments;
        }

        public IEnumerable<CommentDb> GetVideoComments(int videoId)
        {
            var video = videoDbContext.VideoMaterials.FirstOrDefault(b => b.VideoId.Equals(videoId));
            var comments = video.Comments.ToList().AsReadOnly();
            return comments;
        }

        public void RemoveById(string commentId)
        {
            var deletedComment = videoDbContext.Comments.FirstOrDefault(b => b.CommentId.Equals(commentId));
            videoDbContext.Comments.Remove(deletedComment);
            videoDbContext.SaveChanges();
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

        public CommentDb UpdateCommentText(string commentId, string newText)
        {
            var comment = videoDbContext.Comments.FirstOrDefault(b => b.CommentId.Equals(commentId));
            comment.Text = newText;
            videoDbContext.SaveChanges();
            return comment;
        }
    }
}
