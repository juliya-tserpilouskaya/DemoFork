using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        UserDb GetById(string id);
        IEnumerable<UserDb> GetAll();
        void Add(UserDb user);
        void Update(UserDb user);
        void Remove(UserDb user);
    }
}
