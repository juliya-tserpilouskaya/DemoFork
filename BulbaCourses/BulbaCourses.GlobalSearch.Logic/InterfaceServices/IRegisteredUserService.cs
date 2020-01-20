using BulbaCourses.GlobalSearch.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.InterfaceServices
{
    public interface IRegisteredUserService
    {
        IEnumerable<RegisteredUser> GetAll();
        Task<IEnumerable<RegisteredUser>> GetAllAsync();
        RegisteredUser GetById(string id);
        Task<RegisteredUser> GetByIdAsync(string id);
        RegisteredUser Add(RegisteredUser registeredUser);
        Task<RegisteredUser> AddAsync(RegisteredUser registeredUser);
        void RemoveById(string id);
        Task<int> RemoveByIdAsync(string id);
        void RemoveAll();
        Task<int> RemoveAllAsync();
    }
}
