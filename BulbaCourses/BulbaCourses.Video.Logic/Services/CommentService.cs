using AutoMapper;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMapper mapper;
        private readonly ICommentRepository commentRepository;

        public CommentService(IMapper mapper, ICommentRepository commentRepository)
        {
            this.mapper = mapper;
            this.commentRepository = commentRepository;
        }

        public CommentInfo GetById(string commentId)
        {
            var comment = commentRepository.GetById(commentId);
            var result = mapper.Map<CommentDb, CommentInfo>(comment);
            return result;
        }
        public IEnumerable<CommentInfo> GetAll()
        {
            var comments = commentRepository.GetAll();
            var result = mapper.Map<IEnumerable<CommentDb>, IEnumerable<CommentInfo>>(comments);
            return result;
        }

        public void Add(CommentInfo comment)
        {
            var commentDb = mapper.Map<CommentInfo, CommentDb>(comment);
            commentRepository.Add(commentDb);
        }

        public void Delete(CommentInfo comment)
        {
            var commentDb = mapper.Map<CommentInfo, CommentDb>(comment);
            commentRepository.Remove(commentDb);
        }
        public void DeleteById(string commentId)
        {
            var comment = commentRepository.GetById(commentId);
            commentRepository.Remove(comment);
        }

        public void Update(CommentInfo comment)
        {
            var commentDb = mapper.Map<CommentInfo, CommentDb>(comment);
            commentRepository.Update(commentDb);
        }

        public CommentInfo UpdateCommentText(string commentId, string newText)
        {
            var comment = commentRepository.GetById(commentId);
            comment.Text = newText;
            commentRepository.Update(comment);
            var commentInfo = mapper.Map<CommentDb, CommentInfo>(comment);
            return commentInfo;
        }

    }
}
