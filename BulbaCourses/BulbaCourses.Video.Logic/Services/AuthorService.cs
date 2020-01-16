
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
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IMapper mapper, IAuthorRepository authorRepository)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public async Task<Result<AuthorInfo>> AddAsync(AuthorInfo author)
        {
            var authorDb = _mapper.Map<AuthorInfo, AuthorDb>(author);
            try
            {
                await _authorRepository.AddAsync(authorDb);
                return Result<AuthorInfo>.Ok(_mapper.Map<AuthorInfo>(authorDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<AuthorInfo>)Result<AuthorInfo>.Fail($"Cannot save author. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<AuthorInfo>)Result<AuthorInfo>.Fail($"Cannot save author. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<AuthorInfo>)Result<AuthorInfo>.Fail($"Invalid user. {e.Message}");
            }
        }

        public Task<Result> DeleteAsync(AuthorInfo author)
        {
            var authorDb = _mapper.Map<AuthorInfo, AuthorDb>(author);
            _authorRepository.RemoveAsync(authorDb);
            return Task.FromResult(Result.Ok());
        }

        public Task<Result> DeleteByIdAsync(string authorId)
        {
            _authorRepository.RemoveAsyncById(authorId);
            return Task.FromResult(Result.Ok());
        }

        public async Task<IEnumerable<AuthorInfo>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<AuthorDb>, IEnumerable<AuthorInfo>>(authors);
            return result;
        }

        public IEnumerable<CourseInfo> GetAllCourses(AuthorInfo author)
        {
            var authorDb = _mapper.Map<AuthorInfo, AuthorDb>(author);
            var courses = authorDb.AuthorCourses;
            var result = _mapper.Map<IEnumerable<CourseDb>, IEnumerable<CourseInfo>>(courses);
            return result;
        }

        public async Task<AuthorInfo> GetByIdAsync(string authorId)
        {
            var author = await _authorRepository.GetByIdAsync(authorId);
            var authorInfo = _mapper.Map<AuthorDb, AuthorInfo>(author);
            return authorInfo;
        }

        public async Task<Result<AuthorInfo>> UpdateAsync(AuthorInfo author)
        {
            var authorDb = _mapper.Map<AuthorInfo, AuthorDb>(author);
            try
            {
                await _authorRepository.UpdateAsync(authorDb);
                return Result<AuthorInfo>.Ok(_mapper.Map<AuthorInfo>(authorDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<AuthorInfo>)Result<AuthorInfo>.Fail($"Cannot update author. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<AuthorInfo>)Result<AuthorInfo>.Fail($"Cannot update author. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<AuthorInfo>)Result<AuthorInfo>.Fail($"Invalid author. {e.Message}");
            }
        }
    }
}
