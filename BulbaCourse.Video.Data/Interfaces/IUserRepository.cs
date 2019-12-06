using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Data.Interfaces
{
    public interface IUserRepository
    {
        UserDb GetById(string id);
        IEnumerable<UserDb> GetAll();
        void Add(UserDb user);
        void Update(UserDb user);
        void Remove(UserDb user);
    }
}
