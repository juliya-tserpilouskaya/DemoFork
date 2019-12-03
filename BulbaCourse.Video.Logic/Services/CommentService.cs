using BulbaCourse.Video.Data.Interfaces;
using BulbaCourse.Video.Logic.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Logic.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public CommentDb GetById(string commentId)
        {
            var result = commentRepository.GetById(commentId);
            return result;
        }
        public IEnumerable<CommentDb> GetAll()
        {
            var result = commentRepository.GetAll();
            return result;
        }

        public CommentDb AddComment(CommentDb comment)
        {
            var result = commentRepository.AddComment(comment);
            return result;
        }

        public ICollection<CommentDb> GetCourseComments(int courseId)
        {
            var result = commentRepository.GetCourseComments(courseId);
            return result;
        }

        public ICollection<CommentDb> GetVideoComments(int videoId)
        {
            var result = commentRepository.GetVideoComments(videoId);
            return result;
        }

        public bool RemoveById(string commentId)
        {
            var result = commentRepository.RemoveById(commentId);
            return result;
        }

        public CommentDb UpdateCommentText(string commentId, string newText)
        {
            var result = commentRepository.UpdateCommentText(commentId, newText);
            return result;
        }
    }
}
