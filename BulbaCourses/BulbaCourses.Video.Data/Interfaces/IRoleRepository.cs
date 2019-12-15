using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Interfaces
{
    public interface IRoleRepository : IDisposable
    {
        RoleDb GetById(string rolelId);
        IEnumerable<RoleDb> GetAll();
        void Add(RoleDb role);
        void Update(RoleDb role);
        void Remove(RoleDb role);

        Task<RoleDb> GetByIdAsync(string rolelId);
        Task<IEnumerable<RoleDb>> GetAllAsync();
    }
}
