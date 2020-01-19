using AutoMapper;
using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using Ninject;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace BulbaCourses.Podcasts.Logic.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMapper mapper;
        private readonly IManager<CommentDb> dbmanager;

        public CommentService(IMapper mapper, IManager<CommentDb> dbmanager)
        {
            this.mapper = mapper;
            this.dbmanager = dbmanager;
        }

        public async Task<Result> AddAsync(CommentLogic comment, CourseLogic course)
        {
            try
            {
                comment.Id = Guid.NewGuid().ToString();
                comment.PostDate = DateTime.Now;
                comment.Course = course;
                var commentDb = mapper.Map<CommentLogic, CommentDb>(comment);
                var result = await dbmanager.AddAsync(commentDb);
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbUpdateException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbEntityValidationException e)
            {
                return Result.Fail(e.Message);
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }

        }

        public async Task<Result<CommentLogic>> GetByIdAsync(string Id)
        {
            try
            {
                var comment = await dbmanager.GetByIdAsync(Id);
                var CommentLogic = mapper.Map<CommentDb, CommentLogic>(comment);
                return Result<CommentLogic>.Ok(CommentLogic);
            }
            catch (Exception)
            {
                return Result<CommentLogic>.Fail("Exception");
            }
        }

        public async Task<Result<IEnumerable<CommentLogic>>> GetAllAsync()
        {
            try
            {
                var comments = await dbmanager.GetAllAsync();
                var result = mapper.Map<IEnumerable<CommentDb>, IEnumerable<CommentLogic>>(comments);
                return Result<IEnumerable<CommentLogic>>.Ok(result);
            }
            catch (Exception)
            {
                return Result<IEnumerable<CommentLogic>>.Fail("Exception");
            }
        }

        public async Task<Result> DeleteAsync(CommentLogic comment)
        {

            try
            {
                var commentDb = mapper.Map<CommentLogic, CommentDb>(comment);
                await dbmanager.RemoveAsync(commentDb);
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbUpdateException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbEntityValidationException e)
            {
                return Result.Fail(e.Message);
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public async Task<Result> UpdateAsync(CommentLogic comment)
        {
            try
            {
                var commentDb = mapper.Map<CommentLogic, CommentDb>(comment);
                await dbmanager.UpdateAsync(commentDb);
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbUpdateException e)
            {
                return Result.Fail(e.Message);
            }
            catch (DbEntityValidationException e)
            {
                return Result.Fail(e.Message);
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await dbmanager.ExistAsync(name);
        }
    }
}
