using BulbaCourse.Video.Data.DatabaseContex;
using BulbaCourse.Video.Data.Interfaces;
using System;
using System.Collections.Generic;
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

        public CommentDb AddComment(CommentDb comment)
        {
            videoDbContext.Comments.Add(comment);
            videoDbContext.SaveChanges();
            return comment;
        }

        public ICollection<CommentDb> GetCourseComments(int courseId)
        {
            var course = videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            var comments = course.Comments.ToList().AsReadOnly();
            return comments;
        }

        public ICollection<CommentDb> GetVideoComments(int videoId)
        {
            var video = videoDbContext.VideoMaterials.FirstOrDefault(b => b.VideoId.Equals(videoId));
            var comments = video.Comments.ToList().AsReadOnly();
            return comments;
        }

        public bool RemoveById(string commentId)
        {
            var deletedComment = videoDbContext.Comments.FirstOrDefault(b => b.CommentId.Equals(commentId));
            if (deletedComment != null)
            {
                videoDbContext.Comments.Remove(deletedComment);
                videoDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
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
