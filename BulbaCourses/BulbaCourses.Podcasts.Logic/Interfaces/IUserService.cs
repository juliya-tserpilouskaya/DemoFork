using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Logic.Interfaces
{
    public interface IUserService
    {
        UserLogic GetByName(string userName);
        UserLogic GetById(string id);
        IEnumerable<UserLogic> GetAll(); //debug
        void Add(UserLogic user);
        void Delete(UserLogic user);
        void Update(UserLogic user);
        bool Exists(string name);
    }
}
