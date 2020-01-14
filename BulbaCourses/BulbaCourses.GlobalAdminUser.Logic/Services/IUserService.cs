using BulbaCourses.GlobalAdminUser.Logic.Models;
using System.Collections.Generic;

namespace BulbaCourses.GlobalAdminUser.Logic.Services
{
    public interface IUserService
    {
        UserDTO GetById(string id);
        IEnumerable<UserDTO> GetAll();
        void Add(UserDTO user);
        void Update(UserDTO user);
        void Delete(UserDTO user);
    }
}
