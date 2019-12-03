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
        public Comment AddComment(Comment comment)
        {
            videoDbContext.Comments.Add(comment);
            videoDbContext.SaveChanges();
            return comment;
        }

        public ICollection<Comment> GetCourseComments(int courseId)
        {
            var course = videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            var comments = course.Comments.ToList().AsReadOnly();
            return comments;
        }

        public ICollection<Comment> GetVideoComments(int videoId)
        {
            var video = videoDbContext.VideoMaterials.FirstOrDefault(b => b.VideoId.Equals(videoId));
            var comments = video.Comments.ToList().AsReadOnly();
            return comments;
        }

        public bool RemoveById(int commentId)
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

        public Comment UpdateCommentText(string commentId, string newText)
        {
            var comment = videoDbContext.Comments.FirstOrDefault(b => b.CommentId.Equals(commentId));
            comment.Text = newText;
            videoDbContext.SaveChanges();
            return comment;
        }
    }
}
