using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Logic.Interfaces
{
    public interface ICommentService
    {
        CommentLogic GetById(string commentId);
        IEnumerable<CommentLogic> GetAll(); //debug
        void Add(CommentLogic comment, CourseLogic course);
        void Update(CommentLogic comment);
        void Delete(CommentLogic comment);
        bool Exists(string name);
    }
}
