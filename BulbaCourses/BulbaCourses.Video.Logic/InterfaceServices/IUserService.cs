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
        Task<bool> ExistLoginAsync(string login);
        Task<bool> CheckLoginAsync(string login);
        Task<bool> ExistEmailAsync(string email);
        Task<bool> CheckEmailForLossingPass(string email);
        Task<bool> CheckPasswordAsync(string id, string password);
        bool ChangeLogin(string userName, string email);

        Task<UserInfo> GetUserByIdAsync(string userId);
        Task<IEnumerable<UserInfo>> GetAllAsync();
        Task<int> UpdateAsync(UserInfo user);
        Task<int> AddAsync(UserInfo user);
        Task<int> DeleteByIdAsync(string id);
        Task<int> DeleteAsync(UserInfo user);
    }
}
