using BulbaCourses.GlobalAdminUser.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Data.Interfaces
{
    public interface IUserAdditonalInfoRepository
    {
        Task<UserAdditionalInfoDb> GetByIdAsync(string id);
        void Update(UserAdditionalInfoDb user);
        void Remove(UserAdditionalInfoDb user);
    }
}