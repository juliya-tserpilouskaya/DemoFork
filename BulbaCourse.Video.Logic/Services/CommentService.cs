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

        public void Add(CommentDb comment)
        {
            commentRepository.Add(comment);
        }

        public void RemoveById(string commentId)
        {
            var comment = commentRepository.GetById(commentId);
            commentRepository.Remove(comment);
        }

        public CommentDb UpdateCommentText(string commentId, string newText)
        {
            var comment = commentRepository.GetById(commentId);
            comment.Text = newText;
            commentRepository.Update(comment);
            return comment;
        }
    }
}
