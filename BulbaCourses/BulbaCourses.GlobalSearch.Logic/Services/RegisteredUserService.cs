using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using BulbaCourses.GlobalSearch.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Services
{
    class RegisteredUserService : IRegisteredUserService
    {
        public RegisteredUser Add(RegisteredUser registeredUser)
        {
            return RegisteredUserStorage.Add(registeredUser);
        }

        public Task<RegisteredUser> AddAsync(RegisteredUser registeredUser)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegisteredUser> GetAll()
        {
            return RegisteredUserStorage.GetAll();
        }

        public Task<IEnumerable<RegisteredUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public RegisteredUser GetById(string id)
        {
            return RegisteredUserStorage.GetById(id);
        }

        public Task<RegisteredUser> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            RegisteredUserStorage.RemoveAll();
        }

        public Task<int> RemoveAllAsync()
        {
            throw new NotImplementedException();
        }

        public void RemoveById(string id)
        {
            RegisteredUserStorage.RemoveById(id);
        }

        public Task<int> RemoveByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
