using AutoMapper;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Logic.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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

        public async Task<Result<CommentInfo>> UpdateAsync(CommentInfo comment)
        {
            comment.UpdateDate = DateTime.Now.Date;
            var commentDb = _mapper.Map<CommentInfo, CommentDb>(comment);
            try
            {
                await _commentRepository.UpdateAsync(commentDb);
                return Result<CommentInfo>.Ok(_mapper.Map<CommentInfo>(commentDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<CommentInfo>)Result<CommentInfo>.Fail($"Cannot update comment. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<CommentInfo>)Result<CommentInfo>.Fail($"Cannot update comment. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<CommentInfo>)Result<CommentInfo>.Fail($"Invalid comment. {e.Message}");
            }
        }

        public async Task<Result<CommentInfo>> AddAsync(CommentInfo comment)
        {
            comment.Date = DateTime.Now;
            var commentDb = _mapper.Map<CommentInfo, CommentDb>(comment);
            try
            {
                await _commentRepository.AddAsync(commentDb);
                return Result<CommentInfo>.Ok(_mapper.Map<CommentInfo>(commentDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<CommentInfo>)Result<CommentInfo>.Fail($"Cannot save comment. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<CommentInfo>)Result<CommentInfo>.Fail($"Cannot save comment. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<CommentInfo>)Result<CommentInfo>.Fail($"Invalid comment. {e.Message}");
            }
        }

        public Task<Result> DeleteByIdAsync(string commentId)
        {
            _commentRepository.RemoveAsyncById(commentId);
            return Task.FromResult(Result.Ok());
        }

    }
}
