using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTasks.BLL.Models;

namespace BulbaCourses.PracticalMaterialsTasks.BLL.Interfaces
{
    public interface IUserService:IDisposable
    {
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="userdto"></param>
        void MakeUser(UserDTO userdto);
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserDTO GetUser(string id);
        /// <summary>
        /// Get all user async
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserDTO>> GetUsers();

      
    }
}
