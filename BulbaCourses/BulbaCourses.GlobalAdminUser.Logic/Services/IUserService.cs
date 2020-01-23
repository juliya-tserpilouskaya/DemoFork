using BulbaCourses.GlobalAdminUser.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Logic.Services
{
    public interface IUserService
    {
        UserDTO GetById(string id);
        Task<UserDTO> GetByIdAsync(string id);
        //IEnumerable<UserDTO> GetAll();
        Task<IEnumerable<UserDTO>> GetAllAsync();
        void Add(UserDTO user);
        void Update(UserDTO user);
        void Delete(UserDTO user);
    }
}
