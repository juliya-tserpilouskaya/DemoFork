using BulbaCourse.Video.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Logic.FakeRepositories
{
    public class FakeCommentRepository : ICommentRepository
    {
        private List<CommentDb> _comments;
        public FakeCommentRepository()
        {
            UserDb user1 = new UserDb()
            {
                UserId = Guid.NewGuid().ToString(),
                Login = "user1",
                Password = "1111",
                Email = "1@gmail.com"
            };
            UserDb user2 = new UserDb()
            {
                UserId = Guid.NewGuid().ToString(),
                Login = "user2",
                Password = "2222",
                Email = "3@gmail.com"
            };

            UserDb user3 = new UserDb()
            {
                UserId = Guid.NewGuid().ToString(),
                Login = "user3",
                Password = "3333",
                Email = "3@gmail.com"
            };

            _comments = new List<CommentDb>()
            {
               new CommentDb()
               {
                   CommentId = Guid.NewGuid().ToString(),
                   Text = "Yes",
                   UserId = user1,
                   Date = DateTime.Now
               },

               new CommentDb()
               {
                   CommentId = Guid.NewGuid().ToString(),
                   Text = "No",
                   UserId = user2,
                   Date = DateTime.Now
               },
               new CommentDb()
               {
                   CommentId = Guid.NewGuid().ToString(),
                   Text = "Maybe",
                   UserId = user3,
                   Date = DateTime.Now
               },
            };
        }

        public void Add(CommentDb comment)
        {
            _comments.Add(comment);
        }

        public IEnumerable<CommentDb> GetAll()
        {
            throw new NotImplementedException();
        }

        public CommentDb GetById(string commentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentDb> GetCourseComments(int courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentDb> GetVideoComments(int videoId)
        {
            throw new NotImplementedException();
        }

        public void Remove(CommentDb comment)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(string commentId)
        {
            throw new NotImplementedException();
        }

        public void Update(CommentDb comment)
        {
            throw new NotImplementedException();
        }

        public CommentDb UpdateCommentText(string commentId, string newText)
        {
            throw new NotImplementedException();
        }
    }
}
