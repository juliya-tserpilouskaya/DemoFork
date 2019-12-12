using BulbaCourses.Video.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.InterfaceServices
{
    public interface IUserService
    {
        UserInfo GetByLogin(string userName);
        UserInfo GetUserById(string id);
        IEnumerable<UserInfo> GetAll();
        void Add(UserInfo user);
        void Delete(UserInfo user);
        void DeleteById(string userId);
        void Update(UserInfo user);
    }
}
