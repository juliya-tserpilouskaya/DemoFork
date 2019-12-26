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
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public CommentService(IMapper mapper, ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public CommentInfo GetById(string commentId)
        {
            var comment = _commentRepository.GetById(commentId);
            var result = _mapper.Map<CommentDb, CommentInfo>(comment);
            return result;
        }
        public IEnumerable<CommentInfo> GetAll()
        {
            var comments = _commentRepository.GetAll();
            var result = _mapper.Map<IEnumerable<CommentDb>, IEnumerable<CommentInfo>>(comments);
            return result;
        }

        public void Add(CommentInfo comment)
        {
            var commentDb = _mapper.Map<CommentInfo, CommentDb>(comment);
            _commentRepository.Add(commentDb);
        }

        public void Delete(CommentInfo comment)
        {
            var commentDb = _mapper.Map<CommentInfo, CommentDb>(comment);
            _commentRepository.Remove(commentDb);
        }
        public void DeleteById(string commentId)
        {
            var comment = _commentRepository.GetById(commentId);
            _commentRepository.Remove(comment);
        }

        public void Update(CommentInfo comment)
        {
            var commentDb = _mapper.Map<CommentInfo, CommentDb>(comment);
            _commentRepository.Update(commentDb);
        }

        public CommentInfo UpdateCommentText(string commentId, string newText)
        {
            var comment = _commentRepository.GetById(commentId);
            comment.Text = newText;
            _commentRepository.Update(comment);
            var commentInfo = _mapper.Map<CommentDb, CommentInfo>(comment);
            return commentInfo;
        }

        public async Task<CommentInfo> GetCommentByIdAsync(string commentId)
        {
            var comment = await _commentRepository.GetByIdAsync(commentId);
            var commentInfo = _mapper.Map<CommentDb, CommentInfo>(comment);
            return commentInfo;
        }

        public async Task<IEnumerable<CommentInfo>> GetAllAsync()
        {
            var comments = await _commentRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CommentDb>, IEnumerable<CommentInfo>>(comments);
            return result;
        }

        public Task<int> UpdateAsync(CommentInfo comment)
        {
            var commentDb = _mapper.Map<CommentInfo, CommentDb>(comment);
            return _commentRepository.UpdateAsync(commentDb);
        }

        public Task<int> AddAsync(CommentInfo comment)
        {
            var commentDb = _mapper.Map<CommentInfo, CommentDb>(comment);
            return _commentRepository.AddAsync(commentDb);
        }

        public Task<int> DeleteByIdAsync(string commentId)
        {
            var comment = _commentRepository.GetById(commentId);
            return _commentRepository.RemoveAsync(comment);
        }

    }
}
