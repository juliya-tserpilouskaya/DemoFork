using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Logic.Models.Enums;
using BulbaCourses.Video.Logic.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.InterfaceServices
{
    public interface IUserService
    {
        UserInfo GetUserById(string id);
        IEnumerable<UserInfo> GetAll();
        void Add(UserInfo user);
        void Delete(UserInfo user);
        void DeleteById(string userId);
        void Update(UserInfo user);

        Task<UserInfo> GetUserByIdAsync(string userId);
        Task<IEnumerable<UserInfo>> GetAllAsync();
        Task<Result<UserInfo>> UpdateAsync(UserInfo user);
        Task<Result<UserInfo>> AddAsync(UserInfo user);
        Task<Result> DeleteByIdAsync(string id);
        Task<Result> DeleteAsync(UserInfo user);
        Task<Result> BuySubscription(UserInfo user, Subscription subscription);
        Task<Result> BuySingleCourse(UserInfo user, CourseInfo course);
    }
}
