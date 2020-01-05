using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTasks.BLL.Models;

namespace BulbaCourses.PracticalMaterialsTasks.BLL.Interfaces
{
    public interface IUserService
    {
        void MakeUser(UserDTO userdto);

        UserDTO GetUser(string id);

        IEnumerable<UserDTO> GetUsers();

        void Dispose();
    }
}
