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

        public Result Add(CommentLogic comment, CourseLogic course)
        {
            try
            {
                comment.Id = Guid.NewGuid().ToString();
                comment.PostDate = DateTime.Now;
                comment.Course = course;
                var commentDb = mapper.Map<CommentLogic, CommentDb>(comment);
                var result = dbmanager.Add(commentDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }

        }

        public Result<CommentLogic> GetById(string Id)
        {
            try
            {
                var comment = dbmanager.GetById(Id).GetAwaiter().GetResult();
                var CommentLogic = mapper.Map<CommentDb, CommentLogic>(comment);
                return Result<CommentLogic>.Ok(CommentLogic);
            }
            catch (Exception)
            {
                return Result<CommentLogic>.Fail("Exception");
            }
        }

        public Result<IEnumerable<CommentLogic>> GetAll()
        {
            try
            {
                var comments = dbmanager.GetAll().GetAwaiter().GetResult();
                var result = mapper.Map<IEnumerable<CommentDb>, IEnumerable<CommentLogic>>(comments);
                return Result<IEnumerable<CommentLogic>>.Ok(result);
            }
            catch (Exception)
            {
                return Result<IEnumerable<CommentLogic>>.Fail("Exception");
            }
        }

        public Result Delete(CommentLogic comment)
        {

            try
            {
                var commentDb = mapper.Map<CommentLogic, CommentDb>(comment);
                dbmanager.Remove(commentDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public Result Update(CommentLogic comment)
        {
            try
            {
                var commentDb = mapper.Map<CommentLogic, CommentDb>(comment);
                dbmanager.Update(commentDb);
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Exception");
            }
        }

        public bool Exists(string id)
        {
            return dbmanager.GetAll().GetAwaiter().GetResult().Any(b => b.Id == id);
        }
    }
}
