using BulbaCourses.Video.Data.DatabaseContext;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Repositories
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {

        public RoleRepository(VideoDbContext videoDbContext) : base(videoDbContext)
        {
        }

        public void Add(RoleDb role)
        {
            _videoDbContext.Roles.Add(role);
            _videoDbContext.SaveChanges();

        }

        public async Task<int> AddAsync(RoleDb role)
        {
            _videoDbContext.Roles.Add(role);
            var result = await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
            return result;
        }

        public IEnumerable<RoleDb> GetAll()
        {
            var roleList = _videoDbContext.Roles.ToList().AsReadOnly();
            return roleList;

        }

        public async Task<IEnumerable<RoleDb>> GetAllAsync()
        {
            var roleList = await _videoDbContext.Roles.ToListAsync().ConfigureAwait(false);
            return roleList.AsReadOnly();
        }

        public RoleDb GetById(string rolelId)
        {
            var role = _videoDbContext.Roles.FirstOrDefault(b => b.RoleId.Equals(rolelId));
            return role;

        }

        public async Task<RoleDb> GetByIdAsync(string rolelId)
        {
            var role = await _videoDbContext.Roles.SingleOrDefaultAsync(b => b.RoleId.Equals(rolelId)).ConfigureAwait(false);
            return role;
        }

        public void Remove(RoleDb role)
        {
            _videoDbContext.Roles.Remove(role);
            _videoDbContext.SaveChanges();

        }

        public async Task<int> RemoveAsync(RoleDb role)
        {
            _videoDbContext.Roles.Remove(role);
            return await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Update(RoleDb role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }
            _videoDbContext.Entry(role).State = EntityState.Modified;
            _videoDbContext.SaveChanges();

        }

        public async Task<int> UpdateAsync(RoleDb role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }
            _videoDbContext.Entry(role).State = EntityState.Modified;
            return await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
