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
        bool IsLoginExist(string login);
        bool IsEmailExist(string email);
        bool ChangeLogin(string userName, string email);

        Task<UserInfo> GetUserByIdAsync(string userId);
        Task<IEnumerable<UserInfo>> GetAllAsync();
        Task<int> UpdateAsync(UserInfo user);
        Task<int> AddAsync(UserInfo user);
        Task<int> DeleteByIdAsync(string id);
    }
}
