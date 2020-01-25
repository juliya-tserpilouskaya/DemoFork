using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Data.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        T GetById(string id);
        IEnumerable<T> GetAll();
        void Add(T user);
        void Update(T user);
        void Remove(T user);
        void Save();
    }
}
