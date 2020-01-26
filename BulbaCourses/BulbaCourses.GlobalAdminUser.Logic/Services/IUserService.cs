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
        Task<string> RegisterUser(RegisterUserDTO registerUser);
        void Add(UserDTO user);
        void Update(UserDTO user);
        Task<bool> Delete(string id);
        Task<UserProfileDTO> GetUserProfileAsync(string id);
        Task<Result> ChangePassword(UserChangePasswordDTO user);
    }
}
