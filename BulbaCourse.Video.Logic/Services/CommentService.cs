using AutoMapper;
using BulbaCourse.Video.Data.Interfaces;
using BulbaCourse.Video.Logic.InterfaceServices;
using BulbaCourse.Video.Logic.Models;
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
        private readonly IMapper mapper;
        private readonly ICommentRepository commentRepository;

        public CommentService(IMapper mapper, ICommentRepository commentRepository)
        {
            this.mapper = mapper;
            this.commentRepository = commentRepository;
        }

        public CommentLogic GetById(string commentId)
        {
            var comment = commentRepository.GetById(commentId);
            var commentLogic = mapper.Map<CommentDb, CommentLogic>(comment);
            return commentLogic;
        }
        public IEnumerable<CommentLogic> GetAll()
        {
            var commentList = commentRepository.GetAll();
            var commentListLogic = new List<CommentLogic>();
            foreach (CommentDb comment in commentList)
            {
                commentListLogic.Add(mapper.Map<CommentDb, CommentLogic>(comment));
            }
            return commentListLogic;
        }

        public void Add(CommentLogic comment)
        {
            var commentDb = mapper.Map<CommentLogic, CommentDb>(comment);
            commentRepository.Add(commentDb);
        }

        public ICollection<CommentLogic> GetCourseComments(int courseId)
        {
            var courseCommentDb = commentRepository.GetCourseComments(courseId);
            var courseCommentLog = new List<CommentLogic>();
            foreach (CommentDb comment in courseCommentDb)
            {
                courseCommentLog.Add(mapper.Map<CommentDb, CommentLogic>(comment));
            }
                return courseCommentLog;
        }

        public ICollection<CommentLogic> GetVideoComments(int videoId)
        {
            var courseCommentDb = commentRepository.GetVideoComments(videoId);
            var courseCommentLog = new List<CommentLogic>();
            foreach (CommentDb comment in courseCommentDb)
            {
                courseCommentLog.Add(mapper.Map<CommentDb, CommentLogic>(comment));
            }
            return courseCommentLog;
        }

        public void RemoveById(string commentId)
        {
            commentRepository.RemoveById(commentId);
        }

        public CommentLogic UpdateCommentText(string commentId, string newText)
        {
            var commentDb = commentRepository.UpdateCommentText(commentId, newText);
            var commentLogic = mapper.Map<CommentDb, CommentLogic>(commentDb);
            return commentLogic;
        }
    }
}
