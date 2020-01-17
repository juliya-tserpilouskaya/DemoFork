using AutoMapper;
using BulbaCourses.Podcasts.Logic.Interfaces;
using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Logic.Models;
using BulbaCourses.Podcasts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Logic.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMapper mapper;
        private readonly IManager<T> dbmanager;

        public CommentService(IMapper mapper, IManager<CommentDb> dbmanager)
        {
            this.mapper = mapper;
            this.dbmanager = dbmanager;
        }

        public CommentLogic GetById(string Id)
        {
            var comment = dbmanager.GetCommentById(Id);
            var result = mapper.Map<CommentDb, CommentLogic>(comment);
            return result;
        }
        public IEnumerable<CommentLogic> GetAll()
        {
            var comments = dbmanager.GetAllComments();
            var result = mapper.Map<IEnumerable<CommentDb>, IEnumerable<CommentLogic>>(comments);
            return result;
        }

        public void Add(CommentLogic comment, CourseLogic course)
        {
            var commentDb = mapper.Map<CommentLogic, CommentDb>(comment);
            var coursedb = mapper.Map<CourseLogic, CourseDb>(course);
            course.Comments.Append(comment);
            dbmanager.UpdateCourse(coursedb);
            dbmanager.AddComment(commentDb);
        }

        public void Delete(CommentLogic comment)
        {
            var commentDb = mapper.Map<CommentLogic, CommentDb>(comment);
            dbmanager.RemoveComment(commentDb);
        }

        public void Update(CommentLogic comment)
        {
            var commentDb = mapper.Map<CommentLogic, CommentDb>(comment);
            dbmanager.UpdateComment(commentDb);
        }
    }

}
