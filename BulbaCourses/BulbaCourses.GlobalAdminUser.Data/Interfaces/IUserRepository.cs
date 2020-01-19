using BulbaCourses.GlobalAdminUser.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Data.Interfaces
{
    public interface IUserRepository
    {
        UserDb GetById(string id);
        Task<IEnumerable<UserDb>> GetAllAsync();
        void Add(UserDb user);
        void Update(UserDb user);
        void Remove(UserDb user);
    }
}
